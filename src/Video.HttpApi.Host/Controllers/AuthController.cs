using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FreeRedis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Video.Application.Contract.UserInfos;
using Video.Application.Contract.UserInfos.Dtos;
using Video.Domain.Shared;
using Video.HttpApi.Host.Options;

namespace Video.HttpApi.Host.Controllers
{
    /// <summary>
    /// 认证
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserInfoService _userInfoService;
        private readonly IOptions<JWTOptions> _options;
        private readonly RedisClient _redisCilent;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfoService"></param>
        /// <param name="options"></param>
        /// <param name="redisCilent"></param>
        public AuthController(IUserInfoService userInfoService, IOptions<JWTOptions> options, RedisClient redisCilent)
        {
            _userInfoService = userInfoService;
            _options = options;
            _redisCilent = redisCilent;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginInput"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> PostAsync(LoginInput loginInput){
            var userInfo = await _userInfoService.LoginAsync(loginInput);
            if(!userInfo.Status){
                throw new BusinessException("账号已被禁用，详情请联系管理员");
            }
            //设置角色
            var roles = userInfo.Role.Select(x => new Claim(ClaimsIdentity.DefaultRoleClaimType, x.Code!)).ToList();
            //设置用户信息
            roles.Add(new Claim(ClaimsIdentity.DefaultIssuer, JsonSerializer.Serialize(userInfo)));
            roles.Add(new Claim(Constant.Id, userInfo.id.ToString()));

            var jwt = _options.Value;

            var keyByte = Encoding.UTF8.GetBytes(jwt.SecretKey);

            var cred = new SigningCredentials(new SymmetricSecurityKey(keyByte), SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                jwt.Issuer,//签发者
                jwt.Audience,//接收者
                roles,//payload
                expires: DateTime.Now.AddMinutes(jwt.ExpireMinutes),//过期时间
                signingCredentials: cred//令牌
            );

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        public async Task<string> RegisterAsync(RegisterInput input){
            var userInfo=await _userInfoService.RegisterAsync(input);
            //设置角色
            var roles = userInfo.Role.Select(x => new Claim(ClaimsIdentity.DefaultRoleClaimType, x.Code!)).ToList();
            //设置用户信息
            roles.Add(new Claim(ClaimsIdentity.DefaultIssuer, JsonSerializer.Serialize(userInfo)));
            roles.Add(new Claim(Constant.Id, userInfo.id.ToString()));

            var jwt = _options.Value;

            var keyByte = Encoding.UTF8.GetBytes(jwt.SecretKey);

            var cred = new SigningCredentials(new SymmetricSecurityKey(keyByte), SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                jwt.Issuer,//签发者
                jwt.Audience,//接收者
                roles,//payload
                expires: DateTime.Now.AddMinutes(jwt.ExpireMinutes),//过期时间
                signingCredentials: cred//令牌
            );

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }
    }
}
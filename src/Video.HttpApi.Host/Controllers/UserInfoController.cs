using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Video.Application.Contract.Base;
using Video.Application.Contract.UserInfos;
using Video.Application.Contract.UserInfos.Dtos;

namespace Video.HttpApi.Host.Controllers
{
    /// <summary>
    /// 登录账号获取用户信息
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoService _userInfoService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInfoService"></param>
        public UserInfoController(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<UserInfoRoleDto> GetAsync(){
            return await _userInfoService.GetAsync();
        }

        /// <summary>
        /// 修改用户数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Roles ="admin")]
        public async Task UpdateAsync(UpdateUserInfoInput input){
            await _userInfoService.UpdateAsync(input);
        }
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [Authorize(Roles ="admin")]
        public async Task<PageResultDto<UserInfoDto>> GetListAsync([FromQuery]GetListInput input){
            return await _userInfoService.GetListAsync(input);
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete("list")]
        [Authorize(Roles ="admin")]
        public async Task DeleteAsync(IEnumerable<Guid> ids){

            await _userInfoService.DeletesAsync(ids);
        }
        /// <summary>
        /// 禁用用户
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpPut("status")]
        [Authorize(Roles ="admin")]
        public async Task StatusAsync(IEnumerable<Guid> ids,bool status=true){
            await _userInfoService.StatusAsync(ids,status);
        }
    }
}
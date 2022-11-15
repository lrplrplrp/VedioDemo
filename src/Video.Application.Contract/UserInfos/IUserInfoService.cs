using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Video.Application.Contract.Base;
using Video.Application.Contract.UserInfos.Dtos;

namespace Video.Application.Contract.UserInfos
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserInfoService
    {
        
        /// <summary>
        /// 登录账号获取Token
        /// </summary>
        /// <param name="loginInput"></param>
        /// <returns></returns>
        Task<UserInfoRoleDto> LoginAsync(LoginInput loginInput);
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        Task<UserInfoRoleDto> GetAsync();
        /// <summary>
        /// 编辑用户信息
        /// </summary>
        /// <param name="updateUserInfoInput"></param>
        /// <returns></returns>
        Task UpdateAsync(UpdateUserInfoInput updateUserInfoInput);
        /// <summary>
        /// 注册账号
        /// </summary>
        /// <returns></returns>
        Task<UserInfoRoleDto> RegisterAsync(RegisterInput registerInput);
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PageResultDto<UserInfoDto>> GetListAsync(GetListInput input);
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task DeletesAsync(IEnumerable<Guid> ids);
        /// <summary>
        /// 禁用用户
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task StatusAsync(IEnumerable<Guid> ids,bool status=true);
    }
}
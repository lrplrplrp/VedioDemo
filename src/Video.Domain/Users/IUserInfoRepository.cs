using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simple.EntityFrameworkCore.Core;
using Video.Application.Contract.Base;
using Video.Application.Contract.UserInfos.Dtos;

namespace Video.Domain.Users
{
    public interface IUserInfoRepository:IRepository<UserInfo>
    {
        /// <summary>
        /// 获取用户信息，包括角色
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<UserInfoRoleView?> GetUserInfoRoleView(string username,string password);

        /// <summary>
        /// 获取用户信息，包括角色
        /// </summary>
        /// <returns></returns>
        Task<UserInfoRoleView> GetAsync(Guid id);

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<List<UserInfo>> GetListAsync(string? keywords,DateTime? startTime,DateTime? endTime,int skipCount,int maxResultCount);
        /// <summary>
        /// 获取用户总数
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        Task<int> GetCountAsync(string? keywords,DateTime? startTime,DateTime? endTime);
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task DeleteAsync(IEnumerable<Guid> ids);
        /// <summary>
        /// 禁用用户
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task StatusAsync(IEnumerable<Guid> ids,bool status=true);


    }
}
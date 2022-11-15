using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Simpie.EntityFrameworkCore.Core;
using Simpie.EntityFrameworkCore.Extensions;
using Video.Application.Contract.Base;
using Video.Application.Contract.UserInfos.Dtos;
using Video.Domain;
using Video.Domain.Users;

namespace Video.EntityFrameworkCore.User
{
    public class UserInfoRepository : Repository<UserInfo, VideoDbContext>, IUserInfoRepository
    {
        public UserInfoRepository(VideoDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<UserInfoRoleView> GetAsync(Guid id)
        {
            var userInfo=await _dbContext.UserInfo
                .Where(x=>x.id==id)
                .Select(x=>new UserInfoRoleView{
                        Avatar=x.Avatar,
                        CreateTime=x.CreateTime,
                        id=x.id,
                        Name=x.Name,
                        Password=x.Password,
                        Status=x.Status,
                        UserName=x.UserName
                })
                .FirstOrDefaultAsync();
            
            if(userInfo==null){
                return null;
            }

            var userInfoRole=_dbContext.UserRole.Where(x=>x.UserId==userInfo.id);

            var query=
            from role in _dbContext.Role
            join userRole in userInfoRole on role.id equals userRole.RoleId
            select role;
            userInfo.Role=query.ToList();
            return userInfo;
        }

        public async Task<UserInfoRoleView?> GetUserInfoRoleView(string username, string password)
        {
            var userInfo=await _dbContext.UserInfo
                .Where(x=>x.UserName==username&&x.Password==password)
                .Select(x=>new UserInfoRoleView{
                        Avatar=x.Avatar,
                        CreateTime=x.CreateTime,
                        id=x.id,
                        Name=x.Name,
                        Password=x.Password,
                        Status=x.Status,
                        UserName=x.UserName
                })
                .FirstOrDefaultAsync();
            
            if(userInfo==null){
                return null;
            }

            var userInfoRole=_dbContext.UserRole.Where(x=>x.UserId==userInfo.id);

            var query=
            from role in _dbContext.Role
            join userRole in userInfoRole on role.id equals userRole.RoleId
            select role;
            userInfo.Role=query.ToList();
            return userInfo;
        }

        public async Task<int> GetCountAsync(string? keywords, DateTime? startTime, DateTime? endTime)
        {
            var query =CreateQueryable(keywords,startTime,endTime);
            return await query.CountAsync();
        }

        public async Task<List<UserInfo>> GetListAsync(string? keywords, DateTime? startTime, DateTime? endTime, int skipCount, int maxResultCount)
        {
            var query =CreateQueryable(keywords,startTime,endTime);
            return await query.PageBy(skipCount,maxResultCount).ToListAsync();
        }

        public IQueryable<UserInfo> CreateQueryable(string? keywords, DateTime? startTime, DateTime? endTime){
            var query=
                _dbContext.UserInfo.WhereIf(!string.IsNullOrEmpty(keywords),x=>EF.Functions.Like(x.Name,keywords)&&
                EF.Functions.Like(x.UserName,keywords))
                .WhereIf(startTime.HasValue,x=>x.CreateTime>=startTime)
                .WhereIf(endTime.HasValue,x=>x.CreateTime<=endTime);
            return query;
        }

        public async Task DeleteAsync(IEnumerable<Guid> ids)
        {
            await _dbContext.Database.ExecuteSqlRawAsync("DELETE FROM UserInfo WHERE Id In ({0})",string.Join(",",ids));
        }

        public async Task StatusAsync(IEnumerable<Guid> ids,bool status=true)
        {
            await _dbContext.Database.ExecuteSqlRawAsync("UPDATE UserInfo SET Status={0} WHERE Id In ({1})",status,string.Join(",",ids));
        }
    }
}
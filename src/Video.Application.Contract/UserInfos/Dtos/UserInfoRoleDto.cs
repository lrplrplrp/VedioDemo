using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Video.Application.Contract.Base;

namespace Video.Application.Contract.UserInfos.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class UserInfoRoleDto:EntityDto
    {
        /// <summary>
        /// 
        /// </summary>
        public UserInfoRoleDto(){
            Role=new List<RoleDto>();
        }
        /// <summary>
        /// 用户名
        /// </summary>
        /// <value></value>
        public string? Name { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        /// <value></value>
        public string? UserName { get; set; }
        /// <summary>
        /// 密码（加密）
        /// </summary>
        /// <value></value>
        public string? Password { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        /// <value></value>
        public string? Avatar { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        /// <value></value>
        public bool Status { get; set; }=true;
        /// <summary>
        /// 角色
        /// </summary>
        /// <value></value>
        public List<RoleDto> Role { get; set; }
    }
}
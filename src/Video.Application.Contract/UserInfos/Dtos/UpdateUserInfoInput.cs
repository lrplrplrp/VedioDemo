using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Video.Application.Contract.UserInfos.Dtos
{
    /// <summary>
    /// 修改用户输入
    /// </summary>
    public class UpdateUserInfoInput
    {
        /// <summary>
        /// 用户名
        /// </summary>
        /// <value></value>
        public string? Name { get; set; }
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
    }
}
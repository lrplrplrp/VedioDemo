using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Video.Application.Contract.UserInfos.Dtos
{
    /// <summary>
    /// 注册输入
    /// </summary>
    public class RegisterInput
    {
        /// <summary>
        /// 验证码
        /// </summary>
        /// <value></value>
        public string? Code { get; set; }
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
    }
}
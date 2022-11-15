using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Video.Application.Contract.UserInfos.Dtos
{
    /// <summary>
    /// 登录接口
    /// </summary>
    public class LoginInput
    {
        /// <summary>
        /// 用户名
        /// </summary>
        /// <value></value>
        public string? Username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        /// <value></value>
        public string? Password { get; set; }
    }
}
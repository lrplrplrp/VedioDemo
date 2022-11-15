using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Video.HttpApi.Host.Options
{
    /// <summary>
    /// 
    /// </summary>
    public class JWTOptions
    {
        /// <summary>
        /// 密钥
        /// </summary>
        /// <value></value>
        public string SecretKey { get; set; } = null!;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Issuer { get; set; } =null!;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public string Audience { get; set; } =null!;
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int ExpireMinutes { get; set; }
    }
}
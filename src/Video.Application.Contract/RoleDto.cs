using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Video.Application.Contract.Base;

namespace Video.Application.Contract
{
    /// <summary>
    /// 
    /// </summary>
    public class RoleDto:EntityDto
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        /// <value></value>
        public string? Name { get; set; }
        /// <summary>
        /// 角色编号
        /// </summary>
        /// <value></value>
        public string? Code { get; set; }
    }
}
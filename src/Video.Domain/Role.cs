using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simple.EntityFrameworkCore.Core.Base;

namespace Video.Domain
{
    public class Role:Entity
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple.EntityFrameworkCore.Core.Base
{
    public class Entity
    {
        /// <summary>
        /// 主键
        /// </summary>
        /// <value></value>
        public Guid id { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <value></value>
        public DateTime CreateTime { get; set; }
    }
}
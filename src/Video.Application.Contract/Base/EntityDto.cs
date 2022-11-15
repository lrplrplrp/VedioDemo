using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Video.Application.Contract.Base
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public class EntityDto
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
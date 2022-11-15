using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simple.EntityFrameworkCore.Core.Base;

namespace Video.Domain.Videos
{
    /// <summary>
    /// 关注表
    /// </summary>
    public class BeanVermicelli:Entity
    {
        /// <summary>
        /// 被关注者
        /// </summary>
        /// <value></value>
        public Guid BeFocuseId { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        /// <value></value>
        public Guid UserId { get; set; }
    }
}
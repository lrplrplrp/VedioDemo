using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simple.EntityFrameworkCore.Core.Base;
using Video.Domain.Users;

namespace Video.Domain.Videos
{
    /// <summary>
    /// 视频表
    /// </summary>
    public class Video:Entity
    {
        /// <summary>
        /// 标题
        /// </summary>
        /// <value></value>
        public string? Title { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        /// <value></value>
        public string? Description { get; set; }
        /// <summary>
        /// 视频地址
        /// </summary>
        /// <value></value>
        public string? VideoUrl { get; set; }
        /// <summary>
        /// 分类ID
        /// </summary>
        /// <value></value>
        public Guid ClassifyId { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        /// <value></value>
        public Guid UserId { get; set; }

        public virtual UserInfo? User { get; set; }

        public Classify? Classify { get; set; }


    }
}
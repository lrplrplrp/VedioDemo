using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simple.EntityFrameworkCore.Core.Base;
using Video.Domain.Users;

namespace Video.Domain.Videos
{
    /// <summary>
    /// 点赞表
    /// </summary>
    public class Like:Entity
    {
        /// <summary>
        /// 视频id|评论id
        /// </summary>
        /// <value></value>
        public Guid VideoId { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        /// <value></value>
        public Guid UserId { get; set; }
        /// <summary>
        /// 点赞分类
        /// </summary>
        /// <value></value>
        public LikeType Type { get; set; }

        public virtual UserInfo? User { get; set; }


        public virtual Video? Video { get; set; }
    }
}
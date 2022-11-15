using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simple.EntityFrameworkCore.Core.Base;
using Video.Domain.Users;

namespace Video.Domain.Videos
{
    public class Comment:Entity
    {
        /// <summary>
        /// 上级评论Id
        /// </summary>
        /// <value></value>
        public Guid ParentId { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        /// <value></value>
        public string? Content { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        /// <value></value>
        public Guid UserId { get; set; }
        /// <summary>
        /// 视频id
        /// </summary>
        /// <value></value>
        public Guid VideoId { get; set; } 
        public UserInfo? User { get; set; }
        public Video? Video { get; set; }       
    }
}
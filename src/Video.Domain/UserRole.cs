using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simple.EntityFrameworkCore.Core.Base;

namespace Video.Domain
{
    public class UserRole:Entity
    {
        /// <summary>
        /// 用户id
        /// </summary>
        /// <value></value>
        public Guid UserId { get; set; }
        /// <summary>
        /// 角色id
        /// </summary>
        /// <value></value>
        public Guid RoleId { get; set; }
    }
}
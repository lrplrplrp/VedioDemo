using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simple.EntityFrameworkCore.Core.Base;

namespace Video.Domain.Videos
{
    public class Classify:Entity
    {
        /// <summary>
        /// 名称
        /// </summary>
        /// <value></value>
        public string? Name { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Video.Domain.Shared
{
    /// <summary>
    /// 业务异常
    /// </summary>
    public class BusinessException:Exception
    {
        public int Code { get; set; }
        public BusinessException(string message,int Code=400):base(message){

        }
    }
}
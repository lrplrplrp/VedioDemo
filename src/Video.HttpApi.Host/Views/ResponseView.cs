using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Video.HttpApi.Host.Views
{
    /// <summary>
    /// 响应视图
    /// </summary>
    public class ResponseView
    {
        /// <summary>
        ///  构造函数
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        public ResponseView(int code, string? message=null, object? data=null)
        {
            Code = code;
            Message = message;
            Data = data;
        }

        /// <summary>
        /// 状态码
        /// </summary>
        /// <value></value>
        public int Code { get; set; }
        /// <summary>
        /// 提示消息
        /// </summary>
        /// <value></value>
        public string? Message { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        /// <value></value>
        public object? Data { get; set; }
    }
}
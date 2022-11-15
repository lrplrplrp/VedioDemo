using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Video.Domain.Shared;
using Video.HttpApi.Host.Views;

namespace Video.HttpApi.Host.Filters
{
    /// <summary>
    /// 异常过滤器
    /// </summary>
    public class ExceptionFilter:ExceptionFilterAttribute
    {
        private readonly ILogger<ExceptionFilter> _logger;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="logger"></param>
        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            var ex=context.Exception;
            _logger.LogError("Path {Path} message {Exception}",context.HttpContext.Request.Path,context.Exception);

            if(ex is BusinessException exception){
                context.Result=new OkObjectResult(new ResponseView(exception.Code,exception.Message));
            }
            else{
                context.Result=new OkObjectResult(new ResponseView(500,ex.Message));
            }
            
            context.ExceptionHandled=true;
            return Task.CompletedTask;
        }
    }
}
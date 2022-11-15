using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Video.HttpApi.Host.Views;

namespace Video.HttpApi.Host.Filters
{
    /// <summary>
    /// 过滤器
    /// </summary>
    public class ResponseFilter:ActionFilterAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Result!=null){
                if(context.Result is ObjectResult){
                    ObjectResult? objectResult=context.Result as ObjectResult;
                    if(objectResult?.Value?.GetType().Name==nameof(ResponseView)){
                        var result=objectResult.Value as ResponseView;
                        context.Result=new ObjectResult(result);
                    }
                    else{
                        context.Result=new ObjectResult(new ResponseView(200,data:objectResult?.Value));
                    }
                }
                else if(context.Result is EmptyResult){
                    context.Result=new ObjectResult(new ResponseView(200));
                }
                else if(context.Result is ResponseView modelStateResult){
                    context.Result=new ObjectResult(modelStateResult);
                }
            }else{
                context.Result=new ObjectResult(new ResponseView(200));
            }
            base.OnActionExecuted(context);
        }
    }
}
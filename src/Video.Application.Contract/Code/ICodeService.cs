using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Video.Application.Contract.Code.Dto;

namespace Video.Application.Contract.Code
{
    /// <summary>
    /// 验证码
    /// </summary>
    public interface ICodeService
    {
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<string> GetAsync(CodeInput input);
    }
}
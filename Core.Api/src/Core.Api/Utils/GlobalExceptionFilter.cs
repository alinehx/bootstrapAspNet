using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Api.Utils
{
    public class GlobalExceptionFilter : IExceptionFilter, IDisposable
    {
        private readonly ILogger _logger;

        public GlobalExceptionFilter(ILoggerFactory logger)
        {
            _logger = logger.CreateLogger<GlobalExceptionFilter>();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void OnException(ExceptionContext context)
        {
            
            context.Result = new ObjectResult("Erro 500")
            {
                StatusCode = 500,
                DeclaredType = typeof(System.Type)
            };

            _logger.LogError("GlobalExceptionFilter", context.Exception);
        }
    }
}

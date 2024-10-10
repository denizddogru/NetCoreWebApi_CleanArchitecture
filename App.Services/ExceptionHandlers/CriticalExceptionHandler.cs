using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace App.Services.ExceptionHandlers;
public class CriticalExceptionHandler(ILogger<CriticalExceptionHandler> logger) : IExceptionHandler
{
    public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {

        // BUsiness logic

        if(exception is CriticalException)
        {
            Console.WriteLine("Hata ile ilgili sms gönderildi.");
        }

        return ValueTask.FromResult(false);
    }
}

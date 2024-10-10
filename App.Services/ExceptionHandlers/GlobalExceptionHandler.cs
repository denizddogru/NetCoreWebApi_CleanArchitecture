using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace App.Services.ExceptionHandlers;
public class GlobalExceptionHandler : IExceptionHandler
{

    #region Info

    // Global Exception Handler: .NET 8 ile birlikte gelen IException arayüzünü kuulanarak, 
    // uygulamada oluşan tüm işlenmemiş hataları yakalar ve JSON olarak döndürür. 
    // HttpContext : Mevcut HTTP isteği hakkında bilgi sağlar.
    // Exception: yakalanan hatayı temsil eder.
    // CancellationToken: Asenkron işlemin iptal edilmesini sağlar

    #endregion
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {

        // hata mesajını ve HTTp durum kodunu içeren bir hata nesnesi oluşturur.
        var errorAsDto = ServiceResult.Fail(exception.Message, HttpStatusCode.InternalServerError);

        // HTTP yanıtının durumunu 500 olarak ayarlar.
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        // içerik türünü JSON olarak belirler.
        httpContext.Response.ContentType = "application/json";

        // Oluşturulan hata nesnesini JSON formatında HTTP yanıtının gövedesine yazarr., işlem gerektiğinde iptal edilebilir.
        await httpContext.Response.WriteAsJsonAsync(errorAsDto, cancellationToken: cancellationToken);

        return true;
    }
}

using Microsoft.AspNetCore.Http;
using System;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace livraria.net.domain.Helper
{
    public static class Med
    {
        public static string GetTextFromApi(object Model, HttpContext context)
        {
            string Origin;

            if (context.Request.Headers.ContainsKey("x-ClientIP"))
            {
                Origin = context.Request.Headers["x-ClientIP"];
            }
            else if (context.Request.Headers.ContainsKey("x-FORWARDED-FOR"))
            {
                Origin = context.Request.Headers["x-FORWARDED-FOR"];
            }
            else
            {
                Origin =context.Connection.RemoteIpAddress.ToString();
            }

            var path = (context.Request.PathBase.HasValue ? context.Request.PathBase.Value : String.Empty)
                + (context.Request.Path.HasValue ? context.Request.Path.Value : String.Empty);

            return JsonConvert.SerializeObject(new
            {
                Origim = $"{Origin}:{context.Connection.RemotePort}",
                Destiny = $"{context.Connection.LocalIpAddress}:{context.Connection.LocalPort}",
                Scheme = $"{context.Request.Scheme}",
                Path = $"{path}",
                Method = $"{context.Request.Method}",
                ContentType = $"{context.Request.ContentType}",
                Payload = Model
            });
        }

        public static string GetTextFromResponse(ObjectResult result)
        {
            return
                $"Response\n" +
                $"StatusCode: {result.StatusCode}\n" +
                $"Object: {JsonConvert.SerializeObject(result.Value, Formatting.None)}";
        }
    }
}

using livraria.net.core.Controllers.Shared;
using Microsoft.AspNetCore.Mvc;
using System;

namespace livraria.net.core.Extensions
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class CustomResponseAttribute : ProducesResponseTypeAttribute
    {
        public CustomResponseAttribute(int statusCode) : base(typeof(CustomResult), statusCode) { }
    }
}

using AutoMapper;
using FluentValidation.Results;
using livraria.net.core.Contracts;
using livraria.net.core.Controllers.Shared;
using livraria.net.core.Extensions;
using livraria.net.core.Notificator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace livraria.net.core.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        protected readonly IMapper _mapper;
        protected readonly INotificator _notificator;
        protected readonly ILog _log;


        public MainController(IMapper mapper,
                              INotificator notificator, ILog log)
        {
            _mapper = mapper;
            _notificator = notificator;
            _log = log;
        }
        protected bool NotificatorHasNotifications()
        {
            return _notificator.HasNotification();
        }

        protected IEnumerable<string> GetErrorsFromNotificator()
        {
            return _notificator.GetNotifications().Select(n => n.Message);
        }

        protected IActionResult ResponseModelError(ModelStateDictionary modelState)
        {
            AddErrorNotification(modelState);
            return ResponseBadRequest();
        }

        protected IActionResult ResponseEntidadeError(List<ValidationFailure> error)
        {
            AddErrorNotification(error);
            return ResponseBadRequest();
        }

        protected void AddErrorNotification(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
            {
                var errorMsg = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                AddErrorNotification(errorMsg);
            }
        }

        protected new JsonResult Response(HttpStatusCode statusCode, object data, string errorMessage)
        {
            CustomResult result = null;

            if (string.IsNullOrWhiteSpace(errorMessage) && !NotificatorHasNotifications())
            {
                var success = statusCode.IsSuccess();

                if (data != null)
                    result = new CustomResult(statusCode, success, data);
                else
                    result = new CustomResult(statusCode, success);
            }
            else
            {
                var errors = new List<string>();

                if (!string.IsNullOrWhiteSpace(errorMessage))
                    errors.Add(errorMessage);

                if (NotificatorHasNotifications())
                    errors.AddRange(GetErrorsFromNotificator());

                result = new CustomResult(statusCode, false, errors);
            }
            return new JsonResult(result) { StatusCode = (int)result.StatusCode };
        }

        protected void AddErrorNotification(string mensagem)
        {
            _notificator.AddNotification(new Notification(mensagem));
        }

        protected void AddErrorNotification(ValidationFailure error)
        {
            AddErrorNotification(error.ErrorMessage);
        }

        protected void AddErrorNotification(List<ValidationFailure> errors)
        {
            foreach (var erro in errors) AddErrorNotification(erro.ErrorMessage);
        }


        protected IActionResult ResponseOk(object result) =>
            Response(HttpStatusCode.OK, result);

        protected IActionResult ResponseOk() =>
            Response(HttpStatusCode.OK);

        protected IActionResult ResponseCreated() =>
            Response(HttpStatusCode.Created);

        protected IActionResult ResponseCreated(object data) =>
            Response(HttpStatusCode.Created, data);

        protected IActionResult ResponseNoContent()
        {
            return NoContent();
        }

        protected IActionResult ResponseNotModified() =>
            Response(HttpStatusCode.NotModified);

        protected IActionResult ResponseBadRequest(string errorMessage) =>
            Response(HttpStatusCode.BadRequest, errorMessage: errorMessage);

        protected IActionResult ResponseBadRequest() =>
            Response(HttpStatusCode.BadRequest, errorMessage: "Invalid request");

        protected IActionResult ResponseNotFound(string errorMessage) =>
            Response(HttpStatusCode.NotFound, errorMessage: errorMessage);

        protected IActionResult ResponseNotFound() =>
            Response(HttpStatusCode.NotFound, errorMessage: "Resource not found");

        protected IActionResult ResponseUnauthorized(string errorMessage) =>
            Response(HttpStatusCode.Unauthorized, errorMessage: errorMessage);

        protected IActionResult ResponseUnauthorized() =>
            Response(HttpStatusCode.Unauthorized, errorMessage: "Denied access");

        protected IActionResult ResponseForbidden(string errorMessage) =>
            Response(HttpStatusCode.Forbidden, errorMessage: errorMessage);

        protected IActionResult ResponseForbidden() =>
            Response(HttpStatusCode.Forbidden, errorMessage: "Denied permission");

        protected IActionResult ResponseInternalServerError() =>
            Response(HttpStatusCode.InternalServerError);

        protected IActionResult ResponseInternalServerError(string errorMessage) =>
            Response(HttpStatusCode.InternalServerError, errorMessage: errorMessage);

        protected IActionResult ResponseInternalServerError(Exception exception) =>
            Response(HttpStatusCode.InternalServerError, errorMessage: exception.Message);

        protected new JsonResult Response(HttpStatusCode statusCode, object result) =>
            Response(statusCode, result, null);

        protected new JsonResult Response(HttpStatusCode statusCode, string errorMessage) =>
            Response(statusCode, null, errorMessage);

        protected new JsonResult Response(HttpStatusCode statusCode) =>
            Response(statusCode, null, null);

    }
   
}

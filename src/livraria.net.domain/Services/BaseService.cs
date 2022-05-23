using FluentValidation;
using FluentValidation.Results;
using livraria.net.core.Contracts;
using livraria.net.core.Models;
using livraria.net.core.Notificator;
using System.Collections.Generic;

namespace livraria.net.domain.Services
{
    public abstract class BaseService
    {

        protected readonly INotificator _notificator;

        protected BaseService(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected void Notify(List<ValidationFailure> errors)
        {
            foreach (var error in errors)
            {
                AddNotification(error.ErrorMessage);
            }
        }

        protected void AddNotification(string message)
        {
            _notificator.AddNotification(new Notification(message));
        }

        protected bool Validate<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid) return true;

            Notify(validator.Errors);
            return false;
        }
    }
}

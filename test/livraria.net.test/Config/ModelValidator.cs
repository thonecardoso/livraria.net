using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livraria.net.test.Config
{
    public static class ModelValidator
    {
        public static ValidatedObject Validate(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);

            var validatedObject = new ValidatedObject
            {
                IsValid = validationResults.Count() == 0,
                ErrorMessages = validationResults.Select(x => x.ErrorMessage.ToString()).ToList()
            };
            return validatedObject;
        }
    }

    public class ValidatedObject
    {
        public bool IsValid { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}

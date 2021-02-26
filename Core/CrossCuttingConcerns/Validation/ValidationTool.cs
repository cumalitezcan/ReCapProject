using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
   public static class ValidationTool
    {
        //Car Validator'ı kullanmamız için...
        public static void Validate(IValidator validator,object entity)
        {
            
            //Context, ilgili bir thread'i anlatır.
            var context = new ValidationContext<object>(entity);

            //RuleFor kurallarımız için ilgili contex'i doğrula.
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }

        
    }
}

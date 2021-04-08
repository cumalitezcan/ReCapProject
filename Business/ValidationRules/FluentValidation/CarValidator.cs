using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
          //  RuleFor(c => c.Descriptions).NotEmpty(); ;
         //   RuleFor(c=>c.Descriptions).MinimumLength(2);
          //  RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(50).When(c => c.BrandId == 1);
           // RuleFor(c=>c.Descriptions).Must(StartWithA); //Description A ile başlamalı
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Restaurant.Order.Application.Commands;
using Restaurant.Order.Domain.Enum;
using Restaurant.Order.Infra.Validator;

namespace Restaurant.Order.Application.Validators
{
    public interface ICreateOrderCommandValidator : IValidator<CreateOrderCommand> { }

    public class CreateOrderCommandValidator : CommandValidator<CreateOrderCommand>, ICreateOrderCommandValidator
    {
        public CreateOrderCommandValidator()
        {

        }

        protected override void CreateRules()
        {
            RuleFor(x => x.Input)
             .NotEmpty()
             .WithMessage("Input is required");

            RuleFor(x => x.Input)
              .Must(CommonValidators.CheckPeriod)
              .WithMessage("Please enter a valid period");
        }
    }

    public static class CommonValidators
    {
        public static bool CheckPeriod(string arg)
        {
            var input = arg.Split(",");

            if (!input[0].ToLower().Contains(PeriodType.Morning.Name.ToLower()) && !input[0].ToLower().Contains(PeriodType.Night.Name.ToLower()))
                return false;

            return true;
        }
    }
}

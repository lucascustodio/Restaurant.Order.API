using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using FluentValidation.Results;

namespace Restaurant.Order.Infra.Validator
{
    public abstract class CommandValidator<T> : AbstractValidator<T> where T : Command
    {
        public CommandValidator()
        {
            CreateRules();
        }

        protected abstract void CreateRules();

    }
}

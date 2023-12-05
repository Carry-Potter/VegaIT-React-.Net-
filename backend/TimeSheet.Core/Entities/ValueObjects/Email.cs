using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSheet.Core.Entities.ValueObjects
{
    public class Email : ValueObject
    {
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;


        }

        private string Value;

        public override string ToString()
        {
            return Value;
        }
        public static Result<Email> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result.Failure<Email>("Client name can not be empty");
            }

            if (value.Length > 100)
            {
                return Result.Failure<Email>("Long name!");
            }



            if (Is(value))
            {
                return Result.Failure<Email>("Client have number in name");

            }

            return Result.Success(new Email(value));
        }

        private static bool Is(string value)
        {
            foreach (char c in value)
            {
                if (c < '@')
                    return true;
            }

            return false;
        }

        private Email(string value)
        {
            Value = value;
        }

    }
}


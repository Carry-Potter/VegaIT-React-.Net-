using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSheet.Core.Entities.ValueObjects
{
    public class Country : ValueObject
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
        public static Result<Country> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result.Failure<Country>("Client name can not be empty");
            }

            if (value.Length > 40)
            {
                return Result.Failure<Country>("Long name!");
            }



            if (IsDigitsOnly(value))
            {
                return Result.Failure<Country>("Client have number in name");

            }

            return Result.Success(new Country(value));
        }

        private static bool IsDigitsOnly(string value)
        {
            foreach (char c in value)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private Country(string value)
        {
            Value = value;
        }
    
    }
}

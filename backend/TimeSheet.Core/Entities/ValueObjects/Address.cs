using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSheet.Core.Entities.ValueObjects
{
    public class Address : ValueObject
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
        public static Result<Address> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result.Failure<Address>("Client name can not be empty");
            }

            if (value.Length > 40)
            {
                return Result.Failure<Address>("Long name!");
            }



            if (IsDigitsOnly(value))
            {
                return Result.Failure<Address>("Client have number in name");

            }

            return Result.Success(new Address(value));
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

        private Address(string value)
        {
            Value = value;
        }

    }
}

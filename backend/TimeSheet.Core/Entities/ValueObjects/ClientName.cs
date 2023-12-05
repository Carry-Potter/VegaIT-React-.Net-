using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSheet.Core.Entities.ValueObjects
{
   public class ClientName : ValueObject
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

        public static Result<ClientName> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result.Failure<ClientName>("Client name can not be empty");
            }

             if (value.Length > 40)
            {
                return Result.Failure<ClientName>("Long name!");
            }

            

             if (IsDigitsOnly(value)) {
                return Result.Failure<ClientName>("Client have number in name");

            }

            return Result.Success(new ClientName(value));
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

        private ClientName(string value)
        {
            Value = value;
        }
    }
}

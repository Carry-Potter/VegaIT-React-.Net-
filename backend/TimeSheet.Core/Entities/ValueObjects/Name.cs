using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSheet.Core.Entities.ValueObjects
{
    public class Name : ValueObject
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

        public static Result<Name> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result.Failure<Name>("Client name can not be empty");
            }

            return Result.Success(new Name(value));
        }

        private Name(string value)
        {
            Value = value;
           
        }

        
    }
}

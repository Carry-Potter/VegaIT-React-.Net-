using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSheet.Core.Entities.ValueObjects
{
    public class MemberName : ValueObject
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
        public static Result<MemberName> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result.Failure<MemberName>("Member name can not be empty");
            }

            return Result.Success(new MemberName(value));
        }

        private MemberName(string value)
        {
            Value = value;
        }

    }



}

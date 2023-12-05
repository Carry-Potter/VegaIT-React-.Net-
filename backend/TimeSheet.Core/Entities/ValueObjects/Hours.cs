using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSheet.Core.Entities.ValueObjects
{
    public class Hours : ValueObject
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
        public static Result<Hours> Create(int value)
        {


            if (String.IsNullOrEmpty(value.ToString()))
            {
                return Result.Failure<Hours>("Hours name can not be empty");
            }
            if(value >24|| value <0)
            {
                return Result.Failure<Hours>("Hours 0 /24");
            }
            return Result.Success(new Hours(value));
        }

      

        private Hours(int value)
        {
            Value = value.ToString();
        }

    }
}
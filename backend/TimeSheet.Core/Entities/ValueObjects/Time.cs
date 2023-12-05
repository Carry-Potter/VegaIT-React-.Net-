using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSheet.Core.Entities.ValueObjects
{
    class Time : ValueObject
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

        public static Result<Time> Create(int value)
        {


            if (String.IsNullOrEmpty(value.ToString()))
            {
                return Result.Failure<Time>("Hours name can not be empty");
            }
            if (value > 24 || value < 0)
            {
                return Result.Failure<Time>("Hours 0 /24");
            }
            return Result.Success(new Time(value));
        }



        private Time(int value)
        {
            Value = value.ToString();
        }

    }
}
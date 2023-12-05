using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSheet.Core.Entities.ValueObjects
{
   public class ProjectName : ValueObject
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

        public static Result<ProjectName> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result.Failure<ProjectName>("Client name can not be empty");
            }

            return Result.Success(new ProjectName(value));
        }

        private ProjectName(string value)
        {
            Value = value;
            
        }

       
    }
}

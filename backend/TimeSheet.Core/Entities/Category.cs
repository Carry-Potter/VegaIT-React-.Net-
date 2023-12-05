using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using TimeSheet.Core.Entities.ValueObjects;

namespace TimeSheet.Core.Entities
{
   public class Category
    {
        public int Id { get; }
        public Name Name { get; }
        //name


        private Category(Name name, int id)
        {
            Id = id;
            Name = name;
        }

        public static Result<Category> Create(string name, int id)
        {
            Result<Name> LoginNameResult = Name.Create(name);
            if (LoginNameResult.IsFailure)
            {
                return Result.Failure<Category>("Client name can not be empty");
            }
            return Result.Success(new Category(LoginNameResult.Value, id));
        }

    }
}

using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace TimeSheet.Core.Entities
{
   public class PaginationModel

    {
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 10;

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        public List<Client> Data { get; set; }
    }
}

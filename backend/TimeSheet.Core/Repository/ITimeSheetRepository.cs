using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;


namespace TimeSheet.Core.Repository
{
    public interface ITimeSheetRepository
    {

        public void Delete(int id);
        public Maybe<Core.Entities.TimeSheet> FindById(int id);
        public IEnumerable<Core.Entities.TimeSheet> FindALL();
        public void Update(Core.Entities.TimeSheet timeSheet);
        public void Create(Core.Entities.TimeSheet timeSheet);
    }
}

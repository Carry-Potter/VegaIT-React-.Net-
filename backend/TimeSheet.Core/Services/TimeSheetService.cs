using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using TimeSheet.Core.Entities;
using TimeSheet.Core.Repository;

namespace TimeSheet.Core.Services
{
    public class TimeSheetService
    {
        private readonly ITimeSheetRepository _timeSheetRepository;

        public TimeSheetService(ITimeSheetRepository timeSheet)
        {
            _timeSheetRepository = timeSheet;
        }
        public Result Delete(int id)
        {
            if (_timeSheetRepository.FindById(id).HasNoValue)
            {
                return Result.Failure("no id!");
            }
            _timeSheetRepository.Delete(id);
            return Result.Success();


        }
        public IEnumerable<Core.Entities.TimeSheet> GetAll()
        {
            return _timeSheetRepository.FindALL();
        }
        public Result Update(Core.Entities.TimeSheet timeSheet)
        {
            if (_timeSheetRepository.FindById(timeSheet.Id).HasNoValue)
            {
                return Result.Failure("no id!");
            }
            _timeSheetRepository.Update(timeSheet);
            return Result.Success();
        }
        public Result FindById(Core.Entities.TimeSheet timeSheet)
        {
            if (_timeSheetRepository.FindById(timeSheet.Id).HasNoValue)
            {
                return Result.Failure("no id!");
            }
            _timeSheetRepository.Update(timeSheet);
            return Result.Success();
        }
    }
}
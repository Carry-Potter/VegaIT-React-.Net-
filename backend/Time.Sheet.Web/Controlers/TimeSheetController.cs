using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Time.Sheet.Web.DTO;
using TimeSheet.Core.Repository;
using TimeSheet.Core.Services;

namespace Time.Sheet.Web.Controlers
{
    [Route("api/timesheet")]
    [ApiController]
    public class TimeSheetController : Controller
    {

        public readonly TimeSheetService _timeSheetService;
        public readonly ITimeSheetRepository _timeSheetRepository;
        private readonly IMapper _mapper;
        public TimeSheetController(TimeSheetService timeSheetService, ITimeSheetRepository timeSheetRepository,
            IMapper mapper)
        {
            _timeSheetService = timeSheetService;
            _timeSheetRepository = timeSheetRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var timeSheet = _timeSheetService.GetAll();
            var results = _mapper.Map<IEnumerable<TimeSheetDTO>>(timeSheet);

            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var timeSheet = _timeSheetRepository.FindById(id);

            if (timeSheet.HasNoValue)
            {
                return BadRequest();
            }

            var vrednost = timeSheet.Value.OverTime.ToString();

            var timeSheetResult = new ClientDTO()
            {

               

            };

            return Ok(vrednost);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            var Result = _timeSheetService.Delete(id);
            if (Result.IsFailure)
            {
                return BadRequest();
            }
            return Ok();
        }

    }
}

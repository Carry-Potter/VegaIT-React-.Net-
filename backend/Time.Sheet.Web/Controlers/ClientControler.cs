using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Time.Sheet.Web.DTO;
using TimeSheet.Core.Entities;
using TimeSheet.Core.Repository;
using TimeSheet.Core.Services;
using TimeSheet.Persistance.Repository;

namespace Time.Sheet.Web.Controlers
{
    [Route("api/client")]
    [ApiController]
    public class ClientControler : ControllerBase 
    {
        public readonly IClientService _clientService;
        public readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public ClientControler(IClientService clientservice, IClientRepository clientRepository,
            IMapper mapper)
        {
            _clientService = clientservice;
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        [HttpGet("page/{currentPage}")]
        public IActionResult GetAll(int currentPage)
        {

            var clients = _clientService.GetAll(currentPage);
            var results = _mapper.Map<IEnumerable<ClientDTO>>(clients);

            return Ok(results);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var client = _clientRepository.FindById(id);

            if (client.HasNoValue)
            {
                return BadRequest();
            }

            

            var clientResult = new ClientDTO()
            {
                Id= client.Value.Id.ToString(),
                Name = client.Value.Name.ToString(),
                Address = client.Value.Address.ToString(),
                City = client.Value.City.ToString(),
                Country = client.Value.Country.ToString()

            };

            return Ok(clientResult);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            var Result = _clientService.Delete(id);
            if (Result.IsFailure)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult CreateClient(Client client)
        {

            var results = _clientService.Create(client);
            if(results.IsFailure)
            {
                return BadRequest();
            }


            return Ok(results);
        }

    }
}

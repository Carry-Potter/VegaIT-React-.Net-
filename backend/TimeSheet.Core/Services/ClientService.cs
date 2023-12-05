using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using TimeSheet.Core.Entities;
using TimeSheet.Core.Repository;

namespace TimeSheet.Core.Services
{
   public class IClientService 
    {
        private readonly IClientRepository _clientRepository;

        public IClientService(IClientRepository client)
        {
            _clientRepository = client;   
        }
        public Result Delete (int id)
        {
            if (_clientRepository.FindById(id).HasNoValue)
            {
                return Result.Failure("no id!");
            }
            _clientRepository.Delete(id);
            return Result.Success();
            
            
        }

        public IEnumerable<Client> GetAll(int currentPage)
        {


            return _clientRepository.FindALL(currentPage);
        }
        public Result Update(int v, Client client )
        {
            if (_clientRepository.FindById(client.Id).HasNoValue)
            {
                return Result.Failure("no id!");
            }
            _clientRepository.Update(client);
            return Result.Success();
        }
        public Result FindById(int id)
        {
            var vrednost = _clientRepository.FindById(id);

            if (_clientRepository.FindById(id).HasNoValue)
            {
                return Result.Failure("no id!");
            }
            return Result.Success(vrednost);
        }
        public Result Create( Client client)
        {
            _clientRepository.Create(client);
            return Result.Success();
        }

    }
}

using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using TimeSheet.Core.Entities;

namespace TimeSheet.Core.Repository
{
    public interface IClientRepository
    {
        void Delete(int id);
        Maybe<Client> FindById(int id);
        void Create(Client client);
        void Update(Client client);
        IEnumerable<Client> FindALL(int currentPage, int pageSize = 5);

    }
}

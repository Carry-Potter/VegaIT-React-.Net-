using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using TimeSheet.Core.Entities.ValueObjects;

namespace TimeSheet.Core.Entities
{
    public class Client
    {
        public int Id { get; }
        public ClientName Name { get; }
        public Address Address { get; }
        public City City { get; }
       
        public Country Country { get; }

        private Client(int id, ClientName name, Address address, City city, Country country)
        {
            Id = id;
            Name = name;
            Address = address;
            City = city;
            Country = country;

        }

        

        public static Result<Client> Create(int id,string name,string address,string city,string country)
        {
            Result<ClientName> ClientNameResult = ClientName.Create(name);
            Result<Address> ClientNameResult2 = Address.Create(address);
            Result<City> ClientNameResult3 = City.Create(city);
            Result<Country> ClientNameResult4 = Country.Create(country);
            var result = Result.Combine(ClientNameResult, ClientNameResult2, ClientNameResult3, ClientNameResult4);
            if (result.IsFailure)
            {
                return Result.Failure<Client>("Client name can not be empty");
            }
            return Result.Success(new Client(id, ClientNameResult.Value, ClientNameResult2.Value, ClientNameResult3.Value, ClientNameResult4.Value));
        }



    }
}

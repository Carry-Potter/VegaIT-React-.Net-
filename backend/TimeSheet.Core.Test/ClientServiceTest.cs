using System;
using TimeSheet.Core.Services;
using Xunit;
using Moq;
using TimeSheet.Core.Repository;
using TimeSheet.Core.Entities;
using System.Collections.Generic;
 
namespace TimeSheet.Core.Test
{
    public class ClientServiceTest
    {
        //TODO: Napraviti novu klasu koja ce biti odgovorna za testiranje
        [Fact]
        public void Fail_On_Deliting_Client_If_Client_Doesent_Existe()
        {
            var id = 1;
            var moqRepository = new Mock<IClientRepository>();

            var Client1 = Client.Create(id,"ivan","adresa","novi sad","srbija");
            var Client2 = Client.Create(2,"ivan","adresa","novi sad","srbija");

            var listClient = new List<Client>();
            listClient.Add(Client1.Value);
            listClient.Add(Client2.Value);

            moqRepository.Setup(clientReoisitory=>clientReoisitory.FindById(id)).Returns(listClient.Find(x=>x.Id==id));
            var clientService = new IClientService(moqRepository.Object);

            
            var rez= clientService.Delete(3);

            

            

            Assert.True(rez.IsFailure);

            moqRepository.Verify(x => x.FindById(3), Times.Once());

            moqRepository.Verify(x => x.Delete(3), Times.Never());


        }

        [Fact]
        public void Fail_On_GetALL_Client_If_Client_Doesent_Existe() {


            var id = 1;
            var moqRepository = new Mock<IClientRepository>();

            var Client1 = Client.Create(id, "ivan", "adresa", "novi sad", "srbija");
            var Client2 = Client.Create(2, "ivan", "adresa", "novi sad", "srbija");

            var listClient = new List<Client>();
            listClient.Add(Client1.Value);
            listClient.Add(Client2.Value);

            moqRepository.Setup(clientReoisitory => clientReoisitory.FindById(id)).Returns(listClient.Find(x => x.Id == id));
            var clientService = new IClientService(moqRepository.Object);

            IEnumerable<Client> clients = clientService.GetAll();





        }

        [Fact]
        public void Fail_On_FindById_Client_If_Client_Doesent_Existe()
        {

            var id = 1;
            var moqRepository = new Mock<IClientRepository>();

            var Client1 = Client.Create(id, "ivan", "adresa", "novi sad", "srbija");
            var Client2 = Client.Create(2, "ivan", "adresa", "novi sad", "srbija");

            var listClient = new List<Client>();
            listClient.Add(Client1.Value);
            listClient.Add(Client2.Value);

            moqRepository.Setup(clientReoisitory => clientReoisitory.FindById(id)).Returns(listClient.Find(x => x.Id == id));
            var clientService = new IClientService(moqRepository.Object);




            var rez = clientService.FindById(1);

            var rez1 = clientService.FindById(3);
            Assert.True(rez.IsFailure);



        }
        [Fact]
        public void Fail_On_Update_Client_If_Client_Doesent_Existe()
        {
            var id = 1;
            var moqRepository = new Mock<IClientRepository>();

            var Client1 = Client.Create(id, "ivan", "adresa", "novi sad", "srbija");
            var Client2 = Client.Create(2, "ivan", "adresa", "novi sad", "srbija");

            var listClient = new List<Client>();
            listClient.Add(Client1.Value);
            listClient.Add(Client2.Value);

            moqRepository.Setup(clientReoisitory => clientReoisitory.FindById(id)).Returns(listClient.Find(x => x.Id == id));
            var clientService = new IClientService(moqRepository.Object);




            var rez = clientService.Update(1, Client2.Value);
            rez = clientService.Update(3, Client2.Value);

            Assert.True(rez.IsFailure);

        }

    }
}

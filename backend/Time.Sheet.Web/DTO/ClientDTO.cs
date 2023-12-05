using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Time.Sheet.Web.DTO
{
    public class ClientDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Time.Sheet.Web.DTO
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string ProjectNames { get; set; }
        public string Description { get; set; }
        public ClientDTO Client { get; set; }
        public TeamMemberDTO TeamMember { get; set; }
        public string ProjectStatus { get; set; }
    }
}

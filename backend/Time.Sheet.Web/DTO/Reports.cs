using System;

namespace TimeSheet.Core.Entities
{
    class Reports
    {

        public int Id { get; set; }
        public string TeamMember { get; set; }
        public string Category { get; set; }
        public string Project { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public string Client { get; set; }

        private Reports( int id, string teamMember, string category, string project, string client)
        {
            Id = id;
            TeamMember = teamMember;
            Category = category;
            Project = project;
            Client = client;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Time.Sheet.Web.DTO
{
    public class TimeSheetDTO
    {

   
        public string Description { get; set; }
        public int Time { get; set; }
        public int OverTime { get; set; }
       // public string TeamMember { get; set; }
    }
}

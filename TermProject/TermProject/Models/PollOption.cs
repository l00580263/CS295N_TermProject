using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TermProject.Models
{
    public class PollOption
    {
        public int PollOptionID { get; set; }
        public string Name { get; set; }
        public int Votes { get; set; }
    }
}

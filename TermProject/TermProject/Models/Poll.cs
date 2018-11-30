using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TermProject.Models
{
    public class Poll
    {

        #region Properties
        public int PollID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PollOption> Options { get; set; }
        public DateTime EndDate { get; set; }
        #endregion



        #region Methods
        public string GetResult()
        {
            if (!IsPollClosed())
            {
                return "Poll Hasn't Closed.";
            }


            // order votes
            List<PollOption> sortedVotes = Options.OrderByDescending(v => v.Votes).ToList();

            if (sortedVotes[0] != sortedVotes[1])
            {
                // give winner
                return string.Format("{0} has won the vote.", sortedVotes[0].Name);
            }
            else
            {
                // tied
                return "The Poll has ended in a tie";
            }
        }



        public bool IsPollClosed()
        {
            if (EndDate.Ticks > DateTime.Now.Ticks)
            {
                return false;
            }

            return true;
        }
        #endregion
    }
}

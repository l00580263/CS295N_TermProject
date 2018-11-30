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



        public List<int> GetPercentages()
        {
            List<int> percentages = new List<int>();
            float normalizingValue = 0;

            foreach (PollOption op in Options)
            {
                // add votes
                normalizingValue += op.Votes;
            }
            
            foreach (PollOption op in Options)
            {
                // get percentage for options
                int p = (int) ((op.Votes / normalizingValue) * 100f);
                percentages.Add( p );
            }

            return percentages;
        }



        public string PollToHtml()
        {
            // list of colors
            List<string> colors = new List<string>() {"bg-primary", "bg-success", "bg-info", "bg-warning", "bg-danger", "bg-secondary", "bg-dark" };

            // format options
            string formattedBars = "";
            string formattedOptions = "";

            // get percentages
            List<int> percentages = GetPercentages();

            int i = 0;
            foreach (PollOption op in Options)
            {
                // make bar
                string bar = "";
                int p = percentages[i];
                while (p > 0)
                {
                    bar += "_";
                    p--;
                }
                
                // format option
                formattedBars += string.Format("<span class ='{0}'> {1} </span><br>", colors[i%colors.Count], bar);
                formattedOptions += string.Format("<strong> {0} </strong> - {1} votes <br>", op.Name, op.Votes);

                // next option
                i++;
            }

            // format poll
            string formatted = string.Format(@"
            <div class = 'img-thumbnail'>
                <h5 class = 'text-center text-primary'> {0} </h5>
                <div> {1} </div>
                <strong>Poll closes {2} </strong>
                
                <br>
                <br>

                <div class = 'row'>
                    <div class = 'col-lg-4 text-right'>
                        {3}
                    </div>
                    <div class = 'col-lg-8'>
                        {4}
                    </div>
                </div>
            </div>
            ", Name, Description, EndDate.Date.ToString("d"), formattedOptions, formattedBars);

            return formatted;
        }
        #endregion
    }
}

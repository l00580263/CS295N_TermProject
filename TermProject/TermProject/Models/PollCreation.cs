using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TermProject.Models
{
    public class PollCreation
    {
        #region Properties
        [Required(ErrorMessage = "The Poll Needs a Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "The Poll Needs Options")]
        public string Options { get; set; }
        [Required(ErrorMessage = "The Poll Needs an End Date")]
        public DateTime EndDate { get; set; }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAS_Capture_The_Flag.ViewModels
{
    public class SetNickNameViewModel
    {
        [Required(ErrorMessage = "You must enter a nickname")]
        public string Nickname { get; set; }
        //[Required]
        //public string LastName { get; set; }
        //[Required]
        //public string FirstName { get; set; }

        public SetNickNameViewModel()
        {

        }
    }
}

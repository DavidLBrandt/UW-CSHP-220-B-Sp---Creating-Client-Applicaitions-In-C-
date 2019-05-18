using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BirthdayCardGenerator.Models
{
    public class BirthdayCard
    {
        [Required(ErrorMessage ="Please enter who this card is From.")]
        public string From { get; set; }

        [Required(ErrorMessage = "Please enter who this card is To.")]
        public string To { get; set; }

        [Required(ErrorMessage = "Please enter this card's Message.")]
        public string Message { get; set; }
    }
}
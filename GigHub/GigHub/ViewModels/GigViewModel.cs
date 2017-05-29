using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GigHub.CustomAttributes;
using GigHub.Models;

namespace GigHub.ViewModels
{
    public class GigViewModel
    {
        [Required]
        [MaxLength(255)]
        public string Venue { get; set; }

        [Required]
        [ValidateDate]
        public string Date { get; set; }

        [Required]
        [ValidateTime]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
        public DateTime GetDateTime() {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}
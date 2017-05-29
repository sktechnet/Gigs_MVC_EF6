using System.Collections.Generic;
using GigHub.Models;

namespace GigHub.ViewModels
{
    public class GigViewModel
    {
        public string Name { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public int Genre { get; set; }

        public IEnumerable<Genre> Genres { get; set; } 
    }
}
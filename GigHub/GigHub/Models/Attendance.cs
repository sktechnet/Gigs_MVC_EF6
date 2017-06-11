
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace GigHub.Models
{
    public class Attendance
    {

        public Gig Gig { get; set; }
        public ApplicationUser Attendee { get; set; }

        
        [Key]
        [Column(Order = 1)]
        public int GigId { get; set; }


        [Key]
        [Column(Order = 2)]
        public string AttendeeId { get; set; }
        public bool IsAttending { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace TicketSystem_WebAPI.DAL.Entities
{
    public class Tickets
    {
        [Key]
        [Display(Name = "Id")] //Show
        [Required(ErrorMessage = "The field {0} is required")] //show message error, not null
        public Guid Id { get; set; }

        [Display(Name = "Usedate")]
        public DateTime? UseDate { get; set; }

        [Display(Name = "It's used?")]
        public bool IsUsed { get; set; }

        [Display(Name = "Entrance Gate")]
        public string EntranceGate { get; set; }
    }
}

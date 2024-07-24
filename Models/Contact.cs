using System.ComponentModel.DataAnnotations;

namespace W23G72.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a message.")]
        public string Message {  get; set; }
    }
}

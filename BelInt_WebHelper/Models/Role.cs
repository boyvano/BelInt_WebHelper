using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BelInt_WebHelper.Models
{
    public class Role
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }
    }
}
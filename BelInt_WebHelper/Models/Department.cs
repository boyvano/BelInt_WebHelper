using System.Collections.Generic;

namespace BelInt_WebHelper.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? OrganisationId { get; set; }
        public Organisation Organisation { get; set; }
        public List<User> Users { get; set; }
        public Department()
        {
            Users = new List<User>();
        }
    }
}
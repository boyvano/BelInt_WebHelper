using System.Collections.Generic;

namespace BelInt_WebHelper.Models
{
    public class Department
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("Organisation")]
        public int? OrganisationId { get; set; }
        public Organisation Organisation { get; set; }
        public List<User> Users { get; set; }
    }
}
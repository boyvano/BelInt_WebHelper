namespace BelInt_WebHelper.Models
{
    public class Organisation
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }

    }
}
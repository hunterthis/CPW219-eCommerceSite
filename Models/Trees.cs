using System.ComponentModel.DataAnnotations;

namespace CPW219_eCommerceSite.Models
{
    public class Trees
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
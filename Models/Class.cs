using System.ComponentModel.DataAnnotations;

namespace CPW219_eCommerceSite.Models
{
    public class Tree
    {

        [Key]
        public int TreeId { get; set; }
        [Required]
        public string NameofTree { get; set; }
        [Range(0,50)]

    }
}

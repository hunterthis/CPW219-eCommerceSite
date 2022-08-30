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


    /// <summary>
    /// Creates cookies model for trees to enter into webpage and buy stuff
    /// </summary>
    public class CartTreeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

}
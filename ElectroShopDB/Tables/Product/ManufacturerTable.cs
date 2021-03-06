using System.ComponentModel.DataAnnotations;

namespace ElectroShopDB
{
    public class ManufacturerTable
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
    }
}

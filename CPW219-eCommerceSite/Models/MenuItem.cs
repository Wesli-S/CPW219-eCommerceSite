using System.ComponentModel.DataAnnotations;

namespace CPW219_eCommerceSite.Models
{
    /// <summary>
    /// Represents a single item on a food menu for purchase
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// The unique identifier for each product
        /// </summary>
        [Key]
        public int MenuItemID { get; set; }

        /// <summary>
        /// The name of the food item as it appears on the menu
        /// </summary>
        [Required]
        public string MenuItemName { get; set; }

        /// <summary>
        /// The price of this specific food item
        /// </summary>
        [Range(0, int.MaxValue)]        
        public double MenuItemPrice { get; set; }
    }
}

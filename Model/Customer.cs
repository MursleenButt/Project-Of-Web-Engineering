using System;
using System.ComponentModel.DataAnnotations;

namespace KarigarBotiqueStore.Model
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        public string ProductName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Product quantity must be greater than 0.")]
        public int ProductQuantity { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Shipping cost cannot be negative.")]
        public int ShippingCost { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Total bill cannot be negative.")]
        public int TotalBill { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [StringLength(255, ErrorMessage = "Description cannot exceed 255 characters.")]
        public string Discription { get; set; }
    }
}
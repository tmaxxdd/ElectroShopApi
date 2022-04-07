﻿using System.ComponentModel.DataAnnotations;

namespace ElectroShopApi.Tables.Product
{
    public class ProductTable
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double NetPrice { get; set; }
        [Required]
        public double GrossPrice { get; set; }

        // Foreign Key
        [Required]
        public int ProductCategoryId { get; set; }
        // Reference Model
        public ProductCategoryTable ProductCategoryTable { get; set; }

        // Foreign Key
        [Required]
        public string ManufacturerId { get; set; }
        // Reference Model
        public ManufacturerTable ManufacturerTable { get; set; }

        // Foreign Key
        [Required]
        public string TaxRateId { get; set; }
        // Reference Model
        public TaxRateTable TaxRateTable { get; set; }
    }
}
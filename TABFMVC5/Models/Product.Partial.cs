namespace TABFMVC5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ProductMetaData))]
    public partial class Product : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Stock.HasValue && this.Price.HasValue)
            {
                if (this.Stock.Value * this.Price.Value > 100)
                {
                    yield return new ValidationResult("數量與價格匹配錯誤", new string[] { "Stock", "Price" });
                }
            }

            yield return ValidationResult.Success;
        }
    }

    public partial class ProductMetaData
    {
        [Required]
        public int ProductId { get; set; }
        
        [Required]
        [StringLength(80, ErrorMessage="欄位長度不得大於 80 個字元")]
        public string ProductName { get; set; }
        [Required]
        [Range(1, 10000)]
        public Nullable<decimal> Price { get; set; }
        [Required]
        public Nullable<bool> Active { get; set; }
        [Required]
        [Range(1, 9999)]
        public Nullable<decimal> Stock { get; set; }
        [Required]
        public bool IsShowDeleted { get; set; }
    
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}

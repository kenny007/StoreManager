using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreManager.API.Entities
{
    [Table("ProductGroups")]
    public class ProductGroup
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductGroupId { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }

        public int? ParentId { get; set; }
        public virtual ProductGroup ParentProductGroup { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public virtual ICollection<ProductGroup> SubProductGroup { get; set; }
        
    }
}
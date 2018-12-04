using StoreManager.API.Entities;

namespace StoreManager.API.Models
{
    public class GroupResource
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? ParentId { get; set; }
        public virtual ProductGroup ParentProductGroup { get; set; }
     
        
    }
}
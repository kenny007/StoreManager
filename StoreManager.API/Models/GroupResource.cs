using StoreManager.API.Entities;

namespace StoreManager.API.Models
{
    public class GroupResource
    {
        public GroupResource()
        {
            Id = -1;
            ParentId = -1;
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public int? ParentId { get; set; }
        public virtual ProductGroup ParentProductGroup { get; set; }
     
        
    }
}
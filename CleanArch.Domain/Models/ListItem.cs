namespace CleanArch.Domain.Models
{
    public class ListItem : BaseModel
    {
        public string? Name { get; set; }    

        public ICollection<ListItemValue> Values { get; set; }
    }
}

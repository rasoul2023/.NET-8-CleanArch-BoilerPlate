namespace CleanArch.Domain.Models
{
    public class ListItemValue: BaseModel 
    {
        public String? Value { get; set; }
        public string? ListItemId { get; set; }
        public ListItem ListItem { get; set; }
    }
}

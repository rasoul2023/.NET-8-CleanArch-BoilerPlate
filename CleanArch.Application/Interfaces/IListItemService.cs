using CleanArch.Domain.Models;

namespace CleanArch.Application.Interfaces
{
    public interface IListItemService
    {
        IEnumerable<ListItem> GetAll(); 
        ListItem GetById(string? id);   
        void AddItem(ListItem item);
        void UpdateItem (ListItem item);
        void DeleteItem (String? Id);
    }
}

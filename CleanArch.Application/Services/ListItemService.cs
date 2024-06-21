
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infrastructure;

namespace CleanArch.Application.Services
{
    public class ListItemService : IListItemService
    {
        private readonly AppDbContext _context;

        public ListItemService(AppDbContext context)
        {
            _context = context;
        }

        public void AddItem(ListItem item)
        {
            _context.ListItems.Add(item);
            _context.SaveChanges(); 
        }

        public void DeleteItem(string? Id)
        {
            var listItem = _context.ListItems.Find(Id);
            if (listItem != null)
            {
                _context.ListItems.Remove(listItem);
                _context.SaveChanges();
            }
        }


        public ListItem GetById(string? id)
        {
            return _context.ListItems.Find(id);
        }

        public void UpdateItem(ListItem item)
        {
            _context.ListItems.Update(item);
            _context.SaveChanges();
        }

        public IEnumerable<ListItem> GetAll()
        {
            return _context.ListItems.ToList();
        }
    }
}

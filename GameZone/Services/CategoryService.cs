using Microsoft.EntityFrameworkCore;

namespace GameZone.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetCategories()
        {
            return _context.categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
          .OrderBy(c => c.Text)
          .AsNoTracking()   //Improve performance
          .ToList();
        }
    }
}

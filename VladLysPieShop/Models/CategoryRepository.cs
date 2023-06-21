namespace VladLysPieShop.Models
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly VladLysPieShopDbContext _VladLysPieShopDbContext;

        public CategoryRepository(VladLysPieShopDbContext VladLysPieShopDbContext)
        {
            _VladLysPieShopDbContext = VladLysPieShopDbContext;
        }

        public IEnumerable<Category> AllCategories => _VladLysPieShopDbContext.Categories.OrderBy(p => p.CategoryName);
    }
}

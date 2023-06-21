using Microsoft.EntityFrameworkCore;

namespace VladLysPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly VladLysPieShopDbContext _VladLysPieShopDbContext;

        public PieRepository(VladLysPieShopDbContext VladLysPieShopDbContext)
        {
            _VladLysPieShopDbContext = VladLysPieShopDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _VladLysPieShopDbContext.Pies.Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _VladLysPieShopDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie? GetPieById(int pieId)
        {
            return _VladLysPieShopDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }

        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            return _VladLysPieShopDbContext.Pies.Where(p => p.Name.Contains(searchQuery));
        }
    }
}

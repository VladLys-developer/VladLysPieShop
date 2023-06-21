using VladLysPieShop.Models;
using Microsoft.AspNetCore.Components;

namespace VladLysPieShop.Pages.App
{
    public partial class PieCard
    {
        [Parameter]
        public Pie? Pie { get; set; }
    }
}

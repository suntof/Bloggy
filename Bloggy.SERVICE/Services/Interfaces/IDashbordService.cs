using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloggy.SERVICE.Services.Interfaces
{
    public interface IDashbordService
    {
        Task<List<int>> GetYearlyArticleCounts();
        Task<int> GetTotalArticleCount();
        Task<int> GetTotalGenreCount();
    }
}

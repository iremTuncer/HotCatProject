using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace WEB.Data
{
    public class HotCatUserDbContext:DbContext
    {
        public HotCatUserDbContext(DbContextOptions<HotCatDbContext> options) : base(options)
        {

        }
    }
}

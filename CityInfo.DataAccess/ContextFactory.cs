using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CityInfo.DataAccess
{
    /*public class ContextFactory : IDesignTimeDbContextFactory<CityInfoContext>
    {
        public enum ContextType
        {
            MEMORY, SQL
        }

        public CityInfoContext CreateDbContext(string[] args)
        {
            return GetNewContext();
        }

        public static CityInfoContext GetNewContext(ContextType type = ContextType.MEMORY)
        {
            var builder = new DbContextOptionsBuilder();
            DbContextOptions options = null;
            if (type == ContextType.MEMORY)
            {
                options = GetMemoryConfig(builder);
            }
            else
            {
                options = GetSqlConfig(builder);
            }
            return new CityInfoContext(options);
        }

        private static DbContextOptions GetMemoryConfig(DbContextOptionsBuilder builder)
        {
            builder.UseInMemoryDatabase("CityInfo");
            return builder.Options;
        }

        private static DbContextOptions GetSqlConfig(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CityInfo;Trusted_Connection=True;");
            return builder.Options;
        }
    }*/
}

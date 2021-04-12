using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace NewName.NewAbpZeroTemplate.EntityFrameworkCore
{
    public static class NewAbpZeroTemplateDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<NewAbpZeroTemplateDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<NewAbpZeroTemplateDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
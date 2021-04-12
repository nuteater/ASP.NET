using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using NewName.NewAbpZeroTemplate.Configuration;
using NewName.NewAbpZeroTemplate.Web;

namespace NewName.NewAbpZeroTemplate.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class NewAbpZeroTemplateDbContextFactory : IDesignTimeDbContextFactory<NewAbpZeroTemplateDbContext>
    {
        public NewAbpZeroTemplateDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<NewAbpZeroTemplateDbContext>();
            var configuration = AppConfigurations.Get(
                WebContentDirectoryFinder.CalculateContentRootFolder(),
                addUserSecrets: true
            );

            NewAbpZeroTemplateDbContextConfigurer.Configure(builder, configuration.GetConnectionString(NewAbpZeroTemplateConsts.ConnectionStringName));

            return new NewAbpZeroTemplateDbContext(builder.Options);
        }
    }
}
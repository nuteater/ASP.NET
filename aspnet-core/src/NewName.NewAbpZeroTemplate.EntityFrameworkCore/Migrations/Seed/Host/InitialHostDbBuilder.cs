using NewName.NewAbpZeroTemplate.EntityFrameworkCore;

namespace NewName.NewAbpZeroTemplate.Migrations.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly NewAbpZeroTemplateDbContext _context;

        public InitialHostDbBuilder(NewAbpZeroTemplateDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}

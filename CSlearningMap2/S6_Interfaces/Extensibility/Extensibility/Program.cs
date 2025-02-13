
namespace Extensibility
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbMigrator = new DbMigrator(new FileLogger("C:\\Users\\brigi\\Documents\\AA - Stage2\\CSlearning\\CSlearningMap2\\S6_Interfaces\\Extensibility\\log.txt"));
            dbMigrator.Migrate();
        }
    }
}

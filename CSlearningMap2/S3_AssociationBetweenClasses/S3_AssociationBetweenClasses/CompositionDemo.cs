//using static System.Net.Mime.MediaTypeNames;

//namespace S3_AssociationBetweenClasses
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var dbMigrator = new DbMigrator(new Logger());

//            var logger = new Logger();
//            var installer = new Installer(logger);

//            dbMigrator.Migrate();

//            installer.Install();
//        }
//    }

//    public class Logger
//    {
//        public void Log(string message)
//        {
//            Console.WriteLine(message);
//        }
//    }

//    public class Installer
//    {
//        private readonly Logger _logger;

//        public Installer(Logger logger)
//        {
//            _logger = logger;
//        }

//        public void Install()
//        {
//            _logger.Log("We are installing the application.");
//        }
//    }

//    public class DbMigrator
//    {
//        private readonly Logger _logger;

//        public DbMigrator(Logger logger)
//        {
//            _logger = logger;
//        }

//        public void Migrate()
//        {
//            _logger.Log("We are migrating blah blah blah...");
//        }
//    }
//}

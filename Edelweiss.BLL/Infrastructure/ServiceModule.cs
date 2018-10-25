
//using Ninject.Modules;

namespace Edelweiss.BLL.Infrastructure
{
    public class ServiceModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        //public override void Load()
        //{
        //    Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        //}
    }
}

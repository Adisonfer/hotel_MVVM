using Ninject.Modules;

namespace hotel_MVVM.Utils
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            //Bind<IDbRepos>().To<DbReposSQL>();
            //Bind<IApplicantService>().To<ApplicantService>();

        }
    }
}

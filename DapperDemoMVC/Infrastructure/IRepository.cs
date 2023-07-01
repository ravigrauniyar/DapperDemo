using DapperDemoMVC.Models;

namespace DapperDemoMVC.Infrastructure
{
    public interface IRepository
    {
        public bool VerifyLogin(LoginCredentialsModel loginCredentials);
    }
}

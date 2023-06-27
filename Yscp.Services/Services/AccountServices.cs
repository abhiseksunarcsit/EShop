using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yscp.Core.IRepositories;
using Yscp.Data.Healper;
using Yscp.Data.Models.ViewModels;
using Yscp.Services.Interfaces;

namespace Yscp.Services.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly IAccountRepositories _accountRepo;
        public AccountServices(IAccountRepositories accountRepo)
        {
            _accountRepo = accountRepo;
        }
        public async Task<DataResult> LoginAsync(LoginView model)
        {
            var result = await _accountRepo.LoginAsync(model);
            return result;
        }

        public async Task<DataResult> RegisterAsync(Registerview model)
        {
            //var result = await _accountRepo.RegisterAsync(model);
            //return result;
            DataResult result = await _accountRepo.RegisterAsync(model);
            return result;
        }

        public async Task SignOutAsync()
        {
            await _accountRepo.SignOutAsync();


        }
    }
}

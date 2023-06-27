using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yscp.Data.Healper;
using Yscp.Data.Models.ViewModels;

namespace Yscp.Services.Interfaces
{
    public interface IAccountServices
    {
        Task<DataResult> LoginAsync(LoginView model);

        Task<DataResult> RegisterAsync(Registerview model);
        Task SignOutAsync();
    }
}

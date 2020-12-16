using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetterBuys.Interfaces
{
    public interface ILoginCartManagerService
    {
        Task ManageCart(HttpContext context, string user);
    }
}

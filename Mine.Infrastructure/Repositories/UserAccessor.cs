using Mine.Application.Contracts.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Mine.Infrastructure.Repositories
{
    public class UserAccessor : IUserAccessor
    {
        public ClaimsPrincipal User => new();

        public Guid UserId => new Guid("00000000-0000-0000-0000-000000000000");

        public string Username => string.Empty;

        public string Ip => string.Empty;

        public string Origin => string.Empty;
    }
}

using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Mine.Application.Contracts.Authorization
{
    public interface IUserAccessor
    {
        ClaimsPrincipal User { get; }
        Guid UserId { get; }
        string Username { get; }
        string Ip { get; }
        string Origin { get; }
    }
}

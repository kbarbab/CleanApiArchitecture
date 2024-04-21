using Mine.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mine.Application.Contracts.Persistence
{
    public interface IUserRepository : IAsyncRepository<UserEntity>
    {
    }
}

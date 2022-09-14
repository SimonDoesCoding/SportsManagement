using System;
using SportsManagement.Accounts.Api.DTOs;

namespace SportsManagement.Accounts.Api.Repositories.Interfaces
{
    public interface IAccountsRepository
    {
        Task<IEnumerable<AccountDTO>> Get();
        Task<AccountDTO> Get(int id);
        Task Create(AccountDTO account);
        Task Update(int id, AccountDTO updatedAccount);
        Task SoftDelete(int id);
        Task HardDelete(int id);
    }
}


using System;
using SportsManagement.Accounts.Api.Models;

namespace SportsManagement.Accounts.Api.Services.Interfaces
{
    public interface IAccountsService
    {
        Task<IEnumerable<Account>> Get();
        Task<Account> Get(int id);
        Task<Account> Create(Account account);
        Task<Account> Update(int id, Account updatedAccount);
        Task Delete(int id, bool isHardDelete = false);
    }
}


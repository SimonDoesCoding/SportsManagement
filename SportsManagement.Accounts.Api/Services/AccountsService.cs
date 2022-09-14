using System;
using AutoMapper;
using SportsManagement.Accounts.Api.DTOs;
using SportsManagement.Accounts.Api.Models;
using SportsManagement.Accounts.Api.Repositories.Interfaces;
using SportsManagement.Accounts.Api.Services.Interfaces;

namespace SportsManagement.Accounts.Api.Services
{
    public class AccountsService : IAccountsService
    {
        readonly IAccountsRepository _repo;
        readonly IMapper _mapper;


        public AccountsService(IMapper mapper, IAccountsRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<Account> Create(Account account)
        {
            await _repo.Create(_mapper.Map<AccountDTO>(account));
            var accountDTO = await _repo.Get(account.Id);
            var insertedAccount = _mapper.Map<Account>(_repo.Get(account.Id));

            return insertedAccount;
        }

        public async Task Delete(int id, bool isHardDelete = false)
        {
            if (isHardDelete)
            {
                await _repo.HardDelete(id);
                return;
            }

            await _repo.SoftDelete(id);
        }

        public async Task<IEnumerable<Account>> Get()
        {
            var accountDTOs = await _repo.Get();
            var accounts = _mapper.Map<IEnumerable<Account>>(accountDTOs);

            return accounts;
        }

        public async Task<Account> Get(int id)
        {
            var accountDTO = await _repo.Get(id);
            var account = _mapper.Map<Account>(accountDTO);

            return account;
        }

        public async Task<Account> Update(int id, Account updatedAccount)
        {
            var updatedAccountDTO = _mapper.Map<AccountDTO>(updatedAccount);
            await _repo.Update(id, updatedAccountDTO);
            var accountDTO = await _repo.Get(id);
            var account = _mapper.Map<Account>(accountDTO);

            return account;
        }
    }
}


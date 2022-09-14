using System;
namespace SportsManagement.Accounts.Api.DTOs
{
    public class AccountDTO : BaseDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? PasswordHash { get; set; }
        public string? PasswordSalt { get; set; }
        public bool IsVerified { get; set; }
    }
}


using System;
namespace SportsManagement.Accounts.Api.Models
{
    public class Account : BaseModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
    }
}


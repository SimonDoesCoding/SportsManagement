using System;
using SportsManagement.Common.DTOs;

namespace SportsManagement.Teams.Api.DTOs
{
    public class TeamDTO : BaseDTO
    {
        public string? Name { get; set; }
        public string? TeamCode { get; set; }
    }
}


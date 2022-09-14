using System;
namespace SportsManagement.Common.DTOs
{
    public class BaseDTO
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}


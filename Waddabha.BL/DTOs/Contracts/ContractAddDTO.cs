﻿using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.DTOs.Contracts
{
    public class ContractAddDTO
    {
        public decimal Price { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? WorkLocation { get; set; }
        public string? Description { get; set; }
        public string ServiceId { get; set; }


    }
}

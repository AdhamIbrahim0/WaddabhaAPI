﻿using Waddabha.DAL.Data.Models;
using Waddabha.DAL.Data.Enums;

namespace Waddabha.BL.DTOs.Contracts
{
    public class ContractReadDTO : BaseEntity
    {

        public decimal? Price { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? WorkLocation { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; } = Status.Pending; 
        public double? Rating { get; set; }
        public string? FeedbackComment { get; set; }
        public virtual Service Service { get; set; }
        public virtual Buyer Buyer { get; set; }
        public string ChatRoomId { get; set; }

    }
}

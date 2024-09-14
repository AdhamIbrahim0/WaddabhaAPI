using Waddabha.DAL.Data.Enums;
﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Waddabha.DAL.Data.Models
{
    public class Contract : BaseEntity
    {
        public decimal Price { get; set; } // 
        public DateTime? StartDate { get; set; } //
        public DateTime? EndDate { get; set; }//
        public string? WorkLocation { get; set; }//
        public string? Description { get; set; }//
        public double? Rating { get; set; }
        public string? FeedbackComment { get; set; }
        public Status Status { get; set; } = Status.Pending;
        public virtual Service Service { get; set; }
        public string ServiceId { get; set; }
        public virtual Buyer Buyer { get; set; }
        public string BuyerId { get; set; }
        public virtual Seller Seller { get; set; }
        public string SellerId { get; set; }
        public virtual ChatRoom ChatRoom { get; set; }
        public string ChatRoomId { get; set; }
    }
}

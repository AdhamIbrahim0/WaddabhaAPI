﻿namespace Waddabha.DAL.Data.Models
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

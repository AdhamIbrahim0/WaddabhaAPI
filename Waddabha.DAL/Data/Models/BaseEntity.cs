﻿namespace Waddabha.DAL.Data.Models
{
    public class BaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

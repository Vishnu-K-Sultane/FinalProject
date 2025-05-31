﻿using FinalProject.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace FinalProject.Entities.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }  
        [Required]
        [MaxLength(20)]
        public string RoomNumber { get; set; } = null!;
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(50)]
        public BedType BedType { get; set; }
    }
}

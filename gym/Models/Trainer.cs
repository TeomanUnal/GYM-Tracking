using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace gym.Models
{
    public partial class Trainer
    {
        public Trainer()
        {
            Sınıflars = new HashSet<Sınıflar>();
        }

        [Key]
        [Column("TrainerID")]
        public int TrainerId { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        [StringLength(100)]
        public string? Specialty { get; set; }

        [InverseProperty("Trainer")]
        public virtual ICollection<Sınıflar> Sınıflars { get; set; }
    }
}

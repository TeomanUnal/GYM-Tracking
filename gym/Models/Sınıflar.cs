using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace gym.Models
{
    public partial class Sınıflar
    {
        public Sınıflar()
        {
            Bookings = new HashSet<Booking>();
        }

        [Key]
        [Column("ClassID")]
        public int ClassId { get; set; }
        [StringLength(100)]
        public string ClassName { get; set; } = null!;
        [Column("TrainerID")]
        public int? TrainerId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Schedule { get; set; }

        [ForeignKey("TrainerId")]
        [InverseProperty("Sınıflars")]
        public virtual Trainer? Trainer { get; set; }
        [InverseProperty("Class")]
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}

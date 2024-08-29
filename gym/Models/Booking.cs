using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace gym.Models
{
    public partial class Booking
    {
        [Key]
        [Column("BookingID")]
        public int BookingId { get; set; }
        [Column("MemberID")]
        public int? MemberId { get; set; }
        [Column("ClassID")]
        public int? ClassId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BookingDate { get; set; }

        [ForeignKey("ClassId")]
        [InverseProperty("Bookings")]
        public virtual Sınıflar? Class { get; set; }
        [ForeignKey("MemberId")]
        [InverseProperty("Bookings")]
        public virtual Member? Member { get; set; }
    }
}

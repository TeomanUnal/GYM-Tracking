using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace gym.Models
{
    public partial class Member
    {
        public Member()
        {
            Bookings = new HashSet<Booking>();
            Memberships = new HashSet<Membership>();
            Payments = new HashSet<Payment>();
        }

        [Key]
        [Column("MemberID")]
        public int MemberId { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }
        [StringLength(100)]
        public string? Email { get; set; }
        [StringLength(15)]
        public string? PhoneNumber { get; set; }
        [StringLength(255)]
        public string? PhotoPath { get; set; }
        [NotMapped]
        [DisplayName("Upload Image File")]
        public IFormFile? ImageFile { get; set; }

        [InverseProperty("Member")]
        public virtual ICollection<Booking> Bookings { get; set; }
        [InverseProperty("Member")]
        public virtual ICollection<Membership> Memberships { get; set; }
        [InverseProperty("Member")]
        public virtual ICollection<Payment> Payments { get; set; }
    }
}

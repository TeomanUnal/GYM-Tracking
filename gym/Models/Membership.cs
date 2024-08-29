using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace gym.Models
{
    public partial class Membership
    {
        [Key]
        [Column("MembershipID")]
        public int MembershipId { get; set; }
        [Column("MemberID")]
        public int? MemberId { get; set; }
        [StringLength(50)]
        public string MembershipType { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        [ForeignKey("MemberId")]
        [InverseProperty("Memberships")]
        public virtual Member? Member { get; set; }
    }
}

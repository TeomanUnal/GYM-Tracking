using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace gym.Models
{
    public partial class Payment
    {
        [Key]
        [Column("PaymentID")]
        public int PaymentId { get; set; }
        [Column("MemberID")]
        public int? MemberId { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PaymentDate { get; set; }

        [ForeignKey("MemberId")]
        [InverseProperty("Payments")]
        public virtual Member? Member { get; set; }
    }
}

using System.Collections.Generic;

namespace gym.Models
{
    public class Cascade
    {
        public IEnumerable<MembershipViewModel> MembershipList { get; set; }
    }

    public class MembershipViewModel
    {
        public int MembershipId { get; set; }
        public string MembershipType { get; set; }
        public List<MemberViewModel> Members { get; set; }
    }

    public class MemberViewModel
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; }
    }
}

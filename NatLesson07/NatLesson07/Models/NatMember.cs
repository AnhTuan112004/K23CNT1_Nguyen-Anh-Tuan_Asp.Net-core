using System.ComponentModel.DataAnnotations;

namespace NatLesson07.Models
{
    public class NatMember
    {
        public int NatId { get; set; }

        public string NatName { get; set; }
        public string NatUserName { get; set; }

        public string NatPassword { get; set; }

        public string NatEmail { get; set; }

        public bool NatStatus { get; set; }
    }
}

namespace Muhasebecini.Entities
{
    public class AccountantInfo
    {
        public AccountantInfo()
        {
            CommendInfos = new HashSet<CommendInfo>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Url { get; set; }
        public string Address { get; set; }
        public Byte[] Image { get; set; }

        public virtual ICollection<CommendInfo> CommendInfos { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Muhasebecini.Entities
{
    public class CustomerInfo
    {
        public CustomerInfo()
        {
            CommendInfos = new HashSet<CommendInfo>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string  Surname { get; set; }

        public virtual ICollection<CommendInfo> CommendInfos { get; set; }
    }
}

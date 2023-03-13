using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Muhasebecini.Entities
{
    public class CommendInfo
    {
        public int Id { get; set; }                
        public string Commend { get; set; }

        public int AccountantId { get; set; }
        public int CustomerId { get; set; }

        public virtual AccountantInfo  AccountantInfo { get; set; }
        public virtual CustomerInfo  CustomerInfo { get; set; }
    }
}

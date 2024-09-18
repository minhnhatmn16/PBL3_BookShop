using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DTO
{
    public class Account
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public String RoleName { get; set; }
        public String AccountName { get; set; }
        public String Password { get; set; }
        public String UserName { get; set; }
        public String Sex { get; set; }
        public int SexID { get; set; }
        public DateTime Birth { get; set; }
        public String PhoneNumber { get; set; }
        public String Address { get; set; }
        public String Status { get; set; }

    }
}

using BookShop.BLL_ST;
using BookShop.DAL;
using BookShop.DAL_ST;
using BookShop.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BLL
{
    internal class Role_BLL
    {
        private static Role_BLL _Instance;
        public static Role_BLL Instance
        {
            get
            {
                if (_Instance == null) _Instance = new Role_BLL();
                return _Instance;
            }
            private set
            {

            }
        }

        //getBook B1. transfer each row in datarow to actual model
        public Role GetDBRole(DataRow Role)
        {
            Role St = new Role();
            St.RoleID = Convert.ToInt32(Role["RoleID"]);
            St.RoleName = Convert.ToString(Role["RoleName"]);

            return St;
        }

        //getRole B2. transfer model to a gridview
        public List<Role> GetRoleInfor(string Name)
        {
            List<Role> St = new List<Role>();

            foreach (DataRow i in Role_DAL.Instance.Get_RoleInfor().Rows)
            {
                if (Name == "") St.Add(GetDBRole(i)); //get all Roles
                else if ((Convert.ToString(i["RoleName"])).Contains(Name)) //get Roles that have 'title' match the text in textbox
                    St.Add(GetDBRole(i));

            }
            return St;  //return in type list<model>
        }

        public String GetRoleName(int RoleID) //get Role name by id (used for other table to reference to)
        {
            String Name = "";
            foreach (DataRow i in Role_DAL.Instance.Get_RoleInfor().Rows)
            {
                if (Convert.ToInt32(i["RoleID"]) == RoleID)
                {
                    Name = Convert.ToString(i["RoleName"]);
                    break;
                }

            }
            return Name;  //return in type list<model>
        }
    }
}

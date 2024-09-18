using BookShop.BLL;
using BookShop.DAL;
using BookShop.DAL_ST;
using BookShop.DTO;
using BookShop.DTO_ST;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BLL_ST
{
    internal class Account_BLL
    {
        private static Account_BLL _Instance;
        public int UserID = 0;
        public static Account_BLL Instance
        {
            get
            {
                if (_Instance == null) _Instance = new Account_BLL();
                return _Instance;
            }
            private set
            {

            }
        }

        //getBook B1. transfer each row in datarow to actual model
        public Account GetDBAccount(DataRow Account)
        {
            Account St = new Account();
            St.UserID = Convert.ToInt32(Account["UserID"]);
            St.RoleID = Convert.ToInt32(Account["RoleID"]);
            St.RoleName = Role_BLL.Instance.GetRoleName(St.RoleID);
            St.AccountName = Convert.ToString(Account["AccountName"]);
            St.Birth = Convert.ToDateTime(Account["Birth"]);
            St.Password = Convert.ToString(Account["Password"]);
            St.UserName = Convert.ToString(Account["UserName"]);
            St.SexID = Convert.ToInt32(Account["SexID"]);
            St.Sex = Gender.ID[St.SexID];
            St.PhoneNumber = Convert.ToString(Account["PhoneNumber"]);
            St.Address = Convert.ToString(Account["Address"]);
            St.Status = Convert.ToString(Account["Status"]);

            return St;
        }

        //getAccount B2. transfer model to a gridview
        public List<Account> GetAccountInfor(string Name)
        {
            List<Account> St = new List<Account>();

            foreach (DataRow i in Account_DAL.Instance.Get_AccountInfor().Rows)
            {
                Account temp = new Account();
                temp = GetDBAccount(i);
                if (Name == "") St.Add(temp); //get all Accounts
                else if (searchAllField(temp, Name)) //get Accounts that have 'title' match the text in textbox
                    St.Add(temp);

            }
            return St;  //return in type list<model>
        }

        public bool searchAllField(Account account, String searchName) //if return false mean not found
        {
            Type type = account.GetType();
            PropertyInfo[] properties = type.GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                //if (fields["CategoryID"] == row[i] || row["AuthorID"] == row[i] || row["PublisherID"] == row[i]) continue;
                if (Convert.ToString(properties[i].GetValue(account)).ToLower().Contains(searchName.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        public Account getAccountByID(int ID)
        {
            DataTable temp = DB_Helper.Instance.GetRecord("SELECT * FROM Account WHERE UserID = " + ID);
            Account ac = new Account();
            foreach (DataRow i in temp.Rows)
            {
                ac = GetDBAccount(i);
            }
            return ac;
        }

        public String GetAccountName(int AccountID) //get Account name by id (used for other table to reference to)
        {
            String Name = "";
            foreach (DataRow i in Account_DAL.Instance.Get_AccountInfor().Rows)
            {
                if (Convert.ToInt32(i["UserID"]) == AccountID)
                {
                    Name = Convert.ToString(i["UserName"]);
                    break;
                }

            }
            return Name;
        }

        public String GetRoleName(int AccountID)
        {
            int RoleID = 0;
            String RoleName = "";
            foreach (DataRow i in Account_DAL.Instance.Get_AccountInfor().Rows)
            {
                if (Convert.ToInt32(i["UserID"]) == AccountID)
                {
                    RoleID = Convert.ToInt32(i["RoleID"]);
                    RoleName = Role_BLL.Instance.GetRoleName(RoleID);
                    break;
                }

            }
            return RoleName;
        }

        public void UpdateAccount(Account account)
        {
            Account_DAL.Instance.UpdateAccount_DAL(account);
        }
        public void AddAccount_BLL(Account account)
        {
            Account_DAL.Instance.AddAccount_DAL(account);
        }

        public void DeleteAccount_BLL(List<int> listAccountID)
        {
            foreach (int i in listAccountID)
            {
                Account_DAL.Instance.DeleteAccount_DAL(i);
            }
        }
        public void BlockAccount_BLL(int UserID)
        {
            Account_DAL.Instance.BlockAccount_DAL(UserID);
        }
        public void UnlockAccount_BLL(int UserID)
        {
            Account_DAL.Instance.UnLockAccount_DAL(UserID);
        }
        public int getNextAccountID_BLL()
        {
            return Account_DAL.Instance.getNextAccountID();
        }
    }
}

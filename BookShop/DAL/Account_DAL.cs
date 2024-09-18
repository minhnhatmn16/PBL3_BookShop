using BookShop.DAL_ST;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.DTO;

namespace BookShop.DAL
{
    internal class Account_DAL
    {
        SqlDataAdapter da, da_;
        Connect dc;
        private static Account_DAL _Instance;
        public static Account_DAL Instance
        {
            get
            {
                if (_Instance == null) _Instance = new Account_DAL();
                return _Instance;
            }
            private set
            {

            }
        }

        public Account_DAL()
        {
            dc = new Connect();
        }
        public DataTable getAllAccount_DAL()
        {
            return DB_Helper.Instance.GetRecord("SELECT * FROM Account");
        }

        public DataTable getAccountByID(int ID)
        {
            return DB_Helper.Instance.GetRecord("SELECT * FROM Account WHERE AccountID = " + ID);
        }

        public void AddAccount_DAL(Account Account)
        {
            string query_insertAccount = string.Format("INSERT INTO Account values ({0}, N'{1}', N'{2}', N'{3}', {4}, N'{5}', N'{6}', N'{7}', N'{8}')",
                Account.RoleID, Account.AccountName, Account.Password, Account.UserName, Account.SexID, Account.Birth.ToString(), Account.PhoneNumber, Account.Address, Account.Status);
            DB_Helper.Instance.ExecuteDB(query_insertAccount);
        }

        //Update Account
        public void UpdateAccount_DAL(Account account)
        {
            string query_updateAccount = string.Format("UPDATE Account SET AccountName = N'{0}', Password = N'{1}', UserName = N'{2}'," +
                " PhoneNumber = N'{3}', Address = N'{4}', Status = N'{5}' where UserID = {6}",
                account.AccountName, account.Password, account.UserName, account.PhoneNumber, account.Address, account.Status, account.UserID);
            DB_Helper.Instance.ExecuteDB(query_updateAccount);
        }

        //Delete Account by key (AccountID)
        public void DeleteAccount_DAL(int UserID)
        {
            string queryDel_Account = "DELETE FROM Account WHERE UserID = " + UserID;
            DB_Helper.Instance.ExecuteDB(queryDel_Account);
        }

        public void BlockAccount_DAL(int UserID)
        {
            string queryDel_Account = string.Format("UPDATE Account SET Status = N'{0}' WHERE UserID = {1}", StatusAccount.status[1], UserID);
            DB_Helper.Instance.ExecuteDB(queryDel_Account);
        }

        public void UnLockAccount_DAL(int UserID)
        {
            string queryDel_Account = string.Format("UPDATE Account SET Status = N'{0}' WHERE UserID = {1}", StatusAccount.status[0], UserID);
            DB_Helper.Instance.ExecuteDB(queryDel_Account);
        }

        public int getNextAccountID()
        {
            string query = "SELECT IDENT_CURRENT('Account') + IDENT_INCR('Account') AS NextID";

            int AccountID = -1;
            foreach (DataRow i in DB_Helper.Instance.GetRecord(query).Rows)
            {
                AccountID = Convert.ToInt32(i[0]);
            }
            return AccountID;
        }

        public DataTable Get_AccountInfor()
        {
            String SQL = "SELECT * from dbo.Account";
            SqlConnection Con = dc.getConnect();
            da_ = new SqlDataAdapter(SQL, Con);
            Con.Open();
            DataTable TB_Staff = new DataTable();
            da_.Fill(TB_Staff);
            Con.Close();
            return TB_Staff;
        }
    }
}

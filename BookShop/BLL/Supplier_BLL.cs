using BookShop.DAL;
using BookShop.DAL_ST;
using BookShop.DTO;
using BookShop.DTO_ST;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BLL_ST
{
    internal class Supplier_BLL
    {
        private static Supplier_BLL _Instance;
        public static Supplier_BLL Instance
        {
            get
            {
                if (_Instance == null) _Instance = new Supplier_BLL();
                return _Instance;
            }
            private set
            {

            }
        }

        //getBook B1. transfer each row in datarow to actual model
        public Supplier GetDBSupplier(DataRow Supplier)
        {
            Supplier St = new Supplier();
            St.SupplierID = Convert.ToInt32(Supplier["SupplierID"]);
            St.SupplierName = Convert.ToString(Supplier["SupplierName"]);
            St.PhoneNumber = Convert.ToString(Supplier["PhoneNumber"]);
            St.Address = Convert.ToString(Supplier["Address"]);

            return St;
        }

        //getSupplier B2. transfer model to a gridview
        public List<Supplier> GetSupplierInfor(string Name)
        {
            List<Supplier> St = new List<Supplier>();

            foreach (DataRow i in Supplier_DAL.Instance.Get_SupplierInfor().Rows)
            {
                if (Name == "") St.Add(GetDBSupplier(i)); //get all Suppliers
                else if ((Convert.ToString(i["SupplierName"])).Contains(Name)) //get Suppliers that have 'title' match the text in textbox
                    St.Add(GetDBSupplier(i));

            }
            return St;  //return in type list<model>
        }

        public String GetSupplierName(int SupplierID) //get Supplier name by id (used for other table to reference to)
        {
            String Name = "";
            foreach (DataRow i in Supplier_DAL.Instance.Get_SupplierInfor().Rows)
            {
                if (Convert.ToInt32(i["SupplierID"]) == SupplierID)
                {
                    Name = Convert.ToString(i["SupplierName"]);
                    break;
                }

            }
            return Name;  //return in type list<model>
        }
        public Supplier getSupplierByID_BLL(int SupplierID)
        {
            Supplier temp = new Supplier();
            foreach (DataRow i in Supplier_DAL.Instance.getSupplierByID(SupplierID).Rows)
            {
                temp = GetDBSupplier(i);
            }
            return temp;
        }
        public int getNextSupplierID_BLL()
        {
            return Supplier_DAL.Instance.getNextSupplierID();
        }
        public void AddSupplier_BLL(Supplier supplier)
        {
            Supplier_DAL.Instance.AddSupplier_DAL(supplier);
        }
        public void UpdateSupplier_BLL(Supplier supplier)
        {
            Supplier_DAL.Instance.UpdateSupplier_DAL(supplier);
        }
        public void DeleteSupplier_BLL(int supplierID)
        {
            Supplier_DAL.Instance.DeleteSupplier_DAL(supplierID);
        }
    }
}

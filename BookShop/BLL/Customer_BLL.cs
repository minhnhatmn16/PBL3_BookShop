using BookShop.BLL_ST;
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

namespace BookShop.BLL
{
    internal class Customer_BLL
    {
        private static Customer_BLL _Instance;
        public static Customer_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Customer_BLL();
                }
                return _Instance;
            }
            private set { }
        }
        private Customer_BLL()
        {
        }
        //getBook B1. transfer each row in datarow to actual model
        public Customer GetDBCustomer(DataRow Customer)
        {
            Customer St = new Customer();
            St.CustomerID = Convert.ToInt32(Customer["CustomerID"]);
            St.CustomerName = Convert.ToString(Customer["CustomerName"]);
            St.SexID = Convert.ToInt32(Customer["GenderID"]);
            St.PhoneNumber = Convert.ToString(Customer["PhoneNumber"]);

            return St;
        }

        //getCustomer B2. transfer model to a gridview
        public List<Customer> GetCustomerInfor(string Name)
        {
            List<Customer> St = new List<Customer>();

            foreach (DataRow i in Customer_DAL.Instance.getAllCustomer_DAL().Rows)
            {
                Customer temp = new Customer();
                temp = GetDBCustomer(i);
                if (Name == "") St.Add(temp); //get all Customers
                else if (searchAllField(temp, Name)) //get Customers that have 'title' match the text in textbox
                    St.Add(GetDBCustomer(i));

            }
            return St;  //return in type list<model>
        }
        public bool searchAllField(Customer customer, String searchName) //if return false mean not found
        {
            Type type = customer.GetType();
            PropertyInfo[] properties = type.GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                //if (fields["CategoryID"] == row[i] || row["AuthorID"] == row[i] || row["PublisherID"] == row[i]) continue;
                if (Convert.ToString(properties[i].GetValue(customer)).ToLower().Contains(searchName.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }
        public Customer getCustomerByID_BLL(int CustomerID)
        {
            Customer temp = new Customer();
            foreach (DataRow i in Customer_DAL.Instance.getCustomerByID(CustomerID).Rows)
            {
                temp = GetDBCustomer(i);
            }
            return temp;
        }

        public void AddCustomer_BLL(Customer Customer)
        {
            Customer_DAL.Instance.AddCustomer_DAL(Customer);
        }
        public void UpdateCustomer_BLL(Customer Customer)
        {
            Customer_DAL.Instance.UpdateCustomer_DAL(Customer);
        }

        public int getNextCustomerID_BLL()
        {
            return Customer_DAL.Instance.getNextCustomerID();
        }
        public int getNumberOfBookCustomer_BLL(int CustomerID)
        {
            return Customer_DAL.Instance.getNumberOfBookCustomer(CustomerID);
        }
        public Double getTotalPaymentCustomer_BLL(int CustomerID)
        {
            return Customer_DAL.Instance.getTotalPaymentCustomer(CustomerID);
        }
    }
}

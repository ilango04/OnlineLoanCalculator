using System;
using OnlineLoanCalculator;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLoanCalculator
{
    public class Customer
    {
        public string name { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string emailID { get; set; }
        public string employmentType { get; set; }
        public long monthlySalary { get; set; }
        public string company { get; set; }
        public string address { get; set; }
        public long pincode { get; set; }
        public long mobileNumber { get; set; }
        public string password { get; set; }
        public Customer(string name,DateTime dateOfBirth,string emailID,string employmentType,long monthlySalary,string company,string address,long pincode,long mobileNumber,string password)
        {
            this.name = name;
            this.dateOfBirth = dateOfBirth;
            this.emailID = emailID;
            this.employmentType = employmentType;
            this.monthlySalary = monthlySalary;
            this.company = company;
            this.address = address;
            this.pincode = pincode;
            this.mobileNumber = mobileNumber;
            this.password = password;
        }
    }
}                     

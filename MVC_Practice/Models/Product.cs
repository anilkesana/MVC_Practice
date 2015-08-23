using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_Practice.Models
{
    public class Product
    {

        public string Prodcode { get; set; }
        public string ProdName { get; set; }
        public int ProdQty { get; set; }
    }

    public class Employee
    {
       
        public int EmployeeId { set; get; }
        public string EmployeeName { set; get; }
        public string EmployeeGender { set; get; }
        public int DepartmentId { set; get; }
        

    }
    public class Department
    {
        public int DepartmentId { set; get; }
        public string DepartmentName { set; get; }
    }

}
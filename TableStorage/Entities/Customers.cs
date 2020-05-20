using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
//namespace TableDemo.Entities

namespace TableStorageAcct.Entities
{

    class Customer : TableEntity
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerType { get; set; }

        public Customer()
        {

        }
        public Customer(string name, string email, string type)
        {
            this.CustomerName = name;
            this.CustomerEmail = email;
            this.CustomerType = type;
            this.PartitionKey = type;
            this.RowKey = email;
        }
    }



}

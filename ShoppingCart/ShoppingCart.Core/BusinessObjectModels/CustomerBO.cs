using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Core.BusinessObjectModels
{
    public class CustomerBO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
    }
}

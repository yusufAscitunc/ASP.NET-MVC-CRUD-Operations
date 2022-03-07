using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcEF_CodeFirst.Models
{
    public class ViewModel
    {
        public List<Person> People { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
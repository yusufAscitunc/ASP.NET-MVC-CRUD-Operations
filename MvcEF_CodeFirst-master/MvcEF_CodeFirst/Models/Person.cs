using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcEF_CodeFirst.Models
{
    [Table ("People")]
    public class Person
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(20), Required]
        public string Name { get; set; }

        [StringLength(20), Required]
        public string Surname { get; set; }

        [Required]
        public int Age { get; set; }
        public virtual List<Address> Addresses { get; set; }
    }
}
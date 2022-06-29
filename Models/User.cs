using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_PRODUCT_APP.Models
{
    public class User
    {
        [Key]
        [ScaffoldColumn(false)]

        public int Id { get; set; }
        public string Full_Name { get; set; }
        public string Email_Id { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}

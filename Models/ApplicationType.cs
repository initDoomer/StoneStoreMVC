using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoneStoreMVC.Models
{
    public class ApplicationType
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
    }
}

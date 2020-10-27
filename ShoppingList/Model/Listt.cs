using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Model
{
    public class Listt
    {
        [Key]
        public int Id { get; set; }

        public string Category { get; set; }

        public string Quantity { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilApp.Entities
{
    public class Products
    {
        [Key]
        public int ProductId {  get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; } 
        public string Code { get; set; }
        public int Kdv { get; set; }
        public bool IsActive { get; set; }
    }
}

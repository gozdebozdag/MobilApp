﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilApp.Entities
{
    public class Groups
    {
        [Key]
        public int GroupId { get; set; }
        public string GroupName {  get; set; }
    }
}

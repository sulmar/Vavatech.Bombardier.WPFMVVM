﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombardier.WPF.Models
{
    public class Network : Base
    {

        public string Name { get; set; }

        public List<Item> Items { get; set; }
    }
}

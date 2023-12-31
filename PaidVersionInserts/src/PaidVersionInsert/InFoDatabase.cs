﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaidVersionInsert
{
    class InFoDatabase
    {
        public string ServerName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Choice { get; set; }

        public override string ToString()
        {
            return $"{ServerName}\t@\t{Login}\t@\t{Password}\t@\t{Choice}\n";
        }
    }
}

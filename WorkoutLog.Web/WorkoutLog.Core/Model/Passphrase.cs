﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkoutLog.Core.Model
{
    public class Passphrase
    {
        public string Hash { get; set; }
        public string Salt { get; set; }
    }
}

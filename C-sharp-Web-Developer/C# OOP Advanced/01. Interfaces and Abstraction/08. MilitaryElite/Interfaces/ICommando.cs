﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.MilitaryElite.Interfaces
{
    public interface ICommando
    {
        List<Mission> Missions { get; set; }
    }
}

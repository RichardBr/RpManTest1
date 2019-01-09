using System;
using System.Collections.Generic;
using System.Text;
using RpMan.Common;

namespace RpMan.Infrastructure
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public int CurrentYear => DateTime.Now.Year;
    }
}

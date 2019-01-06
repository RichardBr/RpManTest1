using System;
using System.Collections.Generic;
using System.Text;

namespace RpMan.Domain.Entities
{
    class Tenant
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Middlenames { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}

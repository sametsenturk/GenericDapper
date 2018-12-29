using System;
using System.Collections.Generic;
using System.Text;

namespace GenericDapper.Data.Entities
{
    public class User:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}

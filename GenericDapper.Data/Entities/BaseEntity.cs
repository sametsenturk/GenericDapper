using System;
using System.Collections.Generic;
using System.Text;

namespace GenericDapper.Data.Entities
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public DateTime AddDate { get; set; }
    }
}

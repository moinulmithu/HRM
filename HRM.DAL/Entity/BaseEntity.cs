using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HRM.DAL.Entity
{
    [DataContract]
    public abstract class BaseEntity
    {
        [DataMember]
        public int ID { get; set; }
    }
}

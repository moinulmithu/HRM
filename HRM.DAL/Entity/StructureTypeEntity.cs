using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRM.DAL.Entity
{
    public class StructureTypeEntity : BaseEntity
    {
      
        public string StructureName { get; set; }
        public int SortOrder { get; set; }
        public decimal Basic { get; set; }
        public decimal IncrBase { get; set; }
        public Int32 MaxIncr { get; set; }
        public decimal EBIncrBase { get; set; }
        public Int32 EBMaxIncr { get; set; }
        public Int32 PositionTypeId { get; set; }
        public string PositionType { get; set; }
        public decimal ActualPrvBasic { get; set; }
        public decimal MedicalAllowance { get; set; }
        public string PayScale2009 { get; set; }
    }
}

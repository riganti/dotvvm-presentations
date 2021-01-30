using System;
using System.Collections.Generic;

namespace CrudDemo.Data.Data
{
    public partial class EmployeesTerritories
    {
        public long EmployeeId { get; set; }
        public long TerritoryId { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual Territories Territory { get; set; }
    }
}

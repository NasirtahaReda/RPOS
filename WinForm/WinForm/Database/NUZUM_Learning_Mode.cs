//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RedaPOS.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class NUZUM_Learning_Mode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NUZUM_Learning_Mode()
        {
            this.NUZUM_Trainee = new HashSet<NUZUM_Trainee>();
        }
    
        public int id { get; set; }
        public string Learning_mode { get; set; }
        public Nullable<bool> Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NUZUM_Trainee> NUZUM_Trainee { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kunja.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class lodgetype
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public lodgetype()
        {
            this.lodge = new HashSet<lodge>();
        }
    
        public int lodgeTypeID { get; set; }
        public string lodgeTypeNaam { get; set; }
        public string lodgeTypeOmschrijving { get; set; }
        public int aantalpersonen { get; set; }
        public decimal prijs { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<lodge> lodge { get; set; }
    }
}

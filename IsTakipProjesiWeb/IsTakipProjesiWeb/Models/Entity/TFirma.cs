//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IsTakipProjesiWeb.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TFirma
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TFirma()
        {
            this.TCagri = new HashSet<TCagri>();
        }
    
        public byte ID { get; set; }
        public string Firma { get; set; }
        public string Yetkili { get; set; }
        public string Telefon { get; set; }
        public string Sifre { get; set; }
        public string Mail { get; set; }
        public string Sektor { get; set; }
        public string Il { get; set; }
        public string Adres { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TCagri> TCagri { get; set; }
    }
}

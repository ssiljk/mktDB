//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mktDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class mkCliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mkCliente()
        {
            this.mkContacto = new HashSet<mkContacto>();
        }
    
        public int mkClienteId { get; set; }
        public Nullable<int> mkCliCategoriaId { get; set; }
        public string isActive { get; set; }
        public string Rut { get; set; }
        public string RazonSocial { get; set; }
        public string Giro { get; set; }
        public string Email { get; set; }
        public string LegDir { get; set; }
        public string LegDirComCod { get; set; }
        public string LegDirCiuCod { get; set; }
        public string LegDirPaiCod { get; set; }
        public string LegDirProCod { get; set; }
        public Nullable<int> LegDirRegCod { get; set; }
        public Nullable<int> LegDirPosCod { get; set; }
        public string Fon1 { get; set; }
        public string Fantasia { get; set; }
        public string Rubro { get; set; }
        public string Vendedor { get; set; }
        public string Comentario { get; set; }
        public string PaginaWeb { get; set; }
        public string EntDir { get; set; }
        public string EntDirComCod { get; set; }
        public string EntDirCiuCod { get; set; }
        public string EntDirPaiCod { get; set; }
        public string EntDirProCod { get; set; }
        public Nullable<int> EntDirRegCod { get; set; }
        public Nullable<int> EntDirPosCod { get; set; }
        public string CorDir { get; set; }
        public string CorDirComCod { get; set; }
        public string CorDirCiuCod { get; set; }
        public string CorDirPaiCod { get; set; }
        public string CorDirProCod { get; set; }
        public Nullable<int> CorDirRegCod { get; set; }
        public Nullable<int> CorDirPosCod { get; set; }
    
        public virtual mkCliCategoria mkCliCategoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mkContacto> mkContacto { get; set; }
    }
}
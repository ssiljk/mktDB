﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class mkContext : DbContext
    {
        public mkContext()
            : base("name=mkContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<mkCliCargo> mkCliCargo { get; set; }
        public virtual DbSet<mkCliCategoria> mkCliCategoria { get; set; }
        public virtual DbSet<mkCliente> mkCliente { get; set; }
        public virtual DbSet<mkContacto> mkContacto { get; set; }
        public virtual DbSet<mkMarca> mkMarca { get; set; }
        public virtual DbSet<mkMarketingMarca> mkMarketingMarca { get; set; }
        public virtual DbSet<mkMarketingSol> mkMarketingSol { get; set; }
        public virtual DbSet<mkSolucion> mkSolucion { get; set; }
        public virtual DbSet<mkUser> mkUser { get; set; }
    }
}

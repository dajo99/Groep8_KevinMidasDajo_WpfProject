﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Artmin_DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ArtminEntities : DbContext
    {
        public ArtminEntities()
            : base("name=ArtminEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Artist> Artiest { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventType> Eventtype { get; set; }
        public virtual DbSet<Client> Klant { get; set; }
        public virtual DbSet<Location> Locatie { get; set; }
        public virtual DbSet<Note> Notitie { get; set; }
        public virtual DbSet<ToDo> ToDo { get; set; }
    }
}

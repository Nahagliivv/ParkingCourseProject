﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ParkingCourseProject.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ParkingDBEntities : DbContext
    {
        public ParkingDBEntities()
            : base("name=ParkingDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<OWNER> OWNER { get; set; }
        public virtual DbSet<PASS> PASS { get; set; }
        public virtual DbSet<PLACE> PLACE { get; set; }
        public virtual DbSet<VEHICLE> VEHICLE { get; set; }
    }
}
﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RemontApp.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class remontEntities : DbContext
    {
        private static remontEntities _context;
        public remontEntities()
            : base("name=remontEntities")
        {
        }

        public static remontEntities GetContext()
        {
            if( _context == null)
            {
                _context = new remontEntities();
            }
            return _context;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<order_services> order_services { get; set; }
        public virtual DbSet<orders> orders { get; set; }
        public virtual DbSet<roles> roles { get; set; }
        public virtual DbSet<services> services { get; set; }
        public virtual DbSet<users> users { get; set; }
    }
}

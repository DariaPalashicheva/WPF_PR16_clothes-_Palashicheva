//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPF_PR16_clothes__Palashicheva.ApplicationData
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ClothesEntities : DbContext
    {

        public static ClothesEntities _context;

        public static ClothesEntities GetContext()
        {
            if (_context == null)
                _context = new ClothesEntities();
            return _context;
        }

        public ClothesEntities()
            : base("name=ClothesEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Tovars> Tovars { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<Strana> Strana { get; set; }
    }
}

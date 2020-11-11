using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using MySql.Data.MySqlClient;
using MySql.Data.EntityFramework;

namespace ServiceHoster
{
    [Table("products")]
    public class Product
    {
        [Key]
        public int ID { get; set; }

        [Required, Column("description"), MinLength(3), MaxLength(50)]
        public string name { get; set; }

        [MaxLength(150)]
        public string description { get; set; }

        [Required]
        public decimal price { get; set; }

        [ForeignKey("category")]
        public ProductCategory category;
    }

    [Table("productsCategories")]
    public class ProductCategory
    {
        [Key]
        public int ID { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string name { get; set; }

        [MaxLength(150)]
        public string description { get; set; }
    }

    [DbConfigurationType(typeof(MySqlEFConfiguration))]   // use MySql config
    public class ProductsDBCtx : DbContext
    {
        public ProductsDBCtx() : base("server=localhost; User Id=root; Persist Security Info=True; database=ProductDB; password=moh123") // use connection string here
        {
            // check the DB existance
            if (!this.Database.Exists())
                this.Database.Create();
        }


        public virtual DbSet<Product> products { get; set; }
        public virtual DbSet<ProductCategory> productCategories { get; set; }

    }
}

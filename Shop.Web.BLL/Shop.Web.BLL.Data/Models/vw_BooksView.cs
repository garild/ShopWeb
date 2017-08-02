namespace Shop.Web.BLL.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vw_BooksView
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(500)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime DateRelease { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal Price { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(500)]
        public string Author { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(500)]
        public string Publisher { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookType_Id { get; set; }

        public int? NewsType_Id { get; set; }
    }
}

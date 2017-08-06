namespace Shop.Web.BLL.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateRelease { get; set; }

        public decimal Price { get; set; }

        [Required]
        [StringLength(500)]
        public string Author { get; set; }

        [Required]
        [StringLength(500)]
        public string Publisher { get; set; }

        public int? BookType_Id { get; set; }

        public bool IsSuperPromtion { get; set; }

        public virtual Books_D_BookType Books_D_BookType { get; set; }
        
    }
}

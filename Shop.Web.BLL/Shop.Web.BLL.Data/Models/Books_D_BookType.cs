namespace Shop.Web.BLL.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

 
    public partial class Books_D_BookType
    {
      
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
      
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
      
        [StringLength(500)]
        public string Description { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}

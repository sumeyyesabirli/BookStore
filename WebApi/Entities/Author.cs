using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]     
        public int Id { get; set; }
        public string Name { get; set; }
        public string lastName { get; set; }
        public DateTime Birth { get; set; }
        public Book Book { get ; set; }
        public int BookId { get; set; }

    }
}

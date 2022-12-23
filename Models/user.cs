using System.ComponentModel.DataAnnotations;

namespace crudapi.Models
{
    public class user
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}

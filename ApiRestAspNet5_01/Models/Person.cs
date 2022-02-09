using ApiRestAspNet5_01.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace ApiRestAspNet5_01.Model
{
    public class Person : BaseEntity
    {
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string Gender { get; set; }
        public bool Enable { get; set; } = true;
    }
}

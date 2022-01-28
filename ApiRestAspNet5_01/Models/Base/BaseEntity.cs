using System.ComponentModel.DataAnnotations;

namespace ApiRestAspNet5_01.Models.Base
{
    public class BaseEntity
    {
        [Required]
        public long Id { get; set; }
    }
}

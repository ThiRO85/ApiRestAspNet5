using System;
using System.ComponentModel.DataAnnotations;

namespace ApiRestAspNet5_01.Models
{
    public class User
    {
        public long Id { get; set; }

        [MaxLength(50)]
        public string UserName { get; set; }

        [MaxLength(50)]
        public string FullName { get; set; }

        [MaxLength(150)]
        public string Password { get; set; }

        [MaxLength(50)]
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace ApiRestAspNet5_01.Data.VO
{
    public class PersonVO
    {
        //[JsonPropertyName("testId")]
        public long Id { get; set; }

        //[JsonPropertyName("testFirtName")]
        public string FirstName { get; set; }

        //[JsonPropertyName("testLastName")]
        public string LastName { get; set; }

        //[JsonIgnore]
        public string Address { get; set; }

        //[JsonPropertyName("testGender")]
        public string Gender { get; set; }
    }
}

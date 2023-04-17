using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ASP.NET.NovaPasta
{
    public class TeamModel
    {
        [Key]
        public int Id { get; internal set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? sector { get; set; }

        [JsonIgnore]
        [NotMapped]
        public ICollection<EmployeeModel>? Employee { get; set;}

    }
}

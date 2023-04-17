using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ASP.NET.NovaPasta
{
    public class EmployeeModel
    {
        [Key]
        public int Id { get; internal set; }

        [Required]
        public string? name { get; set; }

        [Required]
        public string? position { get; set; }

        public string? email { get; set; }



        [Required]
        [ForeignKey("Reference to the team")]
        public int? TeamReference{ get; set; }

        [JsonIgnore]
        [NotMapped]
        public TeamModel? Team { get; set; } 
        
    }
}

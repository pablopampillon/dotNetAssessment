using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace dotnet_project_db.Models
{
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string? brand { get; set; }
        public string? vin { get; set; }
        public string? color { get; set; }
        public string? year { get; set; }

        [ForeignKey("OwnerId")]
        public virtual Owner owner { get; set; }
    }
}
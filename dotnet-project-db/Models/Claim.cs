using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace dotnet_project_db.Models
{
    public class Claim
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string? description { get; set; }
        public string? status { get; set; }
        public string? date { get; set; }

        [ForeignKey("vehicleId")]
        public virtual Vehicle vehicle { get; set; }
    }
}

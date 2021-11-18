using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLiteWebApi.Entities
{
    public class MountainbikeTour
    {
        [Key]
        [Column("TourId")]
        public int TourId { get; set; }
        public string TourName { get; set; }
        public float TourLength { get; set; }
        public string TourLocation { get; set; }

    }
}

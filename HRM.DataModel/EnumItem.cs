using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM.DataModel
{
    [Table("LookupList")] 
    public class EnumItem
    {
        [Required]
        public int Id;

        [Required]
        public string Word;

        [Required]
        [Key]
        public string Type;
    }
}

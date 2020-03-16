
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFIAPITest.Models
{
    public class Registration
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [StringLength(RegistrationConstants.MaxLength_Firstname)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(RegistrationConstants.MaxLength_Surname)]
        public string Surname { get; set; }

        [Required]
        [StringLength(9)]
        public string PolicyReference { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }

        [StringLength(RegistrationConstants.MaxLength_Email)]
        public string Email { get; set; }

    }
}

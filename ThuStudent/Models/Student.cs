using System.ComponentModel.DataAnnotations;

namespace ThuStudent.Models
{
    public class Student
    {
        [Required]
        public virtual int Id { get; set; }

        [Required]
        [StringLength(100)]
        public virtual string Name { get; set; }

        [RegularExpression("^(.+)@(.+)$", ErrorMessage ="Invalid email format.")]
        public virtual string? Email { get; set; }

        //public virtual DateTime BirthDate { get; set; }
        //[RegularExpression("/(?([0-9]{3}))?([ .-]?)([0-9]{3})2([0-9]{4})/", ErrorMessage = "Invalid phone number format.")]
        [StringLength(10)]
        public virtual string? Phone { get; set; }
    }
}

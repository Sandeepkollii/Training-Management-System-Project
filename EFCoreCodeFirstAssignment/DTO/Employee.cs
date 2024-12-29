using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class Employee
    {
        public int Id { get; set; }
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name should contain only alphabets")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Name should contain minimum 5 characters and maximum of 50 characters")]
        public string Name { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Enter valid date")]
        [CustomValidation(typeof(Employee), nameof(ValidateYearOfBirth))]
        public DateTime? DoB { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Enter valid date")]
        [CustomValidation(typeof(Employee), nameof(ValidateDateOfJoining))]
        public DateTime? DoJ { get; set; }
        [Range(12000, 60000, ErrorMessage = "Salary should in between 12000 and 60000")]
        public double? Salary { get; set; }
        [RegularExpression(@"(^HR|Accts|IT)$", ErrorMessage = "Department can be any of the HR, Accts or IT")]
        public string? Department { get; set; }

        [DataType(DataType.Password)]
        [RegularExpression(@"[A-Za-z\d\W_]{8,}$", ErrorMessage = "Password should be atleast 8 characters length")]
        public string? Password { get; set; }



        // Custom validation for DateOfBirth

        //ValidationAttribute class contains ValidationResult return type method. If we inherit, this method will overrided.
        public static ValidationResult ValidateYearOfBirth(DateTime dateOfBirth)
        {
            if (dateOfBirth.Year < 2002 || dateOfBirth.Year > 2005)
            {
                return new ValidationResult("Year of Birth must be between 2002 and 2005");
            }
            return ValidationResult.Success;
        }

        // Custom validation for DateOfJoining
        public static ValidationResult ValidateDateOfJoining(DateTime dateOfJoining)
        {
            if (dateOfJoining > DateTime.Now)
            {
                return new ValidationResult("Date of Joining must be less than or equal to the current date.");
            }
            return ValidationResult.Success;
        }


    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace form_validation_1.Models
{
    public class Registration
    {



        [Required(ErrorMessage = "*Provide you name")]

        [StringLength(50,MinimumLength=4,ErrorMessage ="lenght should be between 4 to 50")]
        [RegularExpression("^[a-zA-Z0-9 .-]*$",ErrorMessage ="Name should not contain special char")]
        public string name {  get; set; }










        [Required(ErrorMessage = "*Provide you userID")]
        [StringLength(12, MinimumLength = 4, ErrorMessage = "lenght should be between 4 to 12 char")]
        [RegularExpression("^[a-zA-Z0-9_-]*$", ErrorMessage = "UserID should not contain special char")]
        public string userid {  get; set; }








        [Required(ErrorMessage = "*Provide you Password")]
        [StringLength(60, MinimumLength = 8, ErrorMessage = "lenght should be min 8")]
        [RegularExpression("^(?=(?:[^A-Z]*[A-Z]){1})(?=(?:[^a-z]*[a-z]){2})[A-Za-z]{4}(?=.*[0-9!@#$%^&*])[0-9!@#$%^&*]+", ErrorMessage = "password should not contain 1 upper char at least 2 lowercase char")]

        // [Pasdword(ErrorMessage ="no correct format")]
        public string password {  get; set; }








        [Required(ErrorMessage = "*Provide you id")]
        [RegularExpression("^\\d{2}-\\d{5}-\\d$", ErrorMessage = "ID must be in XX-XXXX-X format")]
        public string id {  get; set; }








        [Required(ErrorMessage = "*Provide you email")]

        [RegularExpression("^\\d{2}-\\d{5}-\\d@student.aiub.edu$", ErrorMessage = "email format no correct")]
        public string email { get; set; }



        [Required(ErrorMessage ="*Select date")]
        [Date(ErrorMessage = "Your age is < 18")]
        public DateTime date { get; set; }





    }
}
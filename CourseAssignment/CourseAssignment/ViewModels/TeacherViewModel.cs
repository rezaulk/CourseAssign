using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseAssignment.ViewModels
{
    public class TeacherViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Must enter a Name")]
        [Display(Name = "Enter Full Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Must enter Date")]
        [Display(Name = "Enter Joining Date")]
        public DateTime JoiningDate { get; set; }

        [Required(ErrorMessage = "Must enter an Email")]
        [EmailAddress]
        [Display(Name = "Enter Email")]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@wub.edu.bd", ErrorMessage = "Must be a Valid User of World University")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Must enter an Id")]
        [Display(Name = "Enter Teachers Short Name")]
        public string TeacherShortName { get; set; }

        [Required(ErrorMessage = "Must enter a Mobile Number")]
        [Display(Name = "Enter MobileNo")]
        public string MobileNo { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "enter Minimum 6 digit with at least a Uppercase, a LowerCase, a Number and a Special Character", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
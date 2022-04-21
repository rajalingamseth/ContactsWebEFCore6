using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactWebModels
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="First Name")]
        [Required(ErrorMessage ="First name is required")]
        [StringLength(ContactsManagerConstants.MAX_FIRST_NAME_LENGTH)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required, StringLength(ContactsManagerConstants.MAX_LAST_NAME_LENGTH)]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [StringLength(ContactsManagerConstants.MAX_EMAIL_LENGTH)]
        [EmailAddress(ErrorMessage ="Invalid Email address")]
        public string Email { get; set; }

        [Display(Name = "Mobile Phone")]
        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(ContactsManagerConstants.MAX_PHONE_LENGTH)]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhonePrimary { get; set; }

        [Display(Name = "Home/Office Phone")]
        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(ContactsManagerConstants.MAX_PHONE_LENGTH)]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneSecondary { get; set; }

        [Display(Name ="Address line 1")]
        [StringLength(ContactsManagerConstants.MAX_STREET_ADDRESS_LENGTH)]
        public string StreetAddress1 { get; set; }

        [Display(Name = "Address line 2"), StringLength(ContactsManagerConstants.MAX_STREET_ADDRESS_LENGTH)]
        public string StreetAddress2 { get; set; }

        [Display (Name ="City"), StringLength(ContactsManagerConstants.MAX_CITY_LENGTH)]
        public string City { get; set; }

        public int StateId { get; set; }

        [Required, StringLength(ContactsManagerConstants.MAX_ZIP_LENGTH, MinimumLength = ContactsManagerConstants.MIN_ZIP_LENGTH)]
        [Display(Name ="Zip Code")]
        public string Zip { get; set; }
        public virtual State State { get; set; }

        [Required(ErrorMessage ="The user id is required to map user correctly")]
        public string UserId { get; set; }
        public string FriendlyName => $"{FirstName}{LastName}";
        public string FriendlyAddress => State is null ? "" : string.IsNullOrWhiteSpace(StreetAddress1) ? $"{City}, {State.Abbreviation},{Zip}" :
                                    string.IsNullOrWhiteSpace(StreetAddress2) ? $"{StreetAddress1},{City},{State.Abbreviation}, {Zip} "
                                    : $"{StreetAddress1} - {StreetAddress2}, {City}, {State.Abbreviation}, {Zip}";

    }
}

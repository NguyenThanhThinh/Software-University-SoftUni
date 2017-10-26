namespace _09.Hospital_Database.Models
{
    using System.Collections.Generic;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Patient
    {
        private string lastName;
        private string address;
        private string email;
        private DateTime dateOfBirth;
        private byte[] picture;
        private bool medicalInsurance;
        private ICollection<string> medicaments;
        private ICollection<Diagnose> diagnoses;
        private ICollection<Visitation> visitations;

        public Patient()
        {
            this.DateOfBirth = new DateTime();
            this.Medicaments = new List<string>();
            this.Diagnoses = new List<Diagnose>();
            this.Visitations = new List<Visitation>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2), MaxLength(20)]
        public string FirstName { get; set; }

        [MinLength(2), MaxLength(20)]
        public string LastName
        {
            get => this.lastName;
            set => this.lastName = value;
        }

        public string Address
        {
            get => this.address;
            set => this.address = value;
        }

        public string Email
        {
            get => this.email;
            set => this.email = value;
        }

        public DateTime DateOfBirth
        {
            get => this.dateOfBirth;
            set => this.dateOfBirth = value;
        }

        public byte[] Picture
        {
            get => this.picture;
            set => this.picture = value;
        }

        public bool MedicalInsurance
        {
            get => this.medicalInsurance;
            set => this.medicalInsurance = value;
        }

        public virtual ICollection<string> Medicaments
        {
            get => this.medicaments;
            set => this.medicaments = value;
        }

        public virtual ICollection<Diagnose> Diagnoses
        {
            get => this.diagnoses;
            set => this.diagnoses = value;
        }

        public virtual ICollection<Visitation> Visitations
        {
            get => this.visitations;
            set => this.visitations = value;
        }
    }
}
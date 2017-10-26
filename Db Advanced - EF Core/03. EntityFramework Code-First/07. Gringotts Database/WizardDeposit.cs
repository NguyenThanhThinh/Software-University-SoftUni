using System;
using System.ComponentModel.DataAnnotations;

namespace _07.Gringotts_Database
{
    public class WizardDeposit
    {
        private string firstName = string.Empty;
        private string lastName = string.Empty;
        private string notes = string.Empty;
        private string magicWandCreator = string.Empty;
        private string depositGroup = string.Empty;

        public WizardDeposit()
        {
        }

        public WizardDeposit(string lastName, uint age)
        {
            this.LastName = lastName;
            this.Age = age;
        }

        [Key]
        public int WizardDepositsId { get; set; }

        [StringLength(50)]
        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Firstname max length = 50");
                }
                this.firstName = value;
            }
        }

        [Required]
        [StringLength(60)]
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (value.Length > 60)
                {
                    throw new ArgumentException("LastName max length = 50");
                }
                this.lastName = value;
            }
        }

        [StringLength(1000)]
        public string Notes
        {
            get { return this.notes; }
            set
            {
                if (value.Length > 1000)
                {
                    throw new ArgumentException("Notes max length = 1000");
                }
                this.notes = value;
            }
        }

        [Required]
        public uint Age { get; set; }

        [StringLength(100)]
        public string MagicWandCreator
        {
            get { return this.magicWandCreator; }
            set
            {
                if (value.Length > 100)
                {
                    throw new ArgumentException("MagicWandCreator max length = 100");
                }
                this.magicWandCreator = value;
            }
        }

        public ushort MagicWandSize { get; set; }

        [StringLength(20)]
        public string DepositGroup
        {
            get { return this.depositGroup; }
            set
            {
                if (value.Length > 20)
                {
                    throw new ArgumentException("DepositGroup max lenght = 20");
                }
                this.depositGroup = value;
            }
        }

        public DateTime DepositStartDate { get; set; }

        public decimal DepositAmount { get; set; }

        public decimal DepositInterest { get; set; }

        public double DepositCharge { get; set; }

        public DateTime DepositExpirationDate { get; set; }

        public bool IsDepositExpired { get; set; }
    }
}
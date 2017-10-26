using _09.Hospital_Database.Models;

namespace _09.Hospital_Database
{
    using System.Data.Entity;

    public class HospitalContext : DbContext
    {
        public HospitalContext()
            : base("name=HospitalContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<HospitalContext>());
        }

        public virtual DbSet<Patient> Patients { get; set; }

        public virtual DbSet<Diagnose> Diagnoses { get; set; }

        public virtual DbSet<Visitation> Visitations { get; set; }
    }

}
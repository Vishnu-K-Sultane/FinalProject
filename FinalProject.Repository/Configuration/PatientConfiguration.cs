using FinalProject.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Repository.Configuration
{
    /// <summary>
    /// Configuration class for the Patient entity.
    /// </summary>
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasData(
                new Patient
                {
                    PatientId = new Guid("C513F843-93EA-4761-9113-3EB19B910122"),
                    AadharId = "123456789012",
                    FirstName = "Amit",
                    LastName = "Sharma",
                    MobileNumber = "9876543210",
                    Gender = "Male",
                    Disease = "Diabetes",
                    Symptoms = "Fatigue, frequent urination",
                    AdmissionDateTime = new DateTime(2025, 5, 20, 10, 30, 0),
                    InitialDeposit = 5000m,
                    roomId = 101
                },
                new Patient
                {
                    PatientId = Guid.Parse("96AB69CE-D9D9-4743-BBE9-E357D886FB9A"),
                    AadharId = "234567890123",
                    FirstName = "Neha",
                    LastName = "Verma",
                    MobileNumber = "9123456789",
                    Gender = "Female",
                    Disease = "Asthma",
                    Symptoms = "Shortness of breath, wheezing",
                    AdmissionDateTime = new DateTime(2025, 5, 21, 14, 15, 0),
                    InitialDeposit = 4000m,
                    roomId = 102
                },
                new Patient
                {
                    PatientId = Guid.Parse("75D56A79-8D58-456A-A3AB-57AA863BAC9E"),
                    AadharId = "345678901234",
                    FirstName = "Ravi",
                    LastName = "Kumar",
                    MobileNumber = "9012345678",
                    Gender = "Male",
                    Disease = "Hypertension",
                    Symptoms = "Headache, dizziness",
                    AdmissionDateTime = new DateTime(2025, 5, 22, 9, 0, 0),
                    InitialDeposit = 4500m,
                    roomId = 103
                },
                new Patient
                {
                    PatientId = Guid.Parse("549F3201-112C-4C33-B7D8-F1C320BA2EA6"),
                    AadharId = "456789012345",
                    FirstName = "Pooja",
                    LastName = "Singh",
                    MobileNumber = "9988776655",
                    Gender = "Female",
                    Disease = "Migraine",
                    Symptoms = "Severe headache, nausea",
                    AdmissionDateTime = new DateTime(2025, 5, 23, 11, 45, 0),
                    InitialDeposit = 3000m,
                    roomId = 104
                },
                new Patient
                {
                    PatientId = Guid.Parse("AF6AE5C7-1520-479C-ADD6-B90C84633AE5"),
                    AadharId = "567890123456",
                    FirstName = "Suresh",
                    LastName = "Yadav",
                    MobileNumber = "9876501234",
                    Gender = "Male",
                    Disease = "COVID-19",
                    Symptoms = "Fever, cough, breathlessness",
                    AdmissionDateTime = new DateTime(2025, 5, 24, 16, 0, 0),
                    InitialDeposit = 6000m,
                    roomId = 105
                }
            );
        }
    }

}


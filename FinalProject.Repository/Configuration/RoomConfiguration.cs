using FinalProject.Entities.Models;
using FinalProject.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FinalProject.Repository.Configuration
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            // Enum to string conversion for BedType
            var bedTypeConverter = new EnumToStringConverter<BedType>();
            builder.Property(r => r.BedType)
                   .HasConversion(bedTypeConverter)
                   .IsRequired();

            // Identity column starting from 101
            builder.Property(r => r.RoomId)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn(seed: 101, increment: 1);

            // Required RoomNumber
            builder.Property(r => r.RoomNumber)
                   .IsRequired();

            // Required Price
            builder.Property(r => r.Price)
                   .IsRequired();

            // Seed data
            builder.HasData(
                new Room { RoomId = 101, RoomNumber = "A101", Price = 1000m, BedType = BedType.Single },
                new Room { RoomId = 102, RoomNumber = "A102", Price = 2000m, BedType = BedType.Double },
                new Room { RoomId = 103, RoomNumber = "A103", Price = 500m, BedType = BedType.General },
                new Room { RoomId = 104, RoomNumber = "A104", Price = 5000m, BedType = BedType.ICU },
                new Room { RoomId = 105, RoomNumber = "B101", Price = 1000m, BedType = BedType.Single },
                new Room { RoomId = 106, RoomNumber = "B102", Price = 2000m, BedType = BedType.Double },
                new Room { RoomId = 107, RoomNumber = "B103", Price = 500m, BedType = BedType.General },
                new Room { RoomId = 108, RoomNumber = "B104", Price = 5000m, BedType = BedType.ICU },
                new Room { RoomId = 109, RoomNumber = "C101", Price = 1000m, BedType = BedType.Single },
                new Room { RoomId = 110, RoomNumber = "C102", Price = 2000m, BedType = BedType.Double },
                new Room { RoomId = 111, RoomNumber = "C103", Price = 500m, BedType = BedType.General },
                new Room { RoomId = 112, RoomNumber = "C104", Price = 5000m, BedType = BedType.ICU }
            );
        }
    }
}

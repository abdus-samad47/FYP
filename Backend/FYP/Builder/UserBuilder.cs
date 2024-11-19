using FYP.Models;
using Microsoft.EntityFrameworkCore;

namespace FYP.Builder
{
    public class UserBuilder
    {
        internal static void BuilderUser(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<User>();
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnName("User_Id").IsRequired().ValueGeneratedOnAdd();
            builder.Property(u => u.Username).HasColumnName("User_name").IsRequired().HasMaxLength(50).IsUnicode(true);
            builder.Property(u => u.Email).HasColumnName("User_Email").IsRequired().HasMaxLength(100).IsUnicode(true);
            builder.Property(u => u.PasswordHash).HasColumnName("User_Password").IsRequired().HasMaxLength(255).IsUnicode(false);
            builder.Property(u => u.Salt).HasColumnName("User.Salt").IsRequired().HasMaxLength(255).IsUnicode(false);
            builder.Property(u => u.Role).HasColumnName("User.Role").IsRequired().HasMaxLength(20).IsUnicode(true);
            builder.Property(u => u.CreatedAt).HasColumnName("User_CreatedAt").IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(u => u.UpdatedAt).HasColumnName("User_UpdatedAt").IsRequired(false);
            builder.Property(u => u.DeletedAt).HasColumnName("User_DeletedAt").IsRequired(false);
            builder.Property(u => u.Nic).HasColumnName("User.NIC").IsRequired().HasMaxLength(13).IsUnicode(true);
            builder.Property(u => u.Phonenumber).HasColumnName("User_PhoneNumber").IsRequired().HasMaxLength(20).IsUnicode(true);
            builder.Property(u => u.Address).HasColumnName("User_Address").IsRequired().HasMaxLength(255).IsUnicode(true);
            builder.Property(u => u.Status).HasColumnName("User_Status").IsRequired().HasMaxLength(10).HasDefaultValue("Offline").IsUnicode(true);

            // Add unique constraints
            builder.HasIndex(u => u.Username).IsUnique();
            builder.HasIndex(u => u.Email).IsUnique();
            builder.HasIndex(u => u.Nic).IsUnique();
            builder.HasIndex(u => u.Phonenumber).IsUnique();

            // Configuring relationships
            //builder.HasMany(u => u.SentMessages)
            //    .WithOne(m => m.Sender)
            //    .HasForeignKey(m => m.SenderId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.HasMany(u => u.ReceivedMessages)
            //    .WithOne(m => m.RoomId)
            //    .HasForeignKey(m => m.ReceiverId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.HasMany(u => u.CreatedChatRooms)
            //    .WithOne(cr => cr.Creator)
            //    .HasForeignKey(cr => cr.CreatedBy)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.HasMany(u => u.ChatRoomUsers)
            //    .WithOne(cru => cru.User)
            //    .HasForeignKey(cru => cru.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

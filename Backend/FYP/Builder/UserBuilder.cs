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
            builder.HasKey(u => u.user_id);
            builder.Property(u => u.user_id).HasColumnName("user_id").IsRequired().ValueGeneratedOnAdd();
            builder.Property(u => u.username).HasColumnName("user_name").IsRequired().HasMaxLength(50).IsUnicode(true);
            builder.Property(u => u.email).HasColumnName("user_email").IsRequired().HasMaxLength(100).IsUnicode(true);
            builder.Property(u => u.password).HasColumnName("user_password").IsRequired().HasMaxLength(255).IsUnicode(false);
            builder.Property(u => u.salt).HasColumnName("user_salt").IsRequired().HasMaxLength(255).IsUnicode(false);
            builder.Property(u => u.role).HasColumnName("user_role").IsRequired().HasMaxLength(20).IsUnicode(true);
            builder.Property(u => u.created_at).HasColumnName("user_created_at").IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(u => u.updated_at).HasColumnName("user_updated_at").IsRequired(false);
            builder.Property(u => u.deleted_at).HasColumnName("user_deleted_at").IsRequired(false);
            builder.Property(u => u.nic).HasColumnName("user_nic").IsRequired().HasMaxLength(13).IsUnicode(true);
            builder.Property(u => u.phone_number).HasColumnName("user_phone_number").IsRequired().HasMaxLength(20).IsUnicode(true);
            builder.Property(u => u.address).HasColumnName("user_address").IsRequired().HasMaxLength(255).IsUnicode(true);
            builder.Property(u => u.status).HasColumnName("user_status").IsRequired().HasMaxLength(10).HasDefaultValue("Offline").IsUnicode(true);

            // Add unique constraints
            builder.HasIndex(u => u.username).IsUnique();
            builder.HasIndex(u => u.email).IsUnique();
            builder.HasIndex(u => u.nic).IsUnique();
            builder.HasIndex(u => u.phone_number).IsUnique();

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

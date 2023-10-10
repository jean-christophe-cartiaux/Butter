using Butter.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butter.DataAcces.Configs
{
    internal class FriendsConfig : IEntityTypeConfiguration<FriendsEntity>
    {
        public void Configure(EntityTypeBuilder<FriendsEntity> builder)
        {
            builder.Property(f => f.UserId)
                .IsRequired();
                builder.Property(f=>f.FriendId)
                .IsRequired();
            builder.HasNoKey();



            builder.HasOne(f => f.Users).WithMany
                (u => u.Friends)
                .HasForeignKey(f => f.UserId).OnDelete
                (DeleteBehavior.NoAction);

            builder.HasOne(f=>f.Friends)
                .WithMany(u=>u.MyFriends) 
                .HasForeignKey(f => f.FriendId)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}

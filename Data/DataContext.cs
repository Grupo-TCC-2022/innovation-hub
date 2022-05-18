using innovation_hub.Models;
using Microsoft.EntityFrameworkCore;

namespace innovation_hub.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<AppUserProposal> AppUserProposals { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Phase> Phases { get; set; }
        public DbSet<AppUserProposalVote> AppUserProposalVote { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUserProposal>()
                .HasKey(AD => new { AD.AppUserId, AD.ProposalId });
        }
    }
}
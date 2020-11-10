using Microsoft.EntityFrameworkCore;

namespace Main.Models {
    public class MainContext : DbContext {
        public MainContext (DbContextOptions<MainContext> options) : base (options) { }
        public DbSet<BatteryItems> batteries { get; set; }
        public DbSet<BuildingItems> buildings { get; set; }
        public DbSet<ColumnItems> columns { get; set; }
        public DbSet<CustomerItems> customers { get; set; }
        public DbSet<ElevatorItems> elevators { get; set; }
        public DbSet<LeadItems> leads { get; set; }
        public DbSet<InterventionItems> interventions { get; set; }

    }
}
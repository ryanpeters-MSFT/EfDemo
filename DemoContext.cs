using Microsoft.EntityFrameworkCore;

public class DemoContext : DbContext
{
    public DbSet<Dog> Dogs { get; set; }
    public DbSet<Shot> Applicants { get; set; }
    public DbSet<Agency> Agencies { get; set; }
    public DbSet<Shot> Shots { get; set; }

    public DemoContext(DbContextOptions<DemoContext> context) : base(context) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        //optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var agencies = new Agency[]
        {
            new Agency { Id = 1, Name = "Saving Grace Animal Rescue", City = "Millersvile", State = "MD", Zip = "21108" },
            new Agency { Id = 2, Name = "Last Chance Animal Rescue", City = "Waldorf", State = "MD", Zip = "20603" }
        };

        var dogs = new Dog[]
        {
            new Dog { Id = 1, Name = "Pickles", Breed = "Pug", Age = 5, Received = DateTime.Parse("2/2/2023"), AgencyId = 1 },
            new Dog { Id = 2, Name = "Fluffy", Breed = "Pitty Mix", Age = 2, Received = DateTime.Parse("1/29/2023"), AgencyId = 2 },
            new Dog { Id = 3, Name = "Cheeky", Breed = "Poodle", Age = 8, Received = DateTime.Parse("1/29/2023"), AgencyId = 1 },
            new Dog { Id = 4, Name = "Dan", Breed = "Hound", Age = 4, Received = DateTime.Parse("1/29/2023"), AgencyId = 2 },
            new Dog { Id = 5, Name = "Charlie", Breed = "Labrador", Age = 7, Received = DateTime.Parse("1/29/2023"), AgencyId = 2 }
        };

        var shots = new Shot[]
        {
            new Shot { Id = 1, Name = "Bordetella" },
            new Shot { Id = 2, Name = "Canine Distemper"},
            new Shot { Id = 3, Name = "Canine Hepatitis" },
            new Shot { Id = 4, Name = "Heartworm" },
            new Shot { Id = 5, Name = "Kennel Cough" }
        };

        modelBuilder.Entity<Agency>().HasData(agencies);
        modelBuilder.Entity<Dog>().HasData(dogs);
        modelBuilder.Entity<Shot>().HasData(shots);

        modelBuilder.Entity<DogShot>(dogShot =>
        {
            dogShot.HasData(
                new DogShot { Id = 1, DogId = 1, ShotId = 1, Administered = DateTime.Parse("1/29/2023"), Notes = "No wincing" },
                new DogShot { Id = 2, DogId = 1, ShotId = 2, Administered = DateTime.Parse("1/22/2023"), Notes = "Has a fear of needles!" },
                new DogShot { Id = 3, DogId = 1, ShotId = 3, Administered = DateTime.Parse("1/17/2023"), Notes = "Was a good dog, got a treat afterward" },
                new DogShot { Id = 4, DogId = 2, ShotId = 2, Administered = DateTime.Parse("2/2/2023"), Notes = "This dog ran like hell" },
                new DogShot { Id = 5, DogId = 3, ShotId = 4, Administered = DateTime.Parse("12/17/2022"), Notes = "Tried to eat syringe" }
            );
        });

        // modelBuilder.Entity<DogShot>(dogShot =>
        // {
        //     dogShot.HasOne(s => s.Dog).WithMany(s => s.DogShots);
        //     dogShot.HasOne(s => s.Shot).WithMany(s => s.DogShots);
        // });

        // modelBuilder.Entity<DogShot>(applicant => 
        // {
        //     applicant
        //         .HasMany(a => a.Dogs)
        //         .WithMany(d => d.Applicants)
        //         .UsingEntity(ad => ad.ToTable("ApplicantDog").HasData(
        //             new { DogsId = 1, ApplicantsId = 1}
        //         ));
        // });
    }
}
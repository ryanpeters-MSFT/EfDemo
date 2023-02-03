using Microsoft.EntityFrameworkCore;

public class DemoService
{
    private readonly DemoContext context;

    public DemoService(DemoContext context) => this.context = context;

    public async Task Run()
    {
        SimpleQuery();
        //JoinQuery();
        //CustomSql();
        //LinqQuery();
        //ChangeTracking();
        //UpdateEntityBad();
        //UpdateEntityGood();
        //UpdateRawSql();
    }

    public void SimpleQuery()
    {
        var dogs = context.Dogs;

        foreach (var dog in dogs)
        {
            Console.WriteLine($"{dog.Name} is {dog.Age} years old");
        }
    }

    public void JoinQuery()
    {
        var dogs = context.Dogs
            .Include(d => d.Agency)
            .Include(d => d.DogShots)
            .ThenInclude(s => s.Shot)
            .ToList();

        foreach (var dog in dogs)
        {
            Console.WriteLine($"{dog.Name} is {dog.Age} years old, and belongs to {dog.Agency.Name}");

            foreach (var dogShot in dog.DogShots)
            {
                Console.WriteLine($"- Has {dogShot.Shot.Name} administered");
            }
        }
    }

    public void QueryRawSql()
    {
        // this approach MUST fill every required property on the entity
        var dogs = context.Dogs.FromSqlRaw("select * from dogs limit 2").ToList();

        //var nameParameter = new MySqlParameter("@name", "Charlie");
        //var dogs = context.Dogs.FromSqlRaw("select * from dogs where Name = @name", nameParameter).ToList();

        //var name = "Charlie";
        //var dogs = context.Dogs.FromSqlInterpolated($"select * from dogs where Name = {name}").ToList();

        foreach (var dog in dogs)
        {
            Console.WriteLine($"{dog.Name} is {dog.Age} years old");
        }
    }

    public void LinqQuery()
    {
        var dogs = from d in context.Dogs
                join a in context.Agencies on d.AgencyId equals a.Id
                select new { d.Id, d.Name, AgencyName = a.Name };

        foreach (var dog in dogs)
        {
            Console.WriteLine($"{dog.Name} has ID {dog.Id} at {dog.AgencyName}");
        }
    }

    public void ChangeTracking()
    {
        var dogs = context.Dogs.ToList();

        //dogs.FirstOrDefault(d => d.Id == 2).Name = "Billy Boy Doggo";
        //dogs.FirstOrDefault(d => d.Breed == "Poodle").Name = "Poodle dog";

        foreach (var entry in context.ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged))
        {
            Console.WriteLine((entry.Entity as Dog).Name);
        }

        Console.WriteLine(context.ChangeTracker.DebugView.ShortView);
        Console.WriteLine(context.ChangeTracker.HasChanges());
    }
    
    public void UpdateEntityBad()
    {
        var dog = context.Find<Dog>(2);
        
        dog.Name = "Fluffy 2";

        context.SaveChanges();
    }

    public void UpdateEntityGood()
    {
        var dog = new Dog
        {
            Id = 2,
            Name = "Fluffy 2"
        };

        context.Entry(dog).Property(d => d.Name).IsModified = true;

        context.SaveChanges();
    }

    public void UpdateRawSql()
    {
        var id = 2;
        var newName = "Distemper";

        context.Database.ExecuteSqlInterpolated($"update shot set name = {newName} where id = {id}");
    }
}
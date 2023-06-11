using Microsoft.EntityFrameworkCore;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Movie> Movies {get; set;}
    
    public DbSet<User> Users {get; set;}

    public DbSet<Genre> Genres {get; set;}
    public DbSet<Actor> Actors {get; set;}
    
protected override void OnModelCreating(ModelBuilder modelBuilder)
{

}

}

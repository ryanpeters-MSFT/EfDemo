public class Shot
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<DogShot> DogShots { get; set; }
}
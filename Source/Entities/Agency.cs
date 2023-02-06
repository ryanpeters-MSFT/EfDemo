public class Agency
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public ICollection<Dog> Dogs { get; set; }
}
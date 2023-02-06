using System.ComponentModel.DataAnnotations.Schema;

public class Dog
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Breed { get; set; }
    public int Age { get; set; }
    public DateTime Received { get; set; }
    public int AgencyId { get; set; }
    public Agency Agency { get; set; }
    public ICollection<DogShot> DogShots { get; set; }
}
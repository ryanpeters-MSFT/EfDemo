public class DogShot
{
    public int Id { get; set; }
    public int DogId { get; set; }
    public Dog Dog { get; set; }
    public int ShotId { get; set; }
    public Shot Shot { get; set; }
    public DateTime Administered { get; set; }
    public string Notes { get; set; }
}
namespace Swd.PlayCollector.Model;

public class TypeOfDocument
{
    public int Id { get; set; }
    
    public string TypeName { get; set; }
    
    public List<Media> MediaSet { get; set; }
}
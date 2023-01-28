using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Swd.PlayCollectorTest;

public class TypeOfDocument
{
    public int Id { get; set; }
    
    public string TypeName { get; set; }
    
    public List<Media> MediaItems { get; set; }
}
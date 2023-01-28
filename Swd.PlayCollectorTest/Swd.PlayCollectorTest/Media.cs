using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Swd.PlayCollectorTest;

public class Media
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Uri { get; set; }

    public TypeOfDocument TypeOfDocument { get; set; }
}
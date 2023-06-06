using System.Collections;

namespace APBDKOL2.Entities;

public class Make
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
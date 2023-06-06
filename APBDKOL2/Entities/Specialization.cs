using System.Collections;

namespace APBDKOL2.Entities;

public class Specialization
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Mechanic> Mechanics { get; set; } = new List<Mechanic>();
}
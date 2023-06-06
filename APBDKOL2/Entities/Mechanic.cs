using System.Collections;

namespace APBDKOL2.Entities;

public class Mechanic
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Nickname { get; set; }
    public int Specialization_Id { get; set; }

    public virtual Specialization Specialization { get; set; } = null!;

    public virtual ICollection<MechanicCar> MechanicCars { get; set; } = new List<MechanicCar>();
}
using System.Collections;

namespace APBDKOL2.Entities;

public class Car
{
    public int Id { get; set; }
    public string RegistrationPlate { get; set; }
    public DateTime ProductionYear { get; set; }
    public int Make_Id { get; set; }

    public virtual Make Make { get; set; } = null!;

    public virtual ICollection<MechanicCar> MechanicCars { get; set; } = new List<MechanicCar>();
}
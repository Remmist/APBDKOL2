namespace APBDKOL2.Entities;

public class MechanicCar
{
    public int Mechanic_Id { get; set; }
    public int Car_Id { get; set; }

    public virtual Mechanic Mechanic { get; set; } = null!;
    public virtual Car Car { get; set; } = null!;
}
namespace APBDKOL2.DTO;

public class CarInsertDTO
{
    private int _mechanicId;
    private string _registrationPlate;
    private DateTime _productionYear;
    private string _makeName;

    public int MechanicId
    {
        get => _mechanicId;
        set => _mechanicId = value;
    }

    public string RegistrationPlate
    {
        get => _registrationPlate;
        set => _registrationPlate = value;
    }

    public DateTime ProductionYear
    {
        get => _productionYear;
        set => _productionYear = value;
    }

    public string MakeName
    {
        get => _makeName;
        set => _makeName = value;
    }
}
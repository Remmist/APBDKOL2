namespace APBDKOL2.DTO;

public class CarDTO
{
    private string _name;
    private string _registrationPlate;
    private DateTime _productionYear;

    public string Name
    {
        get => _name;
        set => _name = value;
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
}
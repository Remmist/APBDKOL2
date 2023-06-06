namespace APBDKOL2.DTO;

public class MechanicDTO
{
    private string _firstName;
    private string _lastName;
    private string _nickname;
    private string _specialization;

    private List<CarDTO> _cars = new List<CarDTO>();

    public string FirstName
    {
        get => _firstName;
        set => _firstName = value;
    }

    public string LastName
    {
        get => _lastName;
        set => _lastName = value;
    }

    public string Nickname
    {
        get => _nickname;
        set => _nickname = value;
    }

    public string Specialization
    {
        get => _specialization;
        set => _specialization = value;
    }

    public List<CarDTO> Cars
    {
        get => _cars;
        set => _cars = value;
    }
}
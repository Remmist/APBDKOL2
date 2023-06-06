using APBDKOL2.DTO;

namespace APBDKOL2.Services;

public interface IRepairDbService
{
    Task<MechanicDTO> GetMechanicAsync(int id);

    Task<string> AddCarAsync(CarInsertDTO carInsertDto);
}
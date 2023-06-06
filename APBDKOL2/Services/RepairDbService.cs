using APBDKOL2.DTO;
using APBDKOL2.Entities;
using Microsoft.EntityFrameworkCore;

namespace APBDKOL2.Services;

public class RepairDbService : IRepairDbService
{
    private readonly RepairDbContext _context;

    public RepairDbService(RepairDbContext context)
    {
        _context = context;
    }

    public async Task<MechanicDTO> GetMechanicAsync(int id)
    {
        if (! await _context.Mechanics.AnyAsync(x => x.Id == id))
        {
            return null;
        }

        var mec = await _context.Mechanics.SingleAsync(x => x.Id == id);
        var mecout = new MechanicDTO()
        {
            FirstName = mec.FirstName,
            LastName = mec.LastName,
            Nickname = mec.Nickname,
            Specialization = _context.Specializations.Single(x => x.Id == mec.Id).Name,
        };

        var carlist = await _context.MechanicCars.Where(x => x.Mechanic == mec).ToListAsync();

        foreach (var car in carlist)
        {
            var cardb = await _context.Cars.SingleAsync(x => x.Id == car.Car_Id);
            var make = await _context.Makes.SingleAsync(x => x.Id == cardb.Make_Id);
            mecout.Cars.Add(new CarDTO()
            {
               Name = make.Name,
               RegistrationPlate = cardb.RegistrationPlate,
               ProductionYear = cardb.ProductionYear
            });
        }
        return mecout;
    }

    public async Task<string> AddCarAsync(CarInsertDTO carInsertDto)
    {
        if (! await _context.Mechanics.AnyAsync(x => x.Id == carInsertDto.MechanicId))
        {
            return "Error: Nie ma takiego mechanika w bazie";
        }

        await _context.Database.BeginTransactionAsync();
        
        if (! await _context.Makes.AnyAsync(x => x.Name == carInsertDto.MakeName))
        {
            await _context.Makes.AddAsync(new Make() { Name = carInsertDto.MakeName });
            await _context.SaveChangesAsync();
        }

        var makedb = await _context.Makes.SingleAsync(x => x.Name == carInsertDto.MakeName);
        
        await _context.Cars.AddAsync(new Car()
        {
            RegistrationPlate = carInsertDto.RegistrationPlate,
            ProductionYear = carInsertDto.ProductionYear,
            Make_Id = makedb.Id
        });

        await _context.SaveChangesAsync();

        var cardb = await _context.Cars.SingleAsync(x => x.RegistrationPlate == carInsertDto.RegistrationPlate);

        await _context.MechanicCars.AddAsync(new MechanicCar()
        {
            Car_Id = cardb.Id,
            Mechanic_Id = carInsertDto.MechanicId
        });
        
        await _context.SaveChangesAsync();
        
        await _context.Database.CommitTransactionAsync();
        return "Ok";
    }
}
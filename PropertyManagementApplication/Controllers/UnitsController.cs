using System.Text.Unicode;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyManagementApplication.Data;
using PropertyManagementApplication.Models;
using PropertyManagementApplication.ViewModels;

namespace PropertyManagementApplication.Controllers;

public class UnitsController : Controller
{
    private readonly ApplicationDbContext _dbContext;
    
    public UnitsController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    [Authorize(Roles = AppRoles.PropertyManager)]
    public IActionResult _UnitForm(int propertyId)
    {
        UnitFormViewModel vm = new UnitFormViewModel() {PropertyId = propertyId};
        return PartialView("_UnitForm", vm);
    }

    [HttpGet]
    [Authorize(Roles = AppRoles.PropertyManager)]
    public async Task<IActionResult> EditUnitForm(int unitId)
    {
        var unit = await _dbContext
            .Units
            .AsNoTracking()
            .SingleOrDefaultAsync(u => u.Id == unitId);

        if (unit == null) return NotFound();

        UnitFormViewModel vm = new UnitFormViewModel()
        {
            Id = unit.Id,
            PropertyId = unit.PropertyId,
            UnitNumber = unit.UnitNumber,
            Bedrooms = unit.Bedrooms,
            Bathrooms = unit.Bathrooms,
            MonthlyRent = unit.MonthlyRent,
            SquareFootage = unit.SquareFootage,
            UnitType = unit.UnitType
        };
        
        
        return PartialView("_unitForm", vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = AppRoles.PropertyManager)]
    public async Task<IActionResult> SubmitForm(UnitFormViewModel input)
    {
        if (!ModelState.IsValid)
        {
            return PartialView("_unitForm", input);
        }

        Unit unit;

        if (input.Id == 0)
        {
            unit = new Unit();
            _dbContext.Units.Add(unit);
        }
        else
        {
            var existingUnit = await _dbContext.Units
                .SingleOrDefaultAsync(u => u.Id == input.Id);

            if (existingUnit == null)
            {
                return NotFound();
            }

            unit = existingUnit;
        }

        unit.PropertyId = input.PropertyId;
        unit.UnitNumber = input.UnitNumber;
        unit.Bedrooms = input.Bedrooms;
        unit.Bathrooms = input.Bathrooms;
        unit.MonthlyRent = input.MonthlyRent;
        unit.SquareFootage = input.SquareFootage;
        unit.UnitType = input.UnitType;
        
        
        await _dbContext.SaveChangesAsync();
        return Redirect($"/Properties/Property?propertyId={input.PropertyId}");
    }
}
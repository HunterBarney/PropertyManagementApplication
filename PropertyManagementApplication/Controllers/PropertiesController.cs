using System.ComponentModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyManagementApplication.Data;
using PropertyManagementApplication.Models;
using PropertyManagementApplication.ViewModels;

namespace PropertyManagementApplication.Controllers;

public class PropertiesController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public PropertiesController(
        ApplicationDbContext dbContext
    )
    {
        _dbContext = dbContext;
    }
    
    [Authorize(Roles = AppRoles.PropertyManager)]
    public IActionResult _PropertyForm()
    {
        return PartialView("_PropertyForm", new PropertyFormViewModel());
    }

    [HttpGet]
    [Authorize(Roles = AppRoles.PropertyManager)]
    public async Task<IActionResult> EditPropertyForm(int propertyId)
    {
        var property = await _dbContext
            .Properties
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.Id == propertyId);

        if (property == null) return NotFound();

        PropertyFormViewModel vm = new PropertyFormViewModel()
        {
            Id = propertyId,
            StreetAddress = property.StreetAddress,
            City = property.City,
            State = property.State,
            Zip = property.Zip,
            ContactEmail = property.ContactEmail,
            ContactPhone = property.ContactPhone,
            Name = property.Name
        };
        
        
        return PartialView("_PropertyForm", vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = AppRoles.PropertyManager)]
    public async Task<IActionResult> SubmitForm(PropertyFormViewModel input)
    {
        if (!ModelState.IsValid)
        {
            return PartialView("_PropertyForm", input);
        }

        Property property;

        if (input.Id == 0)
        {
            property = new Property();
            _dbContext.Properties.Add(property);
        }
        else
        {
            var existingProperty = await _dbContext.Properties
                .SingleOrDefaultAsync(p => p.Id == input.Id);

            if (existingProperty == null)
            {
                return NotFound();
            }

            property = existingProperty;
        }

        property.Name = input.Name;
        property.StreetAddress = input.StreetAddress;
        property.City = input.City;
        property.State = input.State;
        property.Zip = input.Zip;
        property.ContactEmail = input.ContactEmail;
        property.ContactPhone = input.ContactPhone;

        await _dbContext.SaveChangesAsync();
        return Redirect($"/");
    }

    [HttpGet]
    public async Task<IActionResult> Property(int propertyId)
    {
        var property = await _dbContext
            .Properties
            .AsNoTracking()
            .Include(p => p.Units)
            .SingleOrDefaultAsync(p => p.Id == propertyId);
        return View(property);
    }
}

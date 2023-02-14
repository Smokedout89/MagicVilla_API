namespace MagicVilla_Web.Models.VM;

using DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public class VillaNumberCreateVM
{
    public VillaNumberCreateVM()
    {
        VillaNumber = new VillaNumberCreateDTO();
    }

    public VillaNumberCreateDTO VillaNumber { get; set; }

    [ValidateNever]
    public IEnumerable<SelectListItem> VillaList { get; set; }
}
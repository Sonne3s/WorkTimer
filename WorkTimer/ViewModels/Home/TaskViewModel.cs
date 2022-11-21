using Microsoft.AspNetCore.Mvc.Rendering;

namespace WorkTimer.ViewModels.Home
{
    public record TaskViewModel(
        Guid Id, int Number, string Name, string Description, List<SelectListItem> Priority, List<SelectListItem> ChildElements);
}

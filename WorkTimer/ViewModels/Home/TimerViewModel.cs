using Microsoft.AspNetCore.Mvc.Rendering;

namespace WorkTimer.ViewModels.Home
{
    public record TimerViewModel(List<SelectListItem> Tasks);
}

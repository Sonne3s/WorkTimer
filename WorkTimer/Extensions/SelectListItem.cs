using Microsoft.AspNetCore.Mvc.Rendering;

namespace WorkTimer.Extensions
{
    public static class SelectListItemExtension
    {
        public static IEnumerable<SelectListItem> SetSelectedItem(this IEnumerable<SelectListItem> list, string value)
            => list.Select(i => new SelectListItem(i.Text, i.Value, i.Value == value));
    }
}

using Microsoft.Maui.Handlers;

namespace Wibci.MauiControls.Controls
{
    public sealed partial class EntryExHandler : EntryHandler
    {
        public static int HandlerCount;

        public EntryExHandler()
        {
            Mapper.ModifyMapping(nameof(EntryEx.Background), MapBackgroundCustom);
            Mapper.AppendToMapping(nameof(EntryEx.IsValid), MapBackgroundDependency);
            Mapper.AppendToMapping(nameof(EntryEx.HasBorder), MapBackgroundDependency);
        }
    }
}

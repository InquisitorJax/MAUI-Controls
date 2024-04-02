using Microsoft.Maui.Handlers;

namespace Wibci.MauiControls.Controls
{
    public sealed partial class EntryExHandler : EntryHandler
    {
        public static int HandlerCount;

        public EntryExHandler()
        {
            Mapper.AppendToMapping("Initial", MapEntryEx);
            Mapper.AppendToMapping(nameof(EntryEx.IsValid), MapIsValid);
        }
    }
}

using eWolfPixelStandard.Project;
using System.Collections.Generic;
using System.Linq;

namespace eWolfPixelStandard.Helpers
{
    public static class ItemHelper
    {
        private static readonly Dictionary<ItemTypes, string> _extensionsMap = new Dictionary<ItemTypes, string>()
        {
            { ItemTypes.Sprite, "SPR"},
            { ItemTypes.BackGround, "BG"},
            { ItemTypes.Animation, "ANIM"},
            { ItemTypes.TextFile, "TXT"},
            { ItemTypes.Folder, ""},
        };

        public static ItemTypes GetType(string extensions)
        {
            string extensionsUpper = extensions.ToUpper().TrimStart('.');
            return _extensionsMap.FirstOrDefault(x => x.Value == extensionsUpper).Key;
        }

        public static string GetType(ItemTypes item)
        {
            return _extensionsMap.FirstOrDefault(x => x.Key == item).Value.ToLower();
        }
    }
}

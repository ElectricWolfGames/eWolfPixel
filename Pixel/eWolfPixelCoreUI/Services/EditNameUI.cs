using eWolfPixelStandard.Interfaces;
using eWolfPixelUI.Pages;

namespace eWolfPixelUI.Services
{
    public class EditNameUI : IEditNameUI
    {
        public string EditName(string title, string oldName)
        {
            NameItem ni = new NameItem
            {
                NewName = oldName,
                TitleText = title
            };

            ni.ShowDialog();

            if (ni.Apply)
            {
                return ni.NewName;
            }
            return oldName;
        }
    }
}

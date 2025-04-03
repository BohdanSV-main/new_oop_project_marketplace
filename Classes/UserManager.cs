using System;
using System.Windows.Forms;

namespace Marketplace
{
    public class UserManager
    {
        private readonly TabControl _mainFrame;
        private readonly TabPage _addProductPage;

        public UserManager(TabControl mainFrame, TabPage addProductPage)
        {
            _mainFrame = mainFrame;
            _addProductPage = addProductPage;
        }


        public void CheckUserAccess()
        {

            if (SessionManager.CurrentUser == null)// don`t touch. Idk but work
            {
                MessageBox.Show("Помилка: користувач не знайдений!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!SessionManager.CurrentUser.IsAdmin)
            {
                _mainFrame.TabPages.Remove(_addProductPage);
            }
            else
            {
                if (!_mainFrame.TabPages.Contains(_addProductPage))
                {
                    _mainFrame.TabPages.Add(_addProductPage);
                }
            }
        }

    }
}

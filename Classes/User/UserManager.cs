using System;
using System.Windows.Forms;

namespace Marketplace
{
    public class UserManager
    {
        private readonly TabControl _mainFrame;
        private readonly TabPage _addProductPage;
        private readonly TabPage _pageShoppingList;
        private readonly TabPage _pageStorage;

        public UserManager(TabControl mainFrame, TabPage addProductPage, TabPage pageShoppingList)
        {
            _mainFrame = mainFrame;
            _addProductPage = addProductPage;
            _pageShoppingList = pageShoppingList;
        }


        public void CheckUserAccess()
        {
            if (SessionManager.CurrentUser == null)
            {
                MessageBox.Show("Помилка: користувач не знайдений!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!SessionManager.CurrentUser.IsAdmin)
            {
                if (_addProductPage != null)
                {
                    _mainFrame.TabPages.Remove(_addProductPage);
                }
            }
            else
            {
                if (!_mainFrame.TabPages.Contains(_addProductPage) && _addProductPage != null)
                {
                    _mainFrame.TabPages.Add(_addProductPage);
                }
            }
        }


    }
}

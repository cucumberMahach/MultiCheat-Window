using MultiCheat_Window.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiCheat_Window.Utils
{
    static class Messages
    {

        public static void CheckConnectErrorMessage(string error)
        {
            MessageBox.Show("Ошибка при подключении к серверу: \r\n"+error, "MultiCheat", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        public static void NoAdminRightsMessage()
        {
            MessageBox.Show("Для работы программы требуются права администратора", "MultiCheat", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }
        public static void UpdateMessage()
        {
            MessageBox.Show(string.Format("MultiCheat обновлён до последней версии {0} от {1}", Constants.versionNumber, Constants.versionDate), "Обновление MultiCheat", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        public static void UpdateConnectError()
        {
            MessageBox.Show("Невозможно подключиться к серверам", "Обновление MultiCheat", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        public static void UpdateDataError()
        {
            MessageBox.Show("Ошибка при проверке версии программы", "MultiCheat", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            System.Diagnostics.Process.Start(Constants.VK_group);
        }
    }

}

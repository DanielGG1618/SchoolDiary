using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_diary
{
    public static class Utils
    {
        private const string _inDevelopText = "В разработке";
        private const string _noEditModeText = "Не работает в режиме редактирования";

        public static Bitmap GetControlScreenshot(Control control)
        {
            Bitmap bmp = new Bitmap(control.Width, control.Height);//создаем картинку нужных размеров
            control.DrawToBitmap(bmp, control.ClientRectangle);//копируем изображение нужного контрола в bmp

            return bmp;
        }

        public static Bitmap GetControlScreenshotByRectangle(Control control, Rectangle rectangle)
        {
            Bitmap bmp = new Bitmap(rectangle.Width, rectangle.Height);//создаем картинку нужных размеров
            control.DrawToBitmap(bmp, rectangle);//копируем изображение нужного контрола в bmp

            return bmp;
        }

        public static void InDevelop()
        {
            MessageBox.Show(_inDevelopText, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void NoEditMode()
        {
            MessageBox.Show(_noEditModeText, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

    }
}

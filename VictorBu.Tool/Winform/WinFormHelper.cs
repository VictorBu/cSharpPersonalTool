using System.Drawing;
using System.Windows.Forms;

namespace VictorBu.Tool.Winform
{
    public static class WinFormHelper
    {
        /// <summary>
        /// 阻止窗口手动关闭
        /// https://www.cnblogs.com/libushuang/p/5783955.html
        /// </summary>
        /// <param name="e"></param>
        public static void StopManualClosing(FormClosingEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.ApplicationExitCall: e.Cancel = false; break;//应用程序要求关闭窗口
                case CloseReason.FormOwnerClosing: e.Cancel = true; break;//所有者窗体正在关闭
                case CloseReason.MdiFormClosing: e.Cancel = true; break;//MDI窗体关闭事件
                case CloseReason.None: break;//不明原因的关闭
                case CloseReason.TaskManagerClosing: e.Cancel = false; break;//任务管理器关闭进程
                case CloseReason.UserClosing: e.Cancel = true; break;//用户通过UI关闭窗口或者通过Alt+F4关闭窗口
                case CloseReason.WindowsShutDown: e.Cancel = false; break;//操作系统准备关机
            }
        }

        /// <summary>
        /// RichTextBox 支持多种颜色文字
        /// https://stackoverflow.com/questions/10587715/multi-color-textbox-c-sharp
        /// </summary>
        /// <param name="box"></param>
        /// <param name="text"></param>
        /// <param name="color"></param>
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}

using ImageCompressorTool;

namespace ImageCompressorTool
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            MainForm mainForm = new MainForm();  // 创建 MainForm 对象
            //mainForm.trackBar.Scroll += mainForm.trackBar_Scroll; // 绑定事件处理程序

            Application.Run(mainForm);
        }
    }

}
 
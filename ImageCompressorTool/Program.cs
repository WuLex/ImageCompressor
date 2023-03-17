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
            MainForm mainForm = new MainForm();  // ���� MainForm ����
            //mainForm.trackBar.Scroll += mainForm.trackBar_Scroll; // ���¼��������

            Application.Run(mainForm);
        }
    }

}
 
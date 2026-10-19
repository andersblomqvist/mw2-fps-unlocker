using System.Diagnostics;

namespace mw2_fps_unlocker
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new AppForm());
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[FATAL ERROR] {ex.GetType().Name}: {ex.Message}");
                Debug.WriteLine($"[STACK TRACE] {ex.StackTrace}");
                MessageBox.Show($"Fatal Error:\n\n{ex.GetType().Name}\n{ex.Message}\n\nStack Trace:\n{ex.StackTrace}", 
                    "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
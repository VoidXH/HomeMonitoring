using System;
using System.Windows.Forms;

namespace HomeEditor {
    static class Program {
        public static HomeEditor window;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            window = new HomeEditor();
            Application.Run(window);
        }
    }
}
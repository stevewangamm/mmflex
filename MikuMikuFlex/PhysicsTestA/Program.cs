using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MMF;

namespace PhysicsTestA
{
    static class Program
    {
        /// <summary>
        /// Main application エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MessagePump.Run(new Form1());
        }
    }
}

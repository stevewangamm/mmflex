using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhysicsTest {
	static class Program {
		/// <summary>
		/// Main application エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() {
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurrencyCalculatorV2
{
	static class CurrencyCalculator
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			System.Windows.Forms.Application.EnableVisualStyles();
			System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
			try
			{
				System.Windows.Forms.Application.Run(new Application());
			}
			catch
			{
				System.Windows.Forms.Application.Run(new Exception());
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsWorkbench.ControlProviders;
using WinFormsWorkbench.Functions;

namespace WinFormsWorkbench
{
	internal class WorkbenchForm
	{
		internal Form Form { get; }

		private Workbench _workbench { get; }

		internal WorkbenchForm(Workbench workbench)
		{
			_workbench = workbench;
			Form = new Form();
		}

		internal WorkbenchForm(Workbench workbench, Form form)
		{
			_workbench = workbench;
			Form = form;
		}
	}
}

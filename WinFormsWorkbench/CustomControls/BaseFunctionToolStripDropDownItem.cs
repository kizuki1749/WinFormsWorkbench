using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsWorkbench.Functions;

namespace WinFormsWorkbench.CustomControls
{
	internal partial class BaseFunctionToolStripDropDownItem : ToolStripDropDownItem
	{
		private BaseFunction _function;

		public BaseFunctionToolStripDropDownItem(BaseFunction function) : base()
		{
			_function = function;
			InitializeComponent();
			RegisterEvents();
		}

		public BaseFunctionToolStripDropDownItem(string name, BaseFunction function) : base()
		{
			_function = function;
			Text = name;
			InitializeComponent();
			RegisterEvents();
		}

		private void RegisterEvents()
		{
			Paint += (sender, e) =>
			{
				if (_function != null)
				{
					Enabled = _function.CanRunFunction;
				}
			};
		}
	}
}

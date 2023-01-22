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
		}

		public BaseFunctionToolStripDropDownItem(string name, BaseFunction function) : base()
		{
			_function = function;
			Text = name;
			InitializeComponent();
		}


		protected override void OnPaint(PaintEventArgs pe)
		{
			if (_function != null)
			{
				//if (_function is ToggleFunction toggle)
					//throw new InvalidOperationException("この項目ではその操作は無効です。");
				Enabled = _function.CanRunFunction;
			}
			base.OnPaint(pe);
		}
	}
}

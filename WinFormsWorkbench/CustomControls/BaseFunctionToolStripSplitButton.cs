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
	internal partial class BaseFunctionToolStripSplitButton : ToolStripSplitButton
	{
		private BaseFunction _function;

		public BaseFunctionToolStripSplitButton(BaseFunction function) : base()
		{
			_function = function;
			InitializeComponent();
			RegisterEvents();
		}

		public BaseFunctionToolStripSplitButton(string name, BaseFunction function) : base(name)
		{
			_function = function;
			InitializeComponent();
			RegisterEvents();
		}

		private void RegisterEvents()
		{
			Paint += (sender, e) =>
			{
				if (_function != null)
				{
					if (_function is ToggleFunction toggle)
						throw new InvalidOperationException("この項目ではその操作は無効です。");
					Enabled = _function.CanRunFunction;
				}
			};
		}
	}
}

﻿using System;
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
	internal partial class BaseFunctionToolStripMenuItem : ToolStripMenuItem
	{
		private BaseFunction _function;

		public BaseFunctionToolStripMenuItem(BaseFunction function) : base()
		{
			_function = function;
			InitializeComponent();
		}

		public BaseFunctionToolStripMenuItem(string name, BaseFunction function) : base(name)
		{
			_function = function;
			InitializeComponent();
		}


		protected override void OnPaint(PaintEventArgs pe)
		{
			if (_function != null)
			{
				if (_function is ToggleFunction toggle)
					Checked = toggle.IsActive;
				Enabled = _function.CanRunFunction;
			}
			base.OnPaint(pe);
		}
	}
}
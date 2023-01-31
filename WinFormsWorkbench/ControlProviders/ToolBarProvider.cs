using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsWorkbench.CustomControls;
using WinFormsWorkbench.Functions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsWorkbench.ControlProviders
{
	/// <summary>
	/// ツールバーを生成するクラス
	/// </summary>
	public class ToolBarProvider : ControlProvider
	{
		/// <summary>
		/// 対象のツールバー
		/// </summary>
		public ToolStrip ToolStrip { get; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ToolBarProvider()
		{
			ToolStrip = new ToolStrip();
		}

		/// <inheritdoc />
		protected internal override void Init(Form form)
		{
			form.Controls.Add(ToolStrip);
		}

		/// <inheritdoc />
		protected internal override void Refresh(FunctionGroup functions)
		{
			ToolStrip.Items.Clear();
			ApplyFunctionsInternal(ToolStrip.Items, functions);
		}

		private void ApplyFunctionsInternal(ToolStripItemCollection toolStrip, FunctionGroup functions)
		{
			foreach (var item in functions.Functions)
			{
				if (item is SeparatorDummyFunction)
				{
					ToolStripSeparator separator = new ToolStripSeparator();
					toolStrip.Add(separator);
					continue;
				}
				if (item is FunctionGroup group)
				{
					ToolStripDropDownItem toolItem = null;
					if (ToolStrip.Items != toolStrip)
					{
						toolItem = new BaseFunctionToolStripMenuItem(item.Name, item);
						if (group.IsRunnable)
							toolItem.Click += (sender, e) => item.RunFunction();
					}
					else
					{
						if (group.IsRunnable)
						{
							var splitButton = new BaseFunctionToolStripSplitButton(item.Name, item);
							splitButton.ButtonClick += (sender, e) => item.RunFunction();
							toolItem = splitButton;
						}
						else
							toolItem = new BaseFunctionToolStripDropDownButton(item.Name, item);
					}
					toolItem.Image = item.Image;
					toolItem.Text = item.Name ?? "";
					toolItem.ToolTipText = toolItem.Image != null ? item.Name : "";
					if (item.Image != null && item.Name != null)
						toolItem.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
					else if (item.Image != null)
						toolItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
					else if (item.Name != null)
						toolItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
					ApplyFunctionsInternal(toolItem.DropDownItems, group);
					toolStrip.Add(toolItem);
				}
				else
				{
					if (ToolStrip.Items != toolStrip)
					{
						BaseFunctionToolStripMenuItem menuItem = new BaseFunctionToolStripMenuItem(item.Name, item);
						menuItem.Image = item.Image;
						menuItem.Click += (sender, e) => item.RunFunction();
						if (item is ToggleFunction toggle)
							menuItem.Checked = toggle.IsActive;
						toolStrip.Add(menuItem);
					}
					else
					{
						BaseFunctionToolStripButton menuItem = new BaseFunctionToolStripButton(item.Name, item);
						menuItem.Image = item.Image;
						menuItem.Click += (sender, e) => item.RunFunction();
						if (item is ToggleFunction toggle)
							menuItem.Checked = toggle.IsActive;
						toolStrip.Add(menuItem);
					}
				}
			}
		}
	}
}

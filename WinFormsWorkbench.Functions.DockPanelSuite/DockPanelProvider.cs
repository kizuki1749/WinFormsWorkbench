using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using WinFormsWorkbench.Functions;

namespace WinFormsWorkbench.ControlProviders
{
	/// <summary>
	/// DockPanelを生成するクラス
	/// </summary>
	public class DockPanelProvider : ControlProvider
	{
		/// <summary>
		/// 対象のDockPanel
		/// </summary>
		public DockPanel DockPanel { get; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public DockPanelProvider()
		{
			DockPanel = new DockPanel();
			DockPanel.Dock = DockStyle.Fill;
			DockPanel.Theme = new VS2015LightTheme();
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="theme">DockPanelに設定するテーマ</param>
		public DockPanelProvider(ThemeBase theme) : this()
		{
			DockPanel.Theme = theme;
		}

		/// <inheritdoc />
		protected override void Init(Form form)
		{
			form.Controls.Add(DockPanel);
		}

		/// <inheritdoc />
		protected override void Refresh(FunctionGroup functions)
		{
		}
	}
}

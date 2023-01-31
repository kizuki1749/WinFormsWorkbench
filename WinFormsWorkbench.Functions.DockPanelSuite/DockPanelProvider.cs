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

		private bool _doNotRegisterControl = false;

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

		/// <summary>
		/// コンストラクタ(既存のDockPanelを利用)
		/// </summary>
		/// <param name="dockPanel">対象のDockPanel</param>
		public DockPanelProvider(DockPanel dockPanel)
		{
			DockPanel = dockPanel;
			_doNotRegisterControl = true;
		}

		/// <inheritdoc />
		protected override void Init(Form form)
		{
			if (!_doNotRegisterControl)
				form.Controls.Add(DockPanel);
		}

		/// <inheritdoc />
		protected override void Refresh(FunctionGroup functions)
		{
		}
	}
}

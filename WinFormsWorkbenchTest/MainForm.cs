using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using WinFormsWorkbench;
using WinFormsWorkbench.ControlProviders;
using WinFormsWorkbench.Functions;

namespace WinFormsWorkbenchTest
{
	public partial class MainForm : Form
	{
		private Workbench _workbench;

		public MainForm()
		{
			InitializeComponent();
		}

		NativeContextMenuProvider contextMenuProvider = new NativeContextMenuProvider();
		private void MainForm_Shown(object sender, EventArgs e)
		{
			var item2 = new Function("項目2", (item) => MessageBox.Show("項目2"));
			item2.Enabled = false;
			DockPanelProvider dockPanel = new DockPanelProvider();
			dockPanel.DockPanel.MouseClick += MainForm_MouseClick;
			_workbench = new Workbench(this, new WorkbenchConfig(new List<ControlProvider>()
			{
				dockPanel,
				new ToolBarProvider(),
				new MenuBarProvider(),
				new NativeMenuProvider(),
				contextMenuProvider,
			}), new FunctionGroup(new List<BaseFunction>()
			{
				new FunctionGroup("項目1", new List<BaseFunction>()
				{
					new ToggleFunction("項目1", (item) => item2.Enabled = true, (item) => item2.Enabled = false),
					item2,
					new SeparatorDummyFunction(),
					new Function("項目3", (item) => MessageBox.Show("項目3"), Properties.Resources.Event_16x),
					new ModalWindowFunction("項目4", () => new MainForm(), Properties.Resources.Event_16x){ProviderOption = new IControlProviderOption[]{ new NativeMenuProviderOption(NativeMenuBar.NativeMenuFlags.MF_MENUBARBREAK) } },
					new DockPanelFunction("項目5", new DockContent(){Text = "テスト"})
				}, Properties.Resources.Event_16x),
				new SeparatorDummyFunction(),
				new FunctionGroup("項目2", new List<BaseFunction>()
				{
					new Function("項目1", (item) => MessageBox.Show("項目1")),
					new Function("項目2", (item) => MessageBox.Show("項目2")),
					new Function("項目3", (item) => MessageBox.Show("項目3")),
					new FunctionGroup("項目4", new List<BaseFunction>()
					{
						new Function("項目1", (item) => MessageBox.Show("項目1")),
						new Function("項目2", (item) => MessageBox.Show("項目2")),
						new Function("項目3", (item) => MessageBox.Show("項目3"))
					}, (item) => MessageBox.Show("項目4"))
				}),
				new FunctionGroup("項目3", new List<BaseFunction>()
				{
					new Function("項目1", (item) => MessageBox.Show("項目1")),
					new Function("項目2", (item) => MessageBox.Show("項目2")),
					new Function("項目3", (item) => MessageBox.Show("項目3")),
					new FunctionGroup("項目4", new List<BaseFunction>()
					{
						new Function("項目1", (item) => MessageBox.Show("項目1")),
						new Function("項目2", (item) => MessageBox.Show("項目2")),
						new Function("項目3", (item) => MessageBox.Show("項目3"))
					}, (item) => MessageBox.Show("項目4"))
				})
			}));
			_workbench.ApplyFunctions();
		}

		private void MainForm_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				contextMenuProvider.Menu.ShowContextMenu(MousePosition.X, MousePosition.Y, NativeMenuBar.ContextMenuFlags.TPM_LEFTALIGN, Handle);
			}
		}
	}
}

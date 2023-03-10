using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsWorkbench.CustomControls;
using WinFormsWorkbench.Functions;
using WinFormsWorkbench.Functions.Events;

namespace WinFormsWorkbench.ControlProviders
{
	/// <summary>
	/// メニューバーを生成するクラス
	/// </summary>
	public class MenuBarProvider : ControlProvider
	{
		/// <summary>
		/// 対象のメニューバー
		/// </summary>
		public MenuStrip Menu { get; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MenuBarProvider() : this(new MenuStrip())
		{
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="target">対象のメニューバー</param>
		public MenuBarProvider(MenuStrip target)
		{
			Menu = target;
		}

		/// <inheritdoc />
		protected internal override void Init(Form form)
		{
			form.Controls.Add(Menu);
		}

		/// <inheritdoc />
		protected internal override void Refresh(FunctionGroup functions)
		{
			Menu.Items.Clear();
			ApplyFunctionsInternal(Menu.Items, functions);
		}

		/// <summary>
		/// メニュー生成(内部処理)
		/// </summary>
		/// <param name="menu">対象のメニュー項目一覧</param>
		/// <param name="functions">機能グループ</param>
		private void ApplyFunctionsInternal(ToolStripItemCollection menu, FunctionGroup functions)
		{
			foreach (var item in functions.Functions)
			{
				if (item is IEventFunction)
					continue;
				if (item is SeparatorDummyFunction)
				{
					ToolStripSeparator separator = new ToolStripSeparator();
					menu.Add(separator);
					continue;
				}
				BaseFunctionToolStripMenuItem menuItem = new BaseFunctionToolStripMenuItem(item.Name, item);
				menuItem.Image = item.Image;
				if (item is FunctionGroup group)
				{
					ApplyFunctionsInternal(menuItem.DropDownItems, group);
					if (group.IsRunnable)
						menuItem.Click += (sender, e) => item.RunFunction();;
				}
				else
				{
					menuItem.Click += (sender, e) =>
					{
						item.RunFunction();
					};
				}
				menu.Add(menuItem);
			}
		}
	}
}

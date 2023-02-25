using System;
using System.Collections.Generic;
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
	/// コンテキストメニューを生成するクラス
	/// </summary>
	public class ContextMenuProvider : ControlProvider
	{
		/// <summary>
		/// 対象のコンテキストメニュー
		/// </summary>
		public ContextMenuStrip Menu { get; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="target">コンテキストメニューを設定するコントロール</param>
		public ContextMenuProvider(Control target)
		{
			Menu = new ContextMenuStrip();
			target.ContextMenuStrip = Menu;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="target">対象のコンテキストメニュー</param>
		public ContextMenuProvider(ContextMenuStrip target)
		{
			Menu = target;
		}

		/// <inheritdoc />
		protected internal override void Init(Form form)
		{
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
						menuItem.Click += (sender, e) => item.RunFunction();
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

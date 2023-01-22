using NativeMenuBar.Builders;
using NativeMenuBar.Hooks;
using NativeMenuBar.MenuItems;
using NativeMenuBar.Menus;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsWorkbench.Functions;

namespace WinFormsWorkbench.ControlProviders
{
	/// <summary>
	/// コンテキストメニューを生成するクラス
	/// </summary>
#if NET5_0_OR_GREATER
	[SupportedOSPlatform("windows7.0")]
#endif
	public class NativeContextMenuProvider : NativeMenuProvider
	{
		/// <summary>
		/// 対象のメニュー
		/// </summary>
		public NativePopupMenu Menu { get; private set; }
		private FunctionGroup _lastFunction;

		/// <inheritdoc />
		protected override void Init(Form form)
		{
		}

		/// <inheritdoc />
		protected override void Refresh(FunctionGroup functions)
		{
			_lastFunction = functions;
			Menu = (NativePopupMenu)ApplyFunctionsInternal(new NativePopupMenu(), functions);
		}

		/// <inheritdoc />
		protected override NativeMenu ApplyFunctionsInternal(NativeMenu menu, FunctionGroup functions)
		{
			foreach (var item in functions.Functions)
			{
				if (item is SeparatorDummyFunction)
				{
					NativeMenuSeparatorItem separator = new NativeMenuSeparatorItem();
					menu.AddMenuItem(separator);
					continue;
				}
				if (item is FunctionGroup group)
				{
					NativePopupMenu popup = new NativePopupMenu();
					popup = (NativePopupMenu)ApplyFunctionsInternal(popup, group);
					NativeMenuPopupItemBuilder builder = new NativeMenuPopupItemBuilder();
					builder.SetSubMenuItemsFromArray(popup.Items.ToArray());
					builder.WithText(item.Name).WithDisabled(!item.CanRunFunction);
					if (item.Image != null)
						builder.WithUncheckedIcon(new Bitmap(item.Image));
					menu.AddMenuItem(builder.Build());
				}
				else
				{
					NativeMenuItemBuilder builder = new NativeMenuItemBuilder();
					builder.ItemSelected += (sender) =>
					{
						item.RunFunction();
						Refresh(_lastFunction);
					};
					builder.WithText(item.Name).WithDisabled(!item.CanRunFunction);
					if (item.Image != null)
						builder.WithUncheckedIcon(new Bitmap(item.Image));
					if (item is ToggleFunction toggle)
						builder.WithChecked(toggle.IsActive);
					menu.AddMenuItem(builder.Build());
				}
			}
			return menu;
		}
	}
}

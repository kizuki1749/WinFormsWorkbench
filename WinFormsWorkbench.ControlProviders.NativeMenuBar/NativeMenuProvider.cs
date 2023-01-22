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
	/// WindowsAPIを用いたメニューバーを生成するクラス。
	/// </summary>
#if NET5_0_OR_GREATER
	[SupportedOSPlatform("windows7.0")]
#endif
	public class NativeMenuProvider : ControlProvider
	{
		private Form _form;
		private FunctionGroup _lastFunction;

		/// <inheritdoc />
		protected override void Init(Form form)
		{
			_form = form;
		}

		/// <inheritdoc />
		protected override void Refresh(FunctionGroup functions)
		{
			_lastFunction = functions;
			ApplyFunctionsInternal(new NativeMenu(new NETWindowMessageHook()), functions).SetMenu(_form.Handle);
		}

		/// <summary>
		/// コントロールを再描画します。他のプロバイダから項目の内容を更新した場合は再描画が必要です。
		/// </summary>
		public void Refresh()
		{
			Refresh(_lastFunction);
		}

		/// <summary>
		/// メニュー生成(内部処理)
		/// </summary>
		/// <param name="menu">対象のメニュー項目一覧</param>
		/// <param name="functions">機能グループ</param>
		/// <returns>作成されたメニュー</returns>
		protected virtual NativeMenu ApplyFunctionsInternal(NativeMenu menu, FunctionGroup functions)
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
					var menuItem = builder.Build();
					if (item.GetProviderOption<NativeMenuProviderOption>() != null)
						menuItem.Flags |= item.GetProviderOption<NativeMenuProviderOption>().AdditionalFlags;
					menu.AddMenuItem(menuItem);
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
					var menuItem = builder.Build();
					if (item.GetProviderOption<NativeMenuProviderOption>() != null)
						menuItem.Flags |= item.GetProviderOption<NativeMenuProviderOption>().AdditionalFlags;
					menu.AddMenuItem(menuItem);
				}
			}
			return menu;
		}
	}
}

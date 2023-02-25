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
	/// リストビューに項目に対する操作を生成するクラス
	/// </summary>
	public class ListViewProvider : ControlProvider
	{
		/// <summary>
		/// 項目選択時に実行される機能
		/// </summary>
		public virtual ListViewEventFunction ItemDoubleClickFunction { get; set; }

		/// <summary>
		/// 対象のリストビュー
		/// </summary>
		protected virtual ListView ListView { get; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ListViewProvider(ListView target)
		{
			target.MultiSelect = false;
			target.DoubleClick += (sender, e) =>
			{
				ProcessDoubleClickEvent((ListView)sender, e);
			};
			target.KeyDown += (sender, e) =>
			{
				if (e.KeyCode == Keys.Enter)
					ProcessDoubleClickEvent((ListView)sender, e);
			};
			ListView = target;
		}

		private void ProcessDoubleClickEvent(ListView target, EventArgs e)
		{
			if (target.SelectedItems.Count <= 0 || ItemDoubleClickFunction == null)
				return;
			ItemDoubleClickFunction.RunFunction(target.SelectedItems[0]);
		}

		/// <inheritdoc />
		protected internal override void Init(Form form)
		{
		}

		/// <inheritdoc />
		protected internal override void Refresh(FunctionGroup functions)
		{
			foreach (var function in functions.Functions)
			{
				if (function is ListViewEventFunction eventFunction)
				{
					ItemDoubleClickFunction = eventFunction;
					break;
				}
			}
		}

		/// <summary>
		/// 現在選択されている項目を取得します。
		/// </summary>
		/// <returns>現在選択されている項目</returns>
		public ListViewItem GetCurrentItem()
		{
			if (ListView.SelectedItems.Count <= 0)
				return null;
			return ListView.SelectedItems[0];
		}

		/// <summary>
		/// 現在選択されている項目を取得します。
		/// </summary>
		/// <returns>現在選択されている項目の配列</returns>
		public IReadOnlyCollection<ListViewItem> GetCurrentItems()
		{
			List<ListViewItem> result = new List<ListViewItem>();
			foreach (ListViewItem item in ListView.SelectedItems)
				result.Add(item);
			return result;
		}
	}
}

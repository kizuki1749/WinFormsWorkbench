using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsWorkbench.ControlProviders;

namespace WinFormsWorkbench
{
	/// <summary>
	/// ワークベンチウィンドウの設定
	/// </summary>
	public class WorkbenchConfig
	{
		/// <summary>
		/// ワークベンチウィンドウの名前
		/// </summary>
		public string Name { get; set; } = "ワークベンチウィンドウ";

		/// <summary>
		/// フォームに追加するコントロール
		/// </summary>
		public IReadOnlyCollection<ControlProvider> ControlProviders { get; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public WorkbenchConfig(IReadOnlyCollection<ControlProvider> controlProviders)
		{
			ControlProviders = controlProviders;
		}
	}
}

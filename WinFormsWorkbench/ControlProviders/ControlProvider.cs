using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsWorkbench.Functions;

namespace WinFormsWorkbench.ControlProviders
{
	/// <summary>
	/// フォーム上のそれぞれのコントロールを管理するクラス
	/// </summary>
	public abstract class ControlProvider
	{
		/// <summary>
		/// コントロールを初期化します。
		/// </summary>
		/// <param name="form">対象のフォーム</param>
		protected internal abstract void Init(Form form);

		/// <summary>
		/// コントロールを再描画します。
		/// </summary>
		protected internal abstract void Refresh(FunctionGroup functions);
	}
}

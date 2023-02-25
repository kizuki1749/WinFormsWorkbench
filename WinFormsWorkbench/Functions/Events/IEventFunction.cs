using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsWorkbench.Functions.Events
{
	/// <summary>
	/// イベントを示すインターフェイス
	/// </summary>
	public interface IEventFunction
	{
		/// <summary>
		/// 機能を実行します。
		/// </summary>
		void RunFunction(object target);
	}
}

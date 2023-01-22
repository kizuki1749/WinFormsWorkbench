using NativeMenuBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsWorkbench.ControlProviders
{
	/// <summary>
	/// WindowsAPIを用いたメニューバーを生成するクラスの設定
	/// </summary>
	public class NativeMenuProviderOption : IControlProviderOption
	{
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="flags">手動で追加指定するフラグ</param>
		public NativeMenuProviderOption(NativeMenuFlags flags)
		{
			AdditionalFlags = flags;
		}

		/// <summary>
		/// 手動で追加指定するフラグ
		/// </summary>
		public NativeMenuFlags AdditionalFlags { get; set; }
	}
}

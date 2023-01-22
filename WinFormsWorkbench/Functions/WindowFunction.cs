using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsWorkbench.Functions
{
	/// <summary>
	/// ウィンドウの表示・非表示を切り替え可能な機能
	/// </summary>
	public class WindowFunction : ToggleFunction
	{
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="name">名前</param>
		/// <param name="form">対象のフォーム</param>
		public WindowFunction(string name, Form form) : base(name, (item) => form.Show(), (item) => form.Visible = false)
		{
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="name">名前</param>
		/// <param name="form">対象のフォーム</param>
		/// <param name="image">項目に設定する画像</param>
		public WindowFunction(string name, Form form, Image image) : base(name, (item) => form.Show(), (item) => form.Visible = false, image)
		{
		}
	}
}

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
	/// モーダルウィンドウを表示可能な機能
	/// </summary>
	public class ModalWindowFunction : Function
	{
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="name">名前</param>
		/// <param name="form">対象のフォーム</param>
		public ModalWindowFunction(string name, Form form) : base(name, (item) => form.ShowDialog())
		{
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="name">名前</param>
		/// <param name="form">対象のフォーム</param>
		/// <param name="image">項目に設定する画像</param>
		public ModalWindowFunction(string name, Form form, Image image) : base(name, (item) => form.ShowDialog(), image)
		{
		}

		/// <summary>
		/// コンストラクタ(フォーム表示ごとにインスタンスを自動生成)
		/// </summary>
		/// <param name="name">名前</param>
		/// <param name="formType">対象のフォーム</param>
		public ModalWindowFunction(string name, Type formType) : base(name, (item) => ((Form)formType.Assembly.CreateInstance(formType.FullName)).ShowDialog())
		{
		}

		/// <summary>
		/// コンストラクタ(フォーム表示ごとにインスタンスを自動生成)
		/// </summary>
		/// <param name="name">名前</param>
		/// <param name="formType">対象のフォーム</param>
		/// <param name="image">項目に設定する画像</param>
		public ModalWindowFunction(string name, Type formType, Image image) : base(name, (item) => ((Form)formType.Assembly.CreateInstance(formType.FullName)).ShowDialog(), image)
		{
		}

		/// <summary>
		/// コンストラクタ(フォーム表示ごとにインスタンスを手動生成)
		/// </summary>
		/// <param name="name">名前</param>
		/// <param name="func">対象のフォームを生成するためのメソッド</param>
		public ModalWindowFunction(string name, Func<Form> func) : base(name, (item) => func().ShowDialog())
		{
		}

		/// <summary>
		/// コンストラクタ(フォーム表示ごとにインスタンスを手動生成)
		/// </summary>
		/// <param name="name">名前</param>
		/// <param name="func">対象のフォームを生成するためのメソッド</param>
		/// <param name="image">項目に設定する画像</param>
		public ModalWindowFunction(string name, Func<Form> func, Image image) : base(name, (item) => func().ShowDialog(), image)
		{
		}
	}
}

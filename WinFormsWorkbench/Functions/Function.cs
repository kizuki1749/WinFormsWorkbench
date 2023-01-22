using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsWorkbench.Functions
{
	/// <summary>
	/// 機能
	/// </summary>
	public class Function : BaseFunction
	{
		/// <inheritdoc />
		public override bool CanRunFunction => Enabled;

		/// <inheritdoc />
		public override Image Image => _image;

		/// <summary>
		/// 機能が実行可能かどうか
		/// </summary>
		public virtual bool Enabled { get; set; } = true;

		private Action<Function> _action;
		private Image _image;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="name">名前</param>
		/// <param name="action">実行する処理</param>
		public Function(string name, Action<Function> action) : base(name)
		{
			_action = action;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="name">名前</param>
		/// <param name="action">実行する処理</param>
		/// <param name="image">項目に設定する画像</param>
		public Function(string name, Action<Function> action, Image image) : this(name, action)
		{
			_image = image;
		}

		/// <inheritdoc />
		public override void RunFunction()
		{
			if (_action != null)
				_action(this);
		}
	}
}

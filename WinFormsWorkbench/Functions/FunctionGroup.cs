using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsWorkbench.Functions
{
	/// <summary>
	/// 機能グループ
	/// </summary>
	public class FunctionGroup : BaseFunction
	{
		/// <summary>
		/// 機能一覧
		/// </summary>
		public IReadOnlyCollection<BaseFunction> Functions { get; }

		/// <summary>
		/// 機能が実行可能であるか(実行する処理が設定されているか)
		/// </summary>
		public bool IsRunnable { get => _action != null; }

		/// <inheritdoc />
		public override Image Image => _image;

		private Action<FunctionGroup> _action;
		private Image _image;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="functions">機能一覧</param>
		public FunctionGroup(IReadOnlyCollection<BaseFunction> functions) : this(null, functions)
		{
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="name">名前</param>
		/// <param name="functions">機能一覧</param>
		public FunctionGroup(string name, IReadOnlyCollection<BaseFunction> functions) : base(name)
		{
			Functions = functions;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="name">名前</param>
		/// <param name="functions">機能一覧</param>
		/// <param name="action">実行する処理</param>
		public FunctionGroup(string name, IReadOnlyCollection<BaseFunction> functions, Action<FunctionGroup> action) : this(name, functions)
		{
			_action = action;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="name">名前</param>
		/// <param name="functions">機能一覧</param>
		/// <param name="action">実行する処理</param>
		/// <param name="image">項目に設定する画像</param>
		public FunctionGroup(string name, IReadOnlyCollection<BaseFunction> functions, Action<FunctionGroup> action, Image image) : this(name, functions, action)
		{
			_image = image;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="name">名前</param>
		/// <param name="functions">機能一覧</param>
		/// <param name="image">項目に設定する画像</param>
		public FunctionGroup(string name, IReadOnlyCollection<BaseFunction> functions, Image image) : this(name, functions)
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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsWorkbench.Functions
{
	/// <summary>
	/// 有効・無効切り替え可能な機能
	/// </summary>
	public class ToggleFunction : BaseFunction
	{
		/// <summary>
		/// 機能が有効であるか
		/// </summary>
		public virtual bool IsActive { get => _active; }

		/// <inheritdoc />
		public override Image Image => _image;

		private bool _active;
		private Action<ToggleFunction> _enableAction;
		private Action<ToggleFunction> _disableAction;
		private Image _image;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="name">名前</param>
		/// <param name="enableAction">有効にした時に実行する処理</param>
		/// <param name="disableAction">無効にした時に実行する処理</param>
		public ToggleFunction(string name, Action<ToggleFunction> enableAction, Action<ToggleFunction> disableAction) : base(name)
		{
			_enableAction = enableAction;
			_disableAction = disableAction;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="name">名前</param>
		/// <param name="enableAction">有効にした時に実行する処理</param>
		/// <param name="disableAction">無効にした時に実行する処理</param>
		/// <param name="image">項目に設定する画像</param>
		public ToggleFunction(string name, Action<ToggleFunction> enableAction, Action<ToggleFunction> disableAction, Image image) : this(name, enableAction, disableAction)
		{
			_image = image;	
		}

		/// <summary>
		/// 有効・無効を切り替え、対応する処理を実行します。
		/// </summary>
		public override void RunFunction()
		{
			_active = !_active;
			if (IsActive)
				EnableFunction();
			else
				DisableFunction();
		}

		/// <summary>
		/// 機能を有効にした時の処理を実行します。
		/// </summary>
		public virtual void EnableFunction()
		{
			if (_enableAction != null)
				_enableAction(this);
		}

		/// <summary>
		/// 機能を無効にした時の処理を実行します。
		/// </summary>
		public virtual void DisableFunction()
		{
			if (_disableAction != null)
				_disableAction(this);
		}
	}
}

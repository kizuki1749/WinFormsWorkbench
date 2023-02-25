using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsWorkbench.Functions.Events
{
	/// <summary>
	/// イベントを示す機能
	/// </summary>
	public abstract class EventFunction<T> : BaseFunction, IEventFunction
	{
		/// <inheritdoc />
		public override bool CanRunFunction => true;


		private Action<EventFunction<T>, T> _action;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="action">実行する処理</param>
		public EventFunction(Action<EventFunction<T>, T> action) : base("")
		{
			_action = action;
		}

		/// <inheritdoc />
		public override void RunFunction()
		{
			RunFunction(default);
		}

		/// <summary>
		/// 機能を実行します。
		/// </summary>
		/// <param name="target">渡すパラメーター</param>
		public virtual void RunFunction(T target)
		{
			if (_action != null)
				_action(this, target);
		}

		/// <inheritdoc />
		public void RunFunction(object target)
		{
			if (!(target is T))
				return;
			RunFunction((T)target);
		}
	}
}

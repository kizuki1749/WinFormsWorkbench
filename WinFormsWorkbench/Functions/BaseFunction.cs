using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsWorkbench.ControlProviders;

namespace WinFormsWorkbench.Functions
{
	/// <summary>
	/// 機能のベース
	/// </summary>
	public abstract class BaseFunction
	{
		/// <summary>
		/// 名前
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// 機能が実行可能かどうか
		/// </summary>
		public virtual bool CanRunFunction { get; } = true;

		/// <summary>
		/// 項目に設定する画像
		/// </summary>
		public virtual Image Image { get; }

		/// <summary>
		/// コントロールを描画する機能に渡す設定項目群
		/// </summary>
		public virtual IControlProviderOption[] ProviderOption { get; set; }

		/// <summary>
		/// この機能が所属しているワークベンチ
		/// </summary>
		protected Workbench Workbench { get => _workbench; }

		internal Workbench _workbench;

		/// <summary>
		/// ProviderOptionから指定した型の項目を返します。
		/// 複数指定されている場合は、一番最初の項目を返します。
		/// 存在しなかった場合はデフォルト値(基本的にはnull)を返します。
		/// </summary>
		/// <typeparam name="T">取得対象の型</typeparam>
		/// <returns>指定した型の項目</returns>
		public T GetProviderOption<T>()
		{
			if (ProviderOption == null)
				return default;
			foreach (IControlProviderOption option in ProviderOption)
			{
				if (option is T)
					return (T)option;
			}
			return default;
		}

		/// <summary>
		/// ProviderOptionから指定した型の項目を返します。
		/// 複数指定されている場合は、一番最初の項目を返します。
		/// 存在しなかった場合はデフォルト値(基本的にはnull)を返します。
		/// </summary>
		/// <param name="type">取得対象の型</param>
		/// <returns>指定した型の項目</returns>
		public object GetProviderOption(Type type)
		{
			foreach (IControlProviderOption option in ProviderOption)
			{
				if (type.IsInstanceOfType(option))
					return option;
			}
			return null;
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="name">機能名</param>
		public BaseFunction(string name)
		{
			Name = name;
		}

		/// <summary>
		/// 機能を実行します
		/// </summary>
		public abstract void RunFunction();
	}
}

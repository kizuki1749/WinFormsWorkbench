using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsWorkbench.ControlProviders;
using WinFormsWorkbench.Functions;

namespace WinFormsWorkbench
{
	/// <summary>
	/// ワークベンチウィンドウを管理するクラス
	/// </summary>
	public class Workbench
	{
		/// <summary>
		/// ワークベンチ名
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// ワークベンチの設定
		/// </summary>
		public WorkbenchConfig Config { get; }

		/// <summary>
		/// 機能群
		/// </summary>
		public FunctionGroup Functions { get; set; }

		private WorkbenchForm _workbenchForm;

		/// <summary>
		/// コンストラクタ。フォームを指定した場合は対象フォームにコントロールを自動配置します。
		/// </summary>
		/// <param name="form">対象のフォーム</param>
		/// <param name="config">ワークベンチの設定</param>
		/// <param name="functions">機能グループ</param>
		public Workbench(Form form, WorkbenchConfig config, FunctionGroup functions)
		{
			Config = config;
			Functions = functions;
			_workbenchForm = new WorkbenchForm(this, form);
			SetInstanseToFunction(Functions);
			foreach (ControlProvider provider in Config.ControlProviders)
			{
				provider.Init(_workbenchForm.Form);
			}
		}

		private void SetInstanseToFunction(BaseFunction function)
		{
			function.Initialize(this);
			function.Initialized(this);
			if (function is FunctionGroup group)
			{
				foreach (BaseFunction item in group.Functions)
				{
					SetInstanseToFunction(item);
				}
			}
		}

		/// <summary>
		/// 設定項目をコントロールに適用します。
		/// </summary>
		public void ApplyFunctions()
		{
			foreach (ControlProvider provider in Config.ControlProviders)
			{
				provider.Refresh(Functions);
			}
		}
	}
}

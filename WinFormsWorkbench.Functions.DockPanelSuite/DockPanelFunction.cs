﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeifenLuo.WinFormsUI.Docking;
using WinFormsWorkbench.ControlProviders;

namespace WinFormsWorkbench.Functions
{
	/// <summary>
	/// DockPanelSuiteを用いたドッキングウィンドウを制御するクラス
	/// </summary>
    public class DockPanelFunction : ToggleFunction
    {
		/// <summary>
		/// 表示先のDockPanel
		/// </summary>
		public DockPanel TargetPanel
		{
			get
			{
				if (!Workbench.Config.ControlProviders.Any(item => item is DockPanelProvider))
					return null;
				return ((DockPanelProvider)Workbench.Config.ControlProviders.First(item => item is DockPanelProvider)).DockPanel;
			}
		}

		/// <summary>
		/// 表示時の初期ドッキング状態
		/// </summary>
		public DockState DockState { get; set; }

		/// <summary>
		/// 表示内容
		/// </summary>
		public DockContent Content { get; }

		/// <inheritdoc />
		public override bool IsActive { get => !Content.IsHidden; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="name">名前</param>
		/// <param name="content">表示内容</param>
		/// <param name="dockState">初期ドッキング状態</param>
		public DockPanelFunction(string name, DockContent content, DockState dockState = DockState.Document) : this(name, content, null, dockState)
		{
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="name">名前</param>
		/// <param name="content">表示内容</param>
		/// <param name="image">項目に設定する画像</param>
		/// <param name="dockState">初期ドッキング状態</param>
		public DockPanelFunction(string name, DockContent content, Image image, DockState dockState = DockState.Document) : base(name, null, null, image)
		{
			DockState = dockState;
			Content = content;
			Content.HideOnClose = true;
		}

		/// <inheritdoc />
		public override void RunFunction()
		{
			if (!IsActive)
				EnableFunction();
			else
				DisableFunction();
		}

		/// <inheritdoc />
		public override void EnableFunction()
		{
			Content.Show(TargetPanel, DockState);
		}

		/// <inheritdoc />
		public override void DisableFunction()
		{
			Content.Hide();
		}
	}
}
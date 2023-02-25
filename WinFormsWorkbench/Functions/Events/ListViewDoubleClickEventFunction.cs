﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsWorkbench.Functions.Events
{
	/// <summary>
	/// リストビュー項目をダブルクリックした時に発生するイベントを処理する機能
	/// </summary>
	public class ListViewDoubleClickEventFunction : EventFunction<ListViewItem>
	{
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="action">実行する処理</param>
		public ListViewDoubleClickEventFunction(Action<EventFunction<ListViewItem>, ListViewItem> action) : base(action)
		{
		}
	}
}

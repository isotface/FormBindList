using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyDebug
{
	/// <summary>
	/// 組み込み型変数をデータバインド対応にする
	/// </summary>
	/// <typeparam name="T">データ型</typeparam>
	public struct VarData<T>
	{
		private T _Value;
		/// <summary>
		/// データの実体
		/// </summary>
		public T Value
		{
			get { return _Value; }
			set { _Value = value; }
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="src">元データ</param>
		public VarData(T src = default(T))
		{
			this._Value = src;
		}
	}
}

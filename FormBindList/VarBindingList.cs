using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MyDebug
{
	/// <summary>
	/// SyncListインターフェイス
	/// </summary>
	public interface IVarBindingList
	{
		void SyncList();
	}


	/// <summary>
	/// 組み込み型Listをデータバインド対応にする（BindingList）
	/// </summary>
	/// <typeparam name="T">データ型</typeparam>
	public class VarBindingList<T> : BindingList<VarData<T>>, IVarBindingList
	{
		/// <summary>
		/// 参照先リスト
		/// </summary>
		private IList<T> m_Src;

		/// <summary>
		/// データソースへのバインディング型
		/// </summary>
		public Type TypeofDataSource
		{
			get { return typeof(VarData<T>); }
		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public VarBindingList()
			: base()
		{
			// 参照先リストがない場合は、List<T>型で内部データを新規に作る
			m_Src = new List<T>();
		}
		public VarBindingList(IList<T> src)
			: base()
		{
			m_Src = src;
			SyncList();
		}

		/// <summary>
		/// 追加
		/// </summary>
		/// <param name="item">追加するデータ</param>
		public void Add(T item)
		{
			// 参照先、自分ともにデータを追加
			m_Src.Add(item);
			base.Add(new VarData<T>(item));
		}

		/// <summary>
		/// 追加（複数）
		/// </summary>
		/// <param name="collection">追加するデータ</param>
		public void AddRange(IEnumerable<T> collection)
		{
			foreach (var item in collection)
			{
				this.Add(item);
			}
		}

		/// <summary>
		/// クリア
		/// </summary>
		public new void Clear()
		{
			// 参照先、自分ともにクリアする
			m_Src.Clear();
			base.Clear();
		}

		/// <summary>
		/// 参照先リストに同期する
		/// </summary>
		public void SyncList()
		{
			// 参照先リストはクリアしない
			base.Clear();
			foreach (var item in m_Src)
			{
				base.Add(new VarData<T>(item));
			}
		}
	}
}

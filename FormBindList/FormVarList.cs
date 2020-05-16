using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyDebug
{
	public partial class FormVarList : Form
	{
		List<DataGridView> m_listDgv = new List<DataGridView>();
		List<BindingSource> m_listBindSrc = new List<BindingSource>();
		List<IVarBindingList> m_listData = new List<IVarBindingList>();

		public int ListCount
		{
			get;
			private set;
		}

		public FormVarList()
		{
			InitializeComponent();

			ListCount = 0;
			tableLayoutPanel1.Dock = DockStyle.Fill;
			m_listDgv.Add(new DataGridView());
		}

		public void AddList<T>(IList<T> list)
		{
			if (list == null)
			{
				return;
			}

			if (tableLayoutPanel1.ColumnCount <= ListCount)
			{
				tableLayoutPanel1.ColumnCount += 1;
				tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
				m_listDgv.Add(new DataGridView());
			}
			m_listDgv[ListCount].Dock = DockStyle.Fill;
			m_listDgv[ListCount].RowHeadersVisible = false;
			m_listDgv[ListCount].ReadOnly = true;
			tableLayoutPanel1.Controls.Add(m_listDgv[ListCount], ListCount, 0);
			
			for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
			{
				tableLayoutPanel1.ColumnStyles[i] = new ColumnStyle(SizeType.Percent, (100.0f / tableLayoutPanel1.ColumnCount));
			}

			var bindSrc= new BindingSource();
			var listData = new VarBindingList<T>(list);
			bindSrc.DataSource = listData.TypeofDataSource;
			bindSrc.DataSource = listData;
			m_listBindSrc.Add(bindSrc);
			m_listData.Add(listData);

			m_listDgv[ListCount].DataSource = m_listBindSrc[ListCount];
			ListCount++;
		}

		public void UpdateList(int idx)
		{
			if (idx < 0 || m_listBindSrc.Count <= idx)
			{
				return;
			}

			m_listData[idx].SyncList();
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyDebug;

namespace FormBindList
{
	public partial class Form1 : Form
	{
		int m_count = 0;

		List<double> m_testData = new List<double>(new double[] { 0.1, 0.2, 0.3 });
		List<string> m_testData2 = new List<string>(new string[] { "One", "Two", "Three", "Four", "Five" });
		List<DateTime> m_testData3 = new List<DateTime>(new DateTime[] { DateTime.Now });

		//FormVarBindList f;
		FormVarList f;


		public Form1()
		{
			InitializeComponent();

			f = new FormVarList();
			f.Show();

			f.AddList<double>(m_testData);
			f.AddList<string>(m_testData2);
			f.AddList<DateTime>(m_testData3);
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			m_testData.Add(m_count++);
			m_testData2.Add("Item" + m_count);
			m_testData3.Add(DateTime.Now);
			f.UpdateList(0);
			f.UpdateList(1);
			f.UpdateList(2);
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			m_testData.Clear();
			m_testData2.Clear();
			m_testData3.Clear();
			f.UpdateList(0);
			f.UpdateList(1);
			f.UpdateList(2);
		}
	}
}

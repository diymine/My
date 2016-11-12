using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Study.Winform.GridView
{
    public class User
    {
        public string Code { get; set; }
        public string Name { get; set; }

        
    }
    public partial class Form1 : Form
    {
        private BindingSource masterBindingSource = new BindingSource();
        private BindingSource detailsBindingSource = new BindingSource();
        private BindingSource masterBindingSource2 = new BindingSource();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView3.DataSource = masterBindingSource2;
            // Bind the DataGridView controls to the BindingSource

            // components and load the data from the database.

            dataGridView1.DataSource = masterBindingSource;

            dataGridView2.DataSource = detailsBindingSource;

            GetData();

            // Resize the master DataGridView columns to fit the newly loaded data.

            dataGridView1.AutoResizeColumns();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Width = 80;
            }

            dataGridView1.Columns[0].Frozen = true;
            dataGridView1.Columns[1].Frozen = true;
            // Configure the details DataGridView so that its columns automatically

            // adjust their widths when the data changes.

            dataGridView2.AutoSizeColumnsMode =

                DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void GetData()
        {
            var dataSet = new DataSet();
            var table = new DataTable("Customer");
            table.Columns.Add(new DataColumn("a"));
            table.Columns.Add(new DataColumn("b"));
            table.Columns.Add(new DataColumn("c"));
            table.Columns.Add(new DataColumn("d"));
            table.Columns.Add(new DataColumn("e"));
            table.Columns.Add(new DataColumn("f"));
            table.Columns.Add(new DataColumn("g"));
            table.Columns.Add(new DataColumn("h"));
            table.Rows.Add(new object[] { "aa", "bb", "cc", "dd", "ee", "ff", "gg", "hh" });
            table.Rows.Add(new object[] { "cc", "dd1", "cc", "dd", "ee", "ff", "gg", "hh" });
            var table1 = new DataTable("Order");
            table1.Columns.Add(new DataColumn("c"));
            table1.Columns.Add(new DataColumn("d"));
            table1.Rows.Add(new object[] { "aa", "bb" });
            table1.Rows.Add(new object[] { "cc", "ddddddff" });
            dataSet.Tables.Add(table);
            dataSet.Tables.Add(table1);
            var relation = new DataRelation("relationTest", table.Columns["a"], table1.Columns["c"]);
            dataSet.Relations.Add(relation);
            masterBindingSource.DataSource = dataSet;
            masterBindingSource.DataMember = "Customer";
            detailsBindingSource.DataSource = masterBindingSource;
            detailsBindingSource.DataMember = "relationTest";

            masterBindingSource2.DataSource = new List<User>()
            {
                new User(){Code = "11",Name = "22"},
                new User(){Code = "33",Name = "22"},
            };


        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;

namespace ConfRemClient
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Provider=SQLOLEDB;Data Source=DESKTOP-B4L9B2O\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=MainOffice";
        RemSrv.RemLib server = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RemotingConfiguration.Configure(@"Client.config", false);
        }

        private void show_tables_Click(object sender, EventArgs e)
        {
            server = new RemSrv.RemLib();
            List<string> tables = server.GetTables(connectionString);
            DataTable dataTable = new DataTable("tables_list");
            dataTable.Columns.Add("id", Type.GetType("System.Int32"));
            dataTable.Columns.Add("table_name",
            Type.GetType("System.String"));
            int cnt = 0;
            tables.ForEach(t =>
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow[0] = cnt++;
                dataRow[1] = t;
                dataTable.Rows.Add(dataRow);
            });
            resultGridView.DataSource = dataTable;
        }
        private void find_by_id_Click(object sender, EventArgs e)
        {
            server = new RemSrv.RemLib();
            var tableName = table_name_text_box.Text;
            var id = Int32.Parse(search_id_holder.Text);
            resultGridView.DataSource = server.FindDataById(connectionString, "dbo." + tableName, "id", id);
        }
        private void show_table_data_Click(object sender, EventArgs e)
        {
            server = new RemSrv.RemLib();
            var tableName = tableName2.Text;
            var filter = filterExpression.Text;
            if (filter == null || filter.Trim().Equals(""))
            {
                resultGridView.DataSource = server.GetTable(connectionString,
                "dbo." + tableName);
            }
            else
            {
                resultGridView.DataSource = server.FindData(connectionString,
                "dbo." + tableName, filter);
            }
        }
        //***************************
        private void resultGridView_UserDeletingRow(object sender,
        DataGridViewRowCancelEventArgs e)
        {
            foreach (DataGridViewRow row in resultGridView.SelectedRows)
            {
                if (row != null)
                {
                    var id = Int32.Parse(row.Cells["id"].Value.ToString());
                    server = new RemSrv.RemLib();
                    var tableName = tableName2.Text;
                    server.DeleteDataById(connectionString, "dbo." + tableName, "id",
                    id);
                    resultGridView.DataSource = server.GetTable(connectionString,
                    "dbo." + tableName);
                }
            }
        }
        private void HorizontalQuery(object sender, EventArgs e)
        {
            server = new RemSrv.RemLib();
            resultGridView.DataSource =
            server.HorizontalQuery();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            server = new RemSrv.RemLib();
            resultGridView.DataSource =
            server.VerticalQuery();
        }
        //***************************
        private void insert_Click(object sender, EventArgs e)
        {
            server = new RemSrv.RemLib();
            var tableName = tableName2.Text;
            foreach (DataGridViewRow row in resultGridView.SelectedRows)
            {
                if (row != null)
                {
                    server.InsertData(connectionString, "dbo." + tableName, null, row.Cells["id"].Value.ToString());
                }
            }
        }
    }
}

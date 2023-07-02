using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCFClientForms
{
    public partial class Form1 : Form
    {
        DataLayerClient client = null;
        public Form1()
        {
            InitializeComponent();
            client = new DataLayerClient();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void show_tables_Click(object sender, EventArgs e)
        {
            string connectionString = @"Provider=SQLOLEDB;Data Source=DESKTOP-B4L9B2O\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=MainOffice";
            List<string> tables = client.GetTables(connectionString).ToList<string>();
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
            string connectionString = @"Provider=SQLOLEDB;Data Source=DESKTOP-B4L9B2O\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=MainOffice";
            var tableName = table_name_text_box.Text;
            var id = Int32.Parse(search_id_holder.Text);
            resultGridView.DataSource = client.FindDataById(connectionString, "dbo." + tableName, "id", id);
        }
        private void show_table_data_Click(object sender, EventArgs e)
        {
            string connectionString = @"Provider=SQLOLEDB;Data Source=DESKTOP-B4L9B2O\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=MainOffice";
            var tableName = tableName2.Text;
            var filter = filterExpression.Text;
            if (filter == null || filter.Trim().Equals(""))
            {
                resultGridView.DataSource = client.GetTable(connectionString,
                "dbo." + tableName);
            }
            else
            {
                resultGridView.DataSource = client.FindData(connectionString,
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
                    var tableName = tableName2.Text;
                    string connectionString = @"Provider=SQLOLEDB;Data Source=DESKTOP-B4L9B2O\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=MainOffice";
                    client.DeleteDataById(connectionString, "dbo." + tableName, "id", id);
                    resultGridView.DataSource = client.GetTable(connectionString,
                    "dbo." + tableName);
                }
            }
        }
        private void ProductNameWithQuantityBiggerThan50Horizontal(object sender, EventArgs e)
        {
            resultGridView.DataSource =
            client.ProductNameWithQuantityBiggerThan50Horizontal();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            resultGridView.DataSource =
            client.OrderIdWhereEmployeeNameStartWithDandSumBetween500and1000Vertical();
        }
        //***************************
        private void insert_Click(object sender, EventArgs e)
        {
            string connectionString = @"Provider=SQLOLEDB;Data Source=DESKTOP-B4L9B2O\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=MainOffice";
            var tableName = tableName2.Text;
            foreach (DataGridViewRow row in resultGridView.SelectedRows)
            {
                if (row != null)
                {
                    client.InsertData(connectionString, "dbo." + tableName, null, row.Cells["id"].Value.ToString());
                }
            }
        }
    }
}

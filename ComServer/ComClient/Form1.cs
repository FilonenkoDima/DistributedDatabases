using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ComClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void show_tables_Click(object sender, EventArgs e)
        {
            var server = new ComSrv.DBComSrv();
            string connectionString = @"Provider=SQLOLEDB;Data Source=DESKTOP-B4L9B2O\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=MainOffice";
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
            var server = new ComSrv.DBComSrv();
            string connectionString = @"Provider=SQLOLEDB;Data
Source=DESKTOP-B4L9B2O;Integrated Security=SSPI;Initial
Catalog=TypicalBranch";
            var tableName = table_name_text_box.Text;
            var id = Int32.Parse(search_id_holder.Text);
            resultGridView.DataSource = server.FindDataById(connectionString,
            "dbo." + tableName, "id", id);
        }
        private void show_table_data_Click(object sender, EventArgs e)
        {
            var server = new ComSrv.DBComSrv();
            string connectionString = @"Provider=SQLOLEDB;Data
Source=DESKTOP-B4L9B2O;Integrated Security=SSPI;Initial
Catalog=TypicalBranch";
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
                    var server = new ComSrv.DBComSrv();
                    var tableName = tableName2.Text;
                    string connectionString = @"Provider=SQLOLEDB;Data
Source=DESKTOP-B4L9B2O;Integrated Security=SSPI;Initial
Catalog=TypicalBranch";
                    server.DeleteDataById(connectionString, "dbo." + tableName, "id",
                    id);
                    resultGridView.DataSource = server.GetTable(connectionString,
                    "dbo." + tableName);
                }
            }
        }
        private void employees_with_progress_Click(object sender, EventArgs e)
        {
            var server = new ComSrv.DBComSrv();
            resultGridView.DataSource =
            server.ProductNameWithQuantityBiggerThan50Horizontal();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var server = new ComSrv.DBComSrv();
            resultGridView.DataSource =
            server.OrderIdWhereEmployeeNameStartWithDandSumBetween500and1000Vertical();
        }
        //***************************
        private void insert_Click(object sender, EventArgs e)
        {
            var server = new ComSrv.DBComSrv();
            string connectionString = @"Provider=SQLOLEDB;Data
Source=DESKTOP-B4L9B2O;Integrated Security=SSPI;Initial
Catalog=TypicalBranch";
            var tableName = tableName2.Text;
            foreach (DataGridViewRow row in resultGridView.SelectedRows)
            {
                if (row != null)
                {
                    server.InsertData(connectionString, "dbo." + tableName, null,
                    row.Cells["id"].Value.ToString());
                }
            }
        }
    }
}

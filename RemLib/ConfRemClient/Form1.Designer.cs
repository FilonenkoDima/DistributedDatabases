using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ConfRemClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            resultGridView = new DataGridView();
            show_tables = new Button();
            find_by_id = new Button();
            search_id_holder = new TextBox();
            save = new Button();
            table_name_label = new Label();
            table_name_text_box = new TextBox();
            id = new Label();
            show_table_data = new Button();
            tableName2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            filterExpression = new TextBox();
            employees_with_progress = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)resultGridView).BeginInit();
            SuspendLayout();
            //
            // resultGridView
            //
            resultGridView.ColumnHeadersHeightSizeMode =
            DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resultGridView.Location = new Point(27, 22);
            resultGridView.Name = "resultGridView";
            resultGridView.RowHeadersWidth = 51;
            resultGridView.RowTemplate.Height = 29;
            resultGridView.Size = new Size(375, 508);
            resultGridView.TabIndex = 0;
            resultGridView.UserDeletingRow +=
            resultGridView_UserDeletingRow;
            //
            // show_tables
            //
            show_tables.Location = new Point(423, 117);
            show_tables.Name = "show_tables";
            show_tables.Size = new Size(221, 43);
            show_tables.TabIndex = 1;
            show_tables.Text = "Show all tables";
            show_tables.UseVisualStyleBackColor = true;
            show_tables.Click += show_tables_Click;
            //
            // find_by_id
            //
            find_by_id.Location = new Point(720, 121);
            find_by_id.Name = "find_by_id";
            find_by_id.Size = new Size(295, 39);
            find_by_id.TabIndex = 3;
            find_by_id.Text = "find_by_id";
            find_by_id.UseVisualStyleBackColor = true;
            find_by_id.Click += find_by_id_Click;
            //
            // search_id_holder
            //
            search_id_holder.Location = new Point(783, 37);
            search_id_holder.Name = "search_id_holder";
            search_id_holder.Size = new Size(278, 27);
            search_id_holder.TabIndex = 4;
            //
            // save
            //
            save.Location = new Point(888, 490);
            save.Name = "save";
            save.Size = new Size(127, 40);
            save.TabIndex = 5;
            save.Text = "save";
            save.UseVisualStyleBackColor = true;
            //
            // table_name_label
            //
            table_name_label.AutoSize = true;
            table_name_label.Location = new Point(679, 75);
            table_name_label.Name = "table_name_label";
            table_name_label.Size = new Size(85, 20);
            table_name_label.TabIndex = 7;
            table_name_label.Text = "Table name";
            //
            // table_name_text_box
            //
            table_name_text_box.Location = new Point(783, 76);
            table_name_text_box.Name = "table_name_text_box";
            table_name_text_box.Size = new Size(278, 27);
            table_name_text_box.TabIndex = 8;
            //
            // id
            //
            id.AutoSize = true;
            id.Location = new Point(679, 44);
            id.Name = "id";
            id.Size = new Size(24, 20);
            id.TabIndex = 9;
            id.Text = "ID";
            //
            // show_table_data
            //
            show_table_data.Location = new Point(487, 338);
            show_table_data.Name = "show_table_data";
            show_table_data.Size = new Size(239, 41);
            show_table_data.TabIndex = 10;
            show_table_data.Text = "Show table data";
            show_table_data.UseVisualStyleBackColor = true;
            show_table_data.Click += show_table_data_Click;
            //
            // tableName2
            //
            tableName2.Location = new Point(563, 231);
            tableName2.Name = "tableName2";
            tableName2.Size = new Size(213, 27);
            tableName2.TabIndex = 11;
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Location = new Point(423, 238);
            label1.Name = "label1";
            label1.Size = new Size(85, 20);
            label1.TabIndex = 12;
            label1.Text = "Table name";
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Location = new Point(423, 289);
            label2.Name = "label2";
            label2.Size = new Size(116, 20);
            label2.TabIndex = 13;
            label2.Text = "Filter expression";
            //
            // filterExpression
            //
            filterExpression.Location = new Point(563, 282);
            filterExpression.Name = "filterExpression";
            filterExpression.Size = new Size(213, 27);
            filterExpression.TabIndex = 14;
            //
            // employees_with_progress
            //
            employees_with_progress.Location = new Point(815, 231);
            employees_with_progress.Name = "employees_with_progress";
            employees_with_progress.Size = new Size(246, 42);
            employees_with_progress.TabIndex = 15;
            employees_with_progress.Text = "Employees with progress";
            employees_with_progress.UseVisualStyleBackColor = true;
            employees_with_progress.Click += employees_with_progress_Click;
            //
            // button1
            //
            button1.Location = new Point(815, 299);
            button1.Name = "button1";
            button1.Size = new Size(246, 80);
            button1.TabIndex = 16;
            button1.Text = "EmployeesWithPremiaBiggerThan200in2023Vertical";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            //
            // Form1
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1073, 570);
            Controls.Add(button1);
            Controls.Add(employees_with_progress);
            Controls.Add(filterExpression);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tableName2);
            Controls.Add(show_table_data);
            Controls.Add(id);
            Controls.Add(table_name_text_box);
            Controls.Add(table_name_label);
            Controls.Add(save);
            Controls.Add(search_id_holder);
            Controls.Add(find_by_id);
            Controls.Add(show_tables);
            Controls.Add(resultGridView);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)resultGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        private DataGridView resultGridView;
        private Button show_tables;
        private Button find_by_id;
        private TextBox search_id_holder;
        private Button save;
        private Label table_name_label;
        private TextBox table_name_text_box;
        private Label id;
        private Button show_table_data;
        private TextBox tableName2;
        private Label label1;
        private Label label2;
        private TextBox filterExpression;
        private Button employees_with_progress;
        private Button button1;
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DefectDetectionApp
{
    public partial class Form2 : Form
    {
        private DatabaseHelper dbHelper;
        public Form2(List<DataShowFormat> databaseResults, DatabaseHelper dbHelper)
        {
            InitializeComponent();
            InitializeDataGridView(databaseResults);
            this.dbHelper = dbHelper;
        }

        // отображаем все данные в виде data grid
        private void InitializeDataGridView(List<DataShowFormat> data)
        {
            DataGridView dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
                ReadOnly = true,
                DataSource = data,
                AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.LightGray,
                },
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    BackColor = Color.Navy,
                    ForeColor = Color.White,
                },
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 10),
                    BackColor = Color.White,
                    ForeColor = Color.Black,
                    SelectionBackColor = Color.CornflowerBlue,
                    SelectionForeColor = Color.White,
                }
            };

            this.Controls.Add(dataGridView);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StaticGenerator
{
    public partial class frmColumnSelection : Form
    {
        List<string> _columns;
        string _tableName;

        public List<string> SelectedColumns { get; set; } = new List<string>();

        public frmColumnSelection(List<string> columns, string tableName)
        {
            InitializeComponent();
            _columns = columns;
            _tableName = tableName;
        }

        private void frmColumnSelection_Load(object sender, EventArgs e)
        {
            ((ListBox)checkedListBox1).DataSource = _columns;
            btnOK.Enabled = false;
            label1.Text = $"Table {_tableName} does not have a primary key.";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue != CheckState.Checked)
            {
                SelectedColumns.Add(_columns[e.Index]);
                btnOK.Enabled = true;
            }
            else
            {
                SelectedColumns.Remove(_columns[e.Index]);
                btnOK.Enabled = SelectedColumns.Count > 0;
            }
        }
    }
}

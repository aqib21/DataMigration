using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DataMigration
{
    public partial class ReportForm : Form
    {
        SqlConnection conn = null;
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            Refresh_Combobox();
        }
        public void Refresh_Combobox()
        {
            try
            {
                using (conn = DB.GetConnection())
                {
                    SqlCommand cmd = DB.PrepareCommand(conn, "SP_GetMigratedEmployeeData", CommandType.StoredProcedure, -1);
                    using SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    DataRow row = dt.NewRow();
                    row[0] = 0;
                    dt.Rows.InsertAt(row, 0);

                    cmb_EmployeeName.DataSource = dt;
                    cmb_EmployeeName.DisplayMember = "Description";
                    cmb_EmployeeName.ValueMember = "EmployeeID";


                    cmb_EmployeeCode.DataSource = dt;
                    cmb_EmployeeCode.DisplayMember = "EmployeeCode";
                    cmb_EmployeeCode.ValueMember = "EmployeeID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DB.Dispose();
            }

        }

        private void ReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DB.Dispose();
        }

        private void Cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            int.TryParse(comboBox.SelectedValue.ToString(), out int employeeId);

            try
            {
                using (conn = DB.GetConnection())
                {
                    SqlCommand cmd = DB.PrepareCommand(conn, "SP_GetMigratedData", CommandType.StoredProcedure, employeeId);
                    using SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    dataGridView.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DB.Dispose();
            }
        }
    }
}

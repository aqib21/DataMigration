using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Linq;

namespace DataMigration
{
    public partial class MainForm : Form
    {
        SqlConnection conn = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Refresh_Combobox();
        }

        private void Cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex == 0)
            {
                lbl_EmployeeID.Text = "EmployeeID: ";
                btn_Move.Enabled = false;
            }
            else
            {
                lbl_EmployeeID.Text = "EmployeeID: " + comboBox.SelectedValue.ToString();
                btn_Move.Enabled = true;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DB.Dispose();
        }

        private void Btn_Move_Click(object sender, EventArgs e)
        {
            btn_Move.Enabled = false;
            txt_Message.Text = "==============================" + Environment.NewLine + "Starting Mirgration Process";
            backgroundWorker.RunWorkerAsync();
        }

        private void ExecuteProcedure(string procedureName, int employeeId)
        {
            SqlCommand cmd = DB.PrepareCommand(conn, procedureName, CommandType.StoredProcedure, employeeId);
            cmd.ExecuteNonQuery();
            string msg = Convert.ToString(cmd.Parameters["@Message"].Value);
            Action action = () => txt_Message.AppendText(Environment.NewLine + msg);
            txt_Message.Invoke(action);
        }

        private void Refresh_Combobox()
        {
            try
            {
                using (conn = DB.GetConnection())
                {
                    SqlCommand cmd = DB.PrepareCommand(conn, "SP_GetEmployeeData", CommandType.StoredProcedure, -1);
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
                txt_Message.Text = "An error occured: " + ex.Message;
            }
            finally
            {
                DB.Dispose();
            }

        }
        private delegate int GetEmployeeIdDelegate();
        private int GetEmployeeId()
        {
            return int.Parse(cmb_EmployeeCode.SelectedValue.ToString());
        }



        private void BackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Action action = () => int.Parse(cmb_EmployeeCode.SelectedValue.ToString());
            int employeeId = (int)cmb_EmployeeCode.Invoke(new GetEmployeeIdDelegate(GetEmployeeId));

            try
            {
                int progress = 0;
                using (conn = DB.GetConnection())
                {
                    string[] procedures = {
                        "SP_UpdateDocumentSequence",
                        "SP_InsertTransaction",
                        "SP_InsertCustomerPayment",
                        "SP_InsertCustomerUnallocatedPayment",
                        "SP_InsertSalesOrders",
                        "SP_UpdateRemainingAmount",
                        "SP_AddEmployeeToMigratedTable"
                    };

                    foreach (string procedure in procedures)
                    {
                        progress += 100 / procedures.Length;
                        backgroundWorker.ReportProgress(progress);
                        ExecuteProcedure(procedure, employeeId);
                    }
                    progress += 100 - progress;
                    backgroundWorker.ReportProgress(progress);
                }
            }
            catch (Exception ex)
            {
                action = () => txt_Message.AppendText(Environment.NewLine + ex.Message);
                txt_Message.Invoke(action);
            }
            finally
            {
                DB.Dispose();
            }
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (progressBar.Value < 100)
            {
                txt_Message.AppendText(Environment.NewLine + "Error Encountered" + Environment.NewLine + "==============================");
            }
            else
            {
                txt_Message.AppendText(Environment.NewLine + "Process Completed" + Environment.NewLine + "==============================");
            }

            Refresh_Combobox();
            foreach (ReportForm reportForm in Application.OpenForms.OfType<ReportForm>())
            {
                reportForm.Refresh_Combobox();

            }
        }

        private void BackgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == -1)
                progressBar.Maximum = Convert.ToInt32(e.UserState);
            else
                progressBar.Value = e.ProgressPercentage;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!Application.OpenForms.OfType<ReportForm>().Any()){
                ReportForm reportForm = new ReportForm();
                reportForm.Show();
            }
            else
            {
                Application.OpenForms["ReportForm"].BringToFront();
            }
        }
    }
}

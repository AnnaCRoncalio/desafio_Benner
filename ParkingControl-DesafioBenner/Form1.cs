using MySql.Data.MySqlClient;
using System;
using System.Text.RegularExpressions;

namespace ParkingControl_DesafioBenner
{
    public partial class Form1 : Form
    {
        private MySqlConnection connection;
        private string dataSource = "datasource=localhost;username=root;password=admin;database=benner_parking_control";
                
        private Label lb_license_plate;
        private TextBox txt_license_plate;
        private Button btn_insert_license_plate;
        private TextBox txt_result;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txt_start_date;
        private TextBox txt_end_date;
        private TextBox txt_initial_value;
        private TextBox txt_extra_value;
        private Button btn_parameter_price;
        private Splitter splitter1;
        private Button btn_calculate_price;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        { }

        private void label1_Click(object sender, EventArgs e)
        { }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lb_license_plate = new System.Windows.Forms.Label();
            this.txt_license_plate = new System.Windows.Forms.TextBox();
            this.btn_insert_license_plate = new System.Windows.Forms.Button();
            this.btn_calculate_price = new System.Windows.Forms.Button();
            this.txt_result = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_start_date = new System.Windows.Forms.TextBox();
            this.txt_end_date = new System.Windows.Forms.TextBox();
            this.txt_initial_value = new System.Windows.Forms.TextBox();
            this.txt_extra_value = new System.Windows.Forms.TextBox();
            this.btn_parameter_price = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.SuspendLayout();
            // 
            // lb_license_plate
            // 
            this.lb_license_plate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_license_plate.AutoSize = true;
            this.lb_license_plate.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lb_license_plate.Location = new System.Drawing.Point(54, 42);
            this.lb_license_plate.Name = "lb_license_plate";
            this.lb_license_plate.Size = new System.Drawing.Size(138, 23);
            this.lb_license_plate.TabIndex = 0;
            this.lb_license_plate.Text = "Placa do veículo:";
            // 
            // txt_license_plate
            // 
            this.txt_license_plate.Location = new System.Drawing.Point(54, 85);
            this.txt_license_plate.Name = "txt_license_plate";
            this.txt_license_plate.PlaceholderText = "AAA1A11 OU AAA-1111";
            this.txt_license_plate.Size = new System.Drawing.Size(243, 27);
            this.txt_license_plate.TabIndex = 1;
            // 
            // btn_insert_license_plate
            // 
            this.btn_insert_license_plate.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_insert_license_plate.FlatAppearance.BorderSize = 3;
            this.btn_insert_license_plate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_insert_license_plate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_insert_license_plate.Location = new System.Drawing.Point(54, 151);
            this.btn_insert_license_plate.Name = "btn_insert_license_plate";
            this.btn_insert_license_plate.Size = new System.Drawing.Size(111, 29);
            this.btn_insert_license_plate.TabIndex = 2;
            this.btn_insert_license_plate.Text = "Entrada";
            this.btn_insert_license_plate.UseVisualStyleBackColor = true;
            this.btn_insert_license_plate.Click += new System.EventHandler(this.btn_insert_license_plate_Click);
            // 
            // btn_calculate_price
            // 
            this.btn_calculate_price.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_calculate_price.FlatAppearance.BorderSize = 3;
            this.btn_calculate_price.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_calculate_price.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_calculate_price.Location = new System.Drawing.Point(187, 151);
            this.btn_calculate_price.Name = "btn_calculate_price";
            this.btn_calculate_price.Size = new System.Drawing.Size(110, 29);
            this.btn_calculate_price.TabIndex = 3;
            this.btn_calculate_price.Text = "Saída";
            this.btn_calculate_price.UseVisualStyleBackColor = true;
            this.btn_calculate_price.Click += new System.EventHandler(this.btn_calculate_price_Click);
            // 
            // txt_result
            // 
            this.txt_result.Location = new System.Drawing.Point(54, 221);
            this.txt_result.Multiline = true;
            this.txt_result.Name = "txt_result";
            this.txt_result.Size = new System.Drawing.Size(243, 73);
            this.txt_result.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(386, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Data Inicial:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(582, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Data Final:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(386, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Valor da hora inicial:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(582, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Valor da hora extra:";
            // 
            // txt_start_date
            // 
            this.txt_start_date.Location = new System.Drawing.Point(386, 85);
            this.txt_start_date.Name = "txt_start_date";
            this.txt_start_date.PlaceholderText = "AAAA-MM-DD";
            this.txt_start_date.Size = new System.Drawing.Size(161, 27);
            this.txt_start_date.TabIndex = 9;
            // 
            // txt_end_date
            // 
            this.txt_end_date.Location = new System.Drawing.Point(582, 85);
            this.txt_end_date.Name = "txt_end_date";
            this.txt_end_date.PlaceholderText = "AAAA-MM-DD";
            this.txt_end_date.Size = new System.Drawing.Size(160, 27);
            this.txt_end_date.TabIndex = 10;
            // 
            // txt_initial_value
            // 
            this.txt_initial_value.Location = new System.Drawing.Point(386, 221);
            this.txt_initial_value.Name = "txt_initial_value";
            this.txt_initial_value.PlaceholderText = "0.0";
            this.txt_initial_value.Size = new System.Drawing.Size(161, 27);
            this.txt_initial_value.TabIndex = 11;
            // 
            // txt_extra_value
            // 
            this.txt_extra_value.Location = new System.Drawing.Point(582, 221);
            this.txt_extra_value.Name = "txt_extra_value";
            this.txt_extra_value.PlaceholderText = "0.0";
            this.txt_extra_value.Size = new System.Drawing.Size(160, 27);
            this.txt_extra_value.TabIndex = 12;
            // 
            // btn_parameter_price
            // 
            this.btn_parameter_price.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_parameter_price.FlatAppearance.BorderSize = 3;
            this.btn_parameter_price.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_parameter_price.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_parameter_price.Location = new System.Drawing.Point(617, 265);
            this.btn_parameter_price.Name = "btn_parameter_price";
            this.btn_parameter_price.Size = new System.Drawing.Size(125, 29);
            this.btn_parameter_price.TabIndex = 13;
            this.btn_parameter_price.Text = "Inserir";
            this.btn_parameter_price.UseVisualStyleBackColor = true;
            this.btn_parameter_price.Click += new System.EventHandler(this.btn_parameter_price_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 350);
            this.splitter1.TabIndex = 14;
            this.splitter1.TabStop = false;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(774, 350);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.btn_parameter_price);
            this.Controls.Add(this.txt_extra_value);
            this.Controls.Add(this.txt_initial_value);
            this.Controls.Add(this.txt_end_date);
            this.Controls.Add(this.txt_start_date);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_result);
            this.Controls.Add(this.btn_calculate_price);
            this.Controls.Add(this.btn_insert_license_plate);
            this.Controls.Add(this.txt_license_plate);
            this.Controls.Add(this.lb_license_plate);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MaximumSize = new System.Drawing.Size(792, 397);
            this.MinimumSize = new System.Drawing.Size(792, 397);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estacionamento Benner";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btn_insert_license_plate_Click(object sender, EventArgs e)
        {
            var plate = txt_license_plate.Text;

            txt_result.Clear();

            if (!PlateValidate(plate))
            {
                MessageBox.Show("Placa com formato inválido");
                txt_license_plate.Clear();
                return;
            }

            try
            {
                connection = new MySqlConnection(dataSource);              
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                connection.Open();

                string selectSQLPlate = "SELECT * FROM t_parking_control WHERE " +
                                        "license_plate_number = '" + txt_license_plate.Text + "' AND end_datetime IS NULL";

                command.CommandText = selectSQLPlate;
                                
                if (command.ExecuteScalar() != null)
                {
                    MessageBox.Show("Placa já cadastrada e com saída em aberto");
                    txt_license_plate.Clear();
                    txt_result.Clear();
                    return;
                }
                
                command.CommandText = "INSERT INTO t_parking_control (license_plate_number)" +
                                      "VALUES (@license_plate_number)";

                command.Parameters.AddWithValue("@license_plate_number", plate);            

                command.ExecuteReader();

                txt_license_plate.Clear();

                txt_result.Text = "Placa inserida com sucesso!";
                txt_result.TextAlign = HorizontalAlignment.Center;

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } finally
            {
                connection.Close();
            }
        }

        private static bool PlateValidate (string plate)
        {
       
            if (string.IsNullOrWhiteSpace(plate))
            {
                MessageBox.Show("Campo para a placa do veículo não preenchido");
            }

            plate = plate.Replace("-", "").Trim();

            var mercosulStandard = new Regex("[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}");
            var standardPlate = new Regex("[a-zA-Z]{3}[0-9]{4}");

            if (mercosulStandard.IsMatch(plate))
            {
                return true;
                
            }
            else if (standardPlate.IsMatch(plate))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btn_calculate_price_Click(object sender, EventArgs e)
        {

            try
            {
                connection = new MySqlConnection(dataSource);
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                connection.Open();

                string selectSQL = "SELECT * FROM t_parking_control WHERE " +
                                   "license_plate_number = '" + txt_license_plate.Text + "' AND end_datetime IS NULL";

                command.CommandText = selectSQL;

                if(command.ExecuteScalar() == null)
                {
                    MessageBox.Show("Placa sem saida em aberto");
                    txt_license_plate.Clear();
                    txt_result.Clear();
                    return; 
                }

                command.CommandText = "parking_calculate_price";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("p_license_plate", txt_license_plate.Text);

                String outMsg = command.ExecuteScalar().ToString();
                                             
                txt_result.Clear();

                txt_result.WordWrap = true;
                txt_result.Text = txt_license_plate.Text + " - " + DateTime.Now.ToString() + 
                                " - R$ " + outMsg;

                txt_license_plate.Clear();
                             
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } finally
            {
                connection.Close();
            }
        }

        private void btn_parameter_price_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_start_date.Text)) 
            {
                MessageBox.Show("Preencha todos os campos para cadastro");
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_end_date.Text))
            {
                MessageBox.Show("Preencha todos os campos para cadastro");
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_initial_value.Text))
            {
                MessageBox.Show("Preencha todos os campos para cadastro");
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_extra_value.Text))
            {
                MessageBox.Show("Preencha todos os campos para cadastro");
                return;
            }

            try
            {
                connection = new MySqlConnection(dataSource);

                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;

                connection.Open();

                command.CommandText = "INSERT INTO t_ticket_price (start_date, end_date, first_hour_price, extra_hour_price) " +
                                     "VALUES " + "(@start_date, @end_date, @first_hour_price, @extra_hour_price) ";
                
                command.Parameters.AddWithValue("@start_date", txt_start_date.Text);
                command.Parameters.AddWithValue("@end_date", txt_end_date.Text);
                command.Parameters.AddWithValue("@first_hour_price", txt_initial_value.Text);
                command.Parameters.AddWithValue("@extra_hour_price", txt_extra_value.Text);

                command.ExecuteNonQuery();

                MessageBox.Show("Cadastro realizado com sucesso!");

                txt_start_date.Clear();
                txt_end_date.Clear();
                txt_initial_value.Clear();
                txt_extra_value.Clear();

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } finally
            {
                connection.Close();
            }
            
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
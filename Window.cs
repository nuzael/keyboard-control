using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace KeyboardControlApp
{
    public partial class Window : Form
    {
        private Button btnDisable;
        private Button btnEnable;

        public Window()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.btnDisable = new Button();
            this.btnEnable = new Button();

            // 
            // btnDisable
            // 
            this.btnDisable.Location = new System.Drawing.Point(50, 30);
            this.btnDisable.Name = "btnDisable";
            this.btnDisable.Size = new System.Drawing.Size(200, 50);
            this.btnDisable.Text = "Desabilitar Teclado";
            this.btnDisable.UseVisualStyleBackColor = true;
            this.btnDisable.Click += new EventHandler(this.btnDisable_Click);

            // 
            // btnEnable
            // 
            this.btnEnable.Location = new System.Drawing.Point(50, 100);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(200, 50);
            this.btnEnable.Text = "Habilitar Teclado";
            this.btnEnable.UseVisualStyleBackColor = true;
            this.btnEnable.Click += new EventHandler(this.btnEnable_Click);

            // 
            // Window
            // 
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.btnDisable);
            this.Controls.Add(this.btnEnable);
            this.Name = "Window";
            this.Text = "Controle de Teclado";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            if (ExecuteCommand("sc config i8042prt start= disabled"))
            {
                MessageBox.Show("Teclado interno desabilitado. Por favor, reinicie o computador.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Não foi possível desabilitar o teclado interno.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            if (ExecuteCommand("sc config i8042prt start= auto"))
            {
                MessageBox.Show("Teclado interno habilitado. Por favor, reinicie o computador.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Não foi possível habilitar o teclado interno.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ExecuteCommand(string command)
        {
            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.Arguments = $"/C {command}";
                    process.StartInfo.Verb = "runas";
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.UseShellExecute = false;
                    process.Start();

                    process.WaitForExit();

                    return process.ExitCode == 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao executar o comando: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}


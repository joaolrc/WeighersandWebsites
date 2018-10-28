using System;
using System.Net;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using ModbusTCP;

namespace Modbus
{
    public class frmStart : System.Windows.Forms.Form
    {
        private ModbusTCP.Master MBmaster;
        private byte[] data;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.GroupBox grpStart;
        private Button Submitbut;
        private TextBox Line1;
        private Label label5;
        private TextBox Line2;
        private Label label6;
        private TextBox Line3;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label11;
        private Button Startbut;
        private Button Stopbut;
        private GroupBox grpExchange;
        private PictureBox pictureBox1;
        private Label label14;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox total3;
        private TextBox total2;
        private PictureBox pictureBox2;
        private PictureBox pictureBox4;
        private Timer timer1;
        private Button stopbut3;
        private Button startbut3;
        private Button stopbut2;
        private Button startbut2;
        private Label label10;
        private Label label12;
        private Label label13;
        private TextBox now3;
        private TextBox now2;
        private TextBox now1;
        private Label label17;
        private Label label16;
        private TextBox total1;
        private Label label20;
        private Button butconfig;
        private TextBox textm3;
        private TextBox textm2;
        private TextBox textm1;
        private Label label19;
        private Label label18;
        private Button tarebut;
        private Label label15;
        private PictureBox pictureBox3;
        private PictureBox pictureBox7;
        private PictureBox pictureBox6;
        private PictureBox pictureBox5;
        private System.ComponentModel.IContainer components;

        public frmStart()
        {
            InitializeComponent();

            timer1.Interval = 30; // 30000 ms = 5 mins
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code
        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStart));
            this.grpStart = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.Submitbut = new System.Windows.Forms.Button();
            this.Line1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Line2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Line3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Startbut = new System.Windows.Forms.Button();
            this.Stopbut = new System.Windows.Forms.Button();
            this.grpExchange = new System.Windows.Forms.GroupBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tarebut = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.butconfig = new System.Windows.Forms.Button();
            this.textm3 = new System.Windows.Forms.TextBox();
            this.textm2 = new System.Windows.Forms.TextBox();
            this.textm1 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.now3 = new System.Windows.Forms.TextBox();
            this.now2 = new System.Windows.Forms.TextBox();
            this.now1 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.stopbut3 = new System.Windows.Forms.Button();
            this.startbut3 = new System.Windows.Forms.Button();
            this.stopbut2 = new System.Windows.Forms.Button();
            this.startbut2 = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.total3 = new System.Windows.Forms.TextBox();
            this.total2 = new System.Windows.Forms.TextBox();
            this.total1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.grpStart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.grpExchange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpStart
            // 
            this.grpStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpStart.Controls.Add(this.pictureBox2);
            this.grpStart.Controls.Add(this.label1);
            this.grpStart.Controls.Add(this.btnConnect);
            this.grpStart.Controls.Add(this.txtIP);
            this.grpStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpStart.Location = new System.Drawing.Point(8, 8);
            this.grpStart.Name = "grpStart";
            this.grpStart.Size = new System.Drawing.Size(827, 64);
            this.grpStart.TabIndex = 11;
            this.grpStart.TabStop = false;
            this.grpStart.Text = "Iniciar Comunicação";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(738, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(87, 46);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 65;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Endereço IP do Slave:";
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.SystemColors.Info;
            this.btnConnect.Location = new System.Drawing.Point(470, 28);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(104, 27);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Conectar";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(269, 30);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(132, 26);
            this.txtIP.TabIndex = 5;
            this.txtIP.Text = "192.168.1.177";
            this.txtIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Submitbut
            // 
            this.Submitbut.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Submitbut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Submitbut.Location = new System.Drawing.Point(631, 53);
            this.Submitbut.Name = "Submitbut";
            this.Submitbut.Size = new System.Drawing.Size(113, 33);
            this.Submitbut.TabIndex = 39;
            this.Submitbut.Text = "Submeter";
            this.Submitbut.UseVisualStyleBackColor = false;
            this.Submitbut.Click += new System.EventHandler(this.Submitbut_Click);
            // 
            // Line1
            // 
            this.Line1.Location = new System.Drawing.Point(202, 56);
            this.Line1.Name = "Line1";
            this.Line1.Size = new System.Drawing.Size(100, 26);
            this.Line1.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(197, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 29);
            this.label5.TabIndex = 41;
            this.label5.Text = "Linha 1";
            // 
            // Line2
            // 
            this.Line2.Location = new System.Drawing.Point(350, 56);
            this.Line2.Name = "Line2";
            this.Line2.Size = new System.Drawing.Size(100, 26);
            this.Line2.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(346, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 29);
            this.label6.TabIndex = 43;
            this.label6.Text = "Linha 2";
            // 
            // Line3
            // 
            this.Line3.Location = new System.Drawing.Point(494, 56);
            this.Line3.Name = "Line3";
            this.Line3.Size = new System.Drawing.Size(100, 26);
            this.Line3.TabIndex = 44;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(492, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 29);
            this.label7.TabIndex = 45;
            this.label7.Text = "Linha 3";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(303, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 20);
            this.label8.TabIndex = 46;
            this.label8.Text = "g";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(451, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 20);
            this.label9.TabIndex = 47;
            this.label9.Text = "g";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(597, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 20);
            this.label11.TabIndex = 48;
            this.label11.Text = "g";
            // 
            // Startbut
            // 
            this.Startbut.BackColor = System.Drawing.Color.Lime;
            this.Startbut.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.Startbut.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Startbut.ForeColor = System.Drawing.Color.Black;
            this.Startbut.Location = new System.Drawing.Point(187, 164);
            this.Startbut.Name = "Startbut";
            this.Startbut.Size = new System.Drawing.Size(64, 29);
            this.Startbut.TabIndex = 49;
            this.Startbut.Text = "Start1";
            this.Startbut.UseVisualStyleBackColor = false;
            this.Startbut.Click += new System.EventHandler(this.Startbut_Click);
            // 
            // Stopbut
            // 
            this.Stopbut.BackColor = System.Drawing.Color.Red;
            this.Stopbut.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.Stopbut.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stopbut.ForeColor = System.Drawing.Color.Black;
            this.Stopbut.Location = new System.Drawing.Point(248, 164);
            this.Stopbut.Name = "Stopbut";
            this.Stopbut.Size = new System.Drawing.Size(71, 29);
            this.Stopbut.TabIndex = 50;
            this.Stopbut.Text = "Stop1";
            this.Stopbut.UseVisualStyleBackColor = false;
            this.Stopbut.Click += new System.EventHandler(this.Stopbut_Click);
            // 
            // grpExchange
            // 
            this.grpExchange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpExchange.Controls.Add(this.pictureBox7);
            this.grpExchange.Controls.Add(this.pictureBox6);
            this.grpExchange.Controls.Add(this.pictureBox5);
            this.grpExchange.Controls.Add(this.pictureBox3);
            this.grpExchange.Controls.Add(this.label15);
            this.grpExchange.Controls.Add(this.tarebut);
            this.grpExchange.Controls.Add(this.label20);
            this.grpExchange.Controls.Add(this.butconfig);
            this.grpExchange.Controls.Add(this.textm3);
            this.grpExchange.Controls.Add(this.textm2);
            this.grpExchange.Controls.Add(this.textm1);
            this.grpExchange.Controls.Add(this.label19);
            this.grpExchange.Controls.Add(this.label18);
            this.grpExchange.Controls.Add(this.label10);
            this.grpExchange.Controls.Add(this.label12);
            this.grpExchange.Controls.Add(this.label13);
            this.grpExchange.Controls.Add(this.now3);
            this.grpExchange.Controls.Add(this.now2);
            this.grpExchange.Controls.Add(this.now1);
            this.grpExchange.Controls.Add(this.label17);
            this.grpExchange.Controls.Add(this.label16);
            this.grpExchange.Controls.Add(this.stopbut3);
            this.grpExchange.Controls.Add(this.startbut3);
            this.grpExchange.Controls.Add(this.stopbut2);
            this.grpExchange.Controls.Add(this.startbut2);
            this.grpExchange.Controls.Add(this.pictureBox4);
            this.grpExchange.Controls.Add(this.label14);
            this.grpExchange.Controls.Add(this.label2);
            this.grpExchange.Controls.Add(this.label3);
            this.grpExchange.Controls.Add(this.label4);
            this.grpExchange.Controls.Add(this.total3);
            this.grpExchange.Controls.Add(this.total2);
            this.grpExchange.Controls.Add(this.total1);
            this.grpExchange.Controls.Add(this.pictureBox1);
            this.grpExchange.Controls.Add(this.Stopbut);
            this.grpExchange.Controls.Add(this.Startbut);
            this.grpExchange.Controls.Add(this.label11);
            this.grpExchange.Controls.Add(this.label9);
            this.grpExchange.Controls.Add(this.label8);
            this.grpExchange.Controls.Add(this.label7);
            this.grpExchange.Controls.Add(this.Line3);
            this.grpExchange.Controls.Add(this.label6);
            this.grpExchange.Controls.Add(this.Line2);
            this.grpExchange.Controls.Add(this.label5);
            this.grpExchange.Controls.Add(this.Line1);
            this.grpExchange.Controls.Add(this.Submitbut);
            this.grpExchange.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpExchange.Location = new System.Drawing.Point(8, 74);
            this.grpExchange.Name = "grpExchange";
            this.grpExchange.Size = new System.Drawing.Size(827, 431);
            this.grpExchange.TabIndex = 12;
            this.grpExchange.TabStop = false;
            this.grpExchange.Text = "Troca de Informação";
            this.grpExchange.Visible = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(565, 15);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(33, 28);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 89;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::ModbusTester.Properties.Resources.red_led_hi;
            this.pictureBox6.Location = new System.Drawing.Point(420, 15);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(33, 28);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 88;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(270, 15);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(33, 28);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 87;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(756, 338);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(69, 68);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 86;
            this.pictureBox3.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(2, 309);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(1083, 20);
            this.label15.TabIndex = 85;
            this.label15.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "------------------";
            // 
            // tarebut
            // 
            this.tarebut.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tarebut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tarebut.Location = new System.Drawing.Point(631, 164);
            this.tarebut.Name = "tarebut";
            this.tarebut.Size = new System.Drawing.Size(113, 33);
            this.tarebut.TabIndex = 84;
            this.tarebut.Text = "Tare";
            this.tarebut.UseVisualStyleBackColor = false;
            this.tarebut.Click += new System.EventHandler(this.tarebut_Click);
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(6, 330);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(727, 104);
            this.label20.TabIndex = 83;
            this.label20.Text = resources.GetString("label20.Text");
            // 
            // butconfig
            // 
            this.butconfig.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.butconfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butconfig.Location = new System.Drawing.Point(631, 107);
            this.butconfig.Name = "butconfig";
            this.butconfig.Size = new System.Drawing.Size(113, 33);
            this.butconfig.TabIndex = 82;
            this.butconfig.Text = "Configurar";
            this.butconfig.UseVisualStyleBackColor = false;
            this.butconfig.Click += new System.EventHandler(this.butconfig_Click);
            // 
            // textm3
            // 
            this.textm3.Location = new System.Drawing.Point(494, 110);
            this.textm3.Name = "textm3";
            this.textm3.Size = new System.Drawing.Size(100, 26);
            this.textm3.TabIndex = 81;
            // 
            // textm2
            // 
            this.textm2.Location = new System.Drawing.Point(350, 110);
            this.textm2.Name = "textm2";
            this.textm2.Size = new System.Drawing.Size(100, 26);
            this.textm2.TabIndex = 80;
            // 
            // textm1
            // 
            this.textm1.Location = new System.Drawing.Point(202, 110);
            this.textm1.Name = "textm1";
            this.textm1.Size = new System.Drawing.Size(100, 26);
            this.textm1.TabIndex = 79;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(8, 113);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(182, 20);
            this.label19.TabIndex = 78;
            this.label19.Text = "Configurar Declives:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(2, 201);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(1083, 20);
            this.label18.TabIndex = 77;
            this.label18.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------------------------------------------" +
    "------------------";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(598, 287);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 20);
            this.label10.TabIndex = 76;
            this.label10.Text = "g";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(453, 287);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 20);
            this.label12.TabIndex = 75;
            this.label12.Text = "g";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(303, 285);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(18, 20);
            this.label13.TabIndex = 74;
            this.label13.Text = "g";
            // 
            // now3
            // 
            this.now3.Cursor = System.Windows.Forms.Cursors.No;
            this.now3.Location = new System.Drawing.Point(494, 281);
            this.now3.Name = "now3";
            this.now3.ReadOnly = true;
            this.now3.Size = new System.Drawing.Size(100, 26);
            this.now3.TabIndex = 73;
            // 
            // now2
            // 
            this.now2.Cursor = System.Windows.Forms.Cursors.No;
            this.now2.Location = new System.Drawing.Point(350, 282);
            this.now2.Name = "now2";
            this.now2.ReadOnly = true;
            this.now2.Size = new System.Drawing.Size(100, 26);
            this.now2.TabIndex = 72;
            // 
            // now1
            // 
            this.now1.Cursor = System.Windows.Forms.Cursors.No;
            this.now1.Location = new System.Drawing.Point(202, 280);
            this.now1.Name = "now1";
            this.now1.ReadOnly = true;
            this.now1.Size = new System.Drawing.Size(100, 26);
            this.now1.TabIndex = 71;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(8, 59);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(165, 20);
            this.label17.TabIndex = 70;
            this.label17.Text = "Configurar Tolbas:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(8, 283);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(180, 20);
            this.label16.TabIndex = 69;
            this.label16.Text = "Pesos Instantâneos:";
            // 
            // stopbut3
            // 
            this.stopbut3.BackColor = System.Drawing.Color.Red;
            this.stopbut3.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.stopbut3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopbut3.ForeColor = System.Drawing.Color.Black;
            this.stopbut3.Location = new System.Drawing.Point(540, 164);
            this.stopbut3.Name = "stopbut3";
            this.stopbut3.Size = new System.Drawing.Size(63, 29);
            this.stopbut3.TabIndex = 68;
            this.stopbut3.Text = "Stop3";
            this.stopbut3.UseVisualStyleBackColor = false;
            this.stopbut3.Click += new System.EventHandler(this.stopbut3_Click);
            // 
            // startbut3
            // 
            this.startbut3.BackColor = System.Drawing.Color.Lime;
            this.startbut3.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.startbut3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startbut3.ForeColor = System.Drawing.Color.Black;
            this.startbut3.Location = new System.Drawing.Point(482, 164);
            this.startbut3.Name = "startbut3";
            this.startbut3.Size = new System.Drawing.Size(60, 29);
            this.startbut3.TabIndex = 67;
            this.startbut3.Text = "Start3";
            this.startbut3.UseVisualStyleBackColor = false;
            this.startbut3.Click += new System.EventHandler(this.startbut3_Click);
            // 
            // stopbut2
            // 
            this.stopbut2.BackColor = System.Drawing.Color.Red;
            this.stopbut2.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.stopbut2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopbut2.ForeColor = System.Drawing.Color.Black;
            this.stopbut2.Location = new System.Drawing.Point(395, 164);
            this.stopbut2.Name = "stopbut2";
            this.stopbut2.Size = new System.Drawing.Size(68, 29);
            this.stopbut2.TabIndex = 66;
            this.stopbut2.Text = "Stop2";
            this.stopbut2.UseVisualStyleBackColor = false;
            this.stopbut2.Click += new System.EventHandler(this.stopbut2_Click);
            // 
            // startbut2
            // 
            this.startbut2.BackColor = System.Drawing.Color.Lime;
            this.startbut2.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.startbut2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startbut2.ForeColor = System.Drawing.Color.Black;
            this.startbut2.Location = new System.Drawing.Point(337, 164);
            this.startbut2.Name = "startbut2";
            this.startbut2.Size = new System.Drawing.Size(61, 29);
            this.startbut2.TabIndex = 65;
            this.startbut2.Text = "Start2";
            this.startbut2.UseVisualStyleBackColor = false;
            this.startbut2.Click += new System.EventHandler(this.startbut2_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(756, 84);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(69, 68);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 64;
            this.pictureBox4.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(2, 233);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(201, 20);
            this.label14.TabIndex = 60;
            this.label14.Text = " Peso Total Registado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(598, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 20);
            this.label2.TabIndex = 59;
            this.label2.Text = "Kg";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(451, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 20);
            this.label3.TabIndex = 58;
            this.label3.Text = "Kg";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(303, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 20);
            this.label4.TabIndex = 57;
            this.label4.Text = "Kg";
            // 
            // total3
            // 
            this.total3.Cursor = System.Windows.Forms.Cursors.No;
            this.total3.Location = new System.Drawing.Point(494, 230);
            this.total3.Name = "total3";
            this.total3.ReadOnly = true;
            this.total3.Size = new System.Drawing.Size(100, 26);
            this.total3.TabIndex = 55;
            // 
            // total2
            // 
            this.total2.Cursor = System.Windows.Forms.Cursors.No;
            this.total2.Location = new System.Drawing.Point(350, 231);
            this.total2.Name = "total2";
            this.total2.ReadOnly = true;
            this.total2.Size = new System.Drawing.Size(100, 26);
            this.total2.TabIndex = 53;
            // 
            // total1
            // 
            this.total1.Cursor = System.Windows.Forms.Cursors.No;
            this.total1.Location = new System.Drawing.Point(202, 229);
            this.total1.Name = "total1";
            this.total1.ReadOnly = true;
            this.total1.Size = new System.Drawing.Size(100, 26);
            this.total1.TabIndex = 51;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(756, 236);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(69, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmStart
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(836, 489);
            this.Controls.Add(this.grpExchange);
            this.Controls.Add(this.grpStart);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesadora ModBus IP";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmStart_Closing);
            this.Load += new System.EventHandler(this.frmStart_Load);
            this.grpStart.ResumeLayout(false);
            this.grpStart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.grpExchange.ResumeLayout(false);
            this.grpExchange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new frmStart());
        }


        // ------------------------------------------------------------------------
        // Programm start
        // ------------------------------------------------------------------------
        private void frmStart_Load(object sender, System.EventArgs e)
        {

        }

        // ------------------------------------------------------------------------
        // Programm stop
        // ------------------------------------------------------------------------
        private void frmStart_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MBmaster != null)
            {
                MBmaster.Dispose();
                MBmaster = null;
            }
            Application.Exit();
        }

        // ------------------------------------------------------------------------
        // Button connect
        // ------------------------------------------------------------------------
        private void btnConnect_Click(object sender, System.EventArgs e)
        {
            try
            {
                // Create new modbus master and add event functions
                MBmaster = new Master(txtIP.Text, 502, true);
                MBmaster.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponseData);
                MBmaster.OnException += new ModbusTCP.Master.ExceptionData(MBmaster_OnException);
                // Show additional fields, enable watchdog
                grpExchange.Visible = true;
            }
            catch (SystemException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        // ------------------------------------------------------------------------
        // Event for response data
        // ------------------------------------------------------------------------
        private void MBmaster_OnResponseData(ushort ID, byte unit, byte function, byte[] values)
        {
            // ------------------------------------------------------------------
            // Seperate calling threads
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Master.ResponseData(MBmaster_OnResponseData), new object[] { ID, unit, function, values });
                return;
            }

            // ------------------------------------------------------------------------
            // Identify requested data
            switch (ID)
            {
                case 3:
                    //grpData.Text = "Read holding register";
                    data = values;
                    // System.Diagnostics.Debug.WriteLine("data..: " + Convert.ToInt16(data[1])+" "+data[2]+" " + Convert.ToString(data[3]));
                    ShowAs(null, null);
                    break;
            }
        }

        // ------------------------------------------------------------------------
        // Modbus TCP slave exception
        // ------------------------------------------------------------------------
        private void MBmaster_OnException(ushort id, byte unit, byte function, byte exception)
        {
            string exc = "Modbus says error: ";
            switch (exception)
            {
                case Master.excIllegalFunction: exc += "Illegal function!"; break;
                case Master.excIllegalDataAdr: exc += "Illegal data adress!"; break;
                case Master.excIllegalDataVal: exc += "Illegal data value!"; break;
                case Master.excSlaveDeviceFailure: exc += "Slave device failure!"; break;
                case Master.excAck: exc += "Acknoledge!"; break;
                case Master.excGatePathUnavailable: exc += "Gateway path unavailbale!"; break;
                case Master.excExceptionTimeout: exc += "Slave timed out!"; break;
                case Master.excExceptionConnectionLost: exc += "Connection is lost!"; break;
                case Master.excExceptionNotConnected: exc += "Not connected!"; break;
            }

            MessageBox.Show(exc, "Modbus slave exception");
        }

        // ------------------------------------------------------------------------
        // Show values in selected way
        // ------------------------------------------------------------------------
        private void ShowAs(object sender, System.EventArgs e)
        {
            bool[] bits = new bool[1];
            int[] word = new int[1];

            if (data.Length < 2) return;
            int length = data.Length / 2 + Convert.ToInt16(data.Length % 2 > 0);
            word = new int[length];

            for (int x = 0; x < length; x = x + 2)
            {
                word[x / 2] = data[x] * 256 + data[x + 1];
            }
            //System.Diagnostics.Debug.WriteLine("data..: " + data[4] * 256 + data[4 + 1] + " " + Convert.ToString(data[4] * 256 + data[4 + 1]));
            total1.Text = word[0].ToString();
            total2.Text = word[1].ToString();
            total3.Text = Convert.ToString(data[4] * 256 + data[4 + 1]);

            now1.Text = Convert.ToString(data[6] * 256 + data[6 + 1]);
            now2.Text = Convert.ToString(data[8] * 256 + data[8 + 1]);
            now3.Text = Convert.ToString(data[10] * 256 + data[10 + 1]);

        }

        private void Submitbut_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)  //carregar multiplas vezes
            {
                //System.Diagnostics.Debug.WriteLine("ola");
                ushort ID = 7;
                byte unit = Convert.ToByte("0");  //byte unit = Convert.ToByte(txtUnit.Text);
                UInt16 StartAddress = 11;  //Posiçao de memoria da Tolba 1
                UInt16 StartAddress2 = 12; //Posiçao de memoria da Tolba 2
                UInt16 StartAddress3 = 13; //Posiçao de memoria da Tolba 3
                int num = 2;

                //UInt32 number1 = Convert.ToUInt32(Line1.Text);
                // UInt32 number2 = Convert.ToUInt32(Line2.Text);
                // UInt32 number3 = Convert.ToUInt32(Line3.Text);
                if (string.IsNullOrEmpty(Line1.Text) == false)
                {
                    try
                    {
                        UInt32 number1 = Convert.ToUInt32(Line1.Text);
                        if (number1 < UInt16.MaxValue)
                        {
                            //getdata(2)...1
                            int[] word = new int[2];
                            // int num = 2;
                            // int x = Convert.ToInt16(ctrl.Tag);
                            try { word[0] = Convert.ToInt16(Line1.Text); }
                            catch (SystemException) { word[0] = Convert.ToUInt16(Line1.Text); };
                            data = new Byte[num * 2];
                            for (int x = 0; x < num; x++)
                            {
                                byte[] dat = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)word[x]));
                                data[x * 2] = dat[0];
                                data[x * 2 + 1] = dat[1];
                            }
                            //getdata(2)...1
                            MBmaster.WriteSingleRegister(ID, unit, StartAddress, data);
                        }
                        else
                        {
                            MessageBox.Show("Valor da linha 1 demasiado grande!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Line1.Text = "";
                        }
                    }

                    catch
                    {
                        MessageBox.Show("Valor inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Line1.Text = "";
                    }
                    System.Threading.Thread.Sleep(100);
                }
                if (string.IsNullOrEmpty(Line2.Text) == false)
                {
                    try
                    {
                        UInt32 number2 = Convert.ToUInt32(Line2.Text);
                        if (number2 < UInt16.MaxValue)
                        {
                            //getdata(2)...2
                            int[] word2 = new int[2];
                            try { word2[0] = Convert.ToInt16(Line2.Text); }
                            catch (SystemException) { word2[0] = Convert.ToUInt16(Line2.Text); };
                            data = new Byte[num * 2];
                            for (int x = 0; x < num; x++)
                            {
                                byte[] dat = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)word2[x]));
                                data[x * 2] = dat[0];
                                data[x * 2 + 1] = dat[1];
                            }
                            //getdata(2)...2
                            MBmaster.WriteSingleRegister(ID, unit, StartAddress2, data);
                        }
                        else
                        {
                            MessageBox.Show("Valor da linha 2 demasiado grande!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Line2.Text = "";
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Valor inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Line2.Text = "";
                    }
                }
                System.Threading.Thread.Sleep(100);
                if (string.IsNullOrEmpty(Line3.Text) == false)
                {
                    try
                    {
                        UInt32 number3 = Convert.ToUInt32(Line3.Text);
                        if (number3 < UInt16.MaxValue)
                        {
                            //getdata(2)...3
                            int[] word3 = new int[2];
                            try { word3[0] = Convert.ToInt16(Line3.Text); }
                            catch (SystemException) { word3[0] = Convert.ToUInt16(Line3.Text); };
                            data = new Byte[num * 2];
                            for (int x = 0; x < num; x++)
                            {
                                byte[] dat = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)word3[x]));
                                data[x * 2] = dat[0];
                                data[x * 2 + 1] = dat[1];
                            }
                            //getdata(2)...3
                            MBmaster.WriteSingleRegister(ID, unit, StartAddress3, data);
                        }
                        else
                        {
                            MessageBox.Show("Valor da linha 3 demasiado grande!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Line3.Text = "";
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Valor inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Line3.Text = "";
                    }
                }
                System.Threading.Thread.Sleep(50);
            }
        }

        private void Startbut_Click(object sender, EventArgs e) //start linha 1
        {
            this.pictureBox5.Load("led-green-black.png");
            bool ON = true;
            ushort ID = 5;
            byte unit = Convert.ToByte("0"); 
            UInt16 StartAddress = 2;  //Posiçao de memoria Start/Stop
            for (int i = 0; i < 5; i++)  //carregar multiplas vezes
            {
                MBmaster.WriteSingleCoils(ID, unit, StartAddress, ON);
                System.Threading.Thread.Sleep(100);
            }
        }

        private void Stopbut_Click(object sender, EventArgs e)
        {
            pictureBox5.Load("red-led-hi.png");
            bool OFF = false;
            ushort ID = 5;
            byte unit = Convert.ToByte("0");  //byte unit = Convert.ToByte(txtUnit.Text);
            UInt16 StartAddress = 2;     //Posiçao de memoria Start/Stop
            for (int i = 0; i < 5; i++)  //carregar multiplas vezes
            {
                MBmaster.WriteSingleCoils(ID, unit, StartAddress, OFF);
                System.Threading.Thread.Sleep(100);
            }          
        }

        private void button1_Click(object sender, EventArgs e)      //Read Holding registers (atualizar valores)
        {
            ushort ID = 3;
            byte unit = Convert.ToByte("0");
            ushort StartAddress = 51;  //Posiçao de memoria do registo da Tolba 1
            UInt16 Length = Convert.ToUInt16("6");
            MBmaster.ReadHoldingRegister(ID, unit, StartAddress, Length); //atualizar valores de peso total registado                                                                         
        }

        private void timer1_Tick(object sender, EventArgs e) //atualizar periodicamente as quantidades pesadas
        {
            if (grpExchange.Visible)
            {
                //System.Diagnostics.Debug.WriteLine(DateTime.Now.ToString());
                button1_Click(sender, e);
            }
        }

        private void startbut2_Click(object sender, EventArgs e)
        {
            this.pictureBox6.Load("led-green-black.png");
            bool ON = true;
            ushort ID = 5;
            byte unit = Convert.ToByte("0");  //byte unit = Convert.ToByte(txtUnit.Text);
            UInt16 StartAddress = 3;  //Posiçao de memoria Start/Stop linha 2
            for (int i = 0; i < 3; i++)  //carregar multiplas vezes
            {
                MBmaster.WriteSingleCoils(ID, unit, StartAddress, ON);
                System.Threading.Thread.Sleep(100);
            }
        }

        private void stopbut2_Click(object sender, EventArgs e)
        {
            pictureBox6.Load("red-led-hi.png");
            bool OFF = false;
            ushort ID = 5;
            byte unit = Convert.ToByte("0");  //byte unit = Convert.ToByte(txtUnit.Text);
            UInt16 StartAddress = 3;  //Posiçao de memoria Start/Stop linha 2
            for (int i = 0; i < 3; i++)  //carregar multiplas vezes
            {
                MBmaster.WriteSingleCoils(ID, unit, StartAddress, OFF);
                System.Threading.Thread.Sleep(100);
            }
        }

        private void startbut3_Click(object sender, EventArgs e)
        {
            this.pictureBox7.Load("led-green-black.png");
            bool ON = true;
            ushort ID = 5;
            byte unit = Convert.ToByte("0");  //byte unit = Convert.ToByte(txtUnit.Text);
            UInt16 StartAddress = 4;  //Posiçao de memoria Start/Stop
            for (int i = 0; i < 3; i++)  //carregar multiplas vezes
            {
                MBmaster.WriteSingleCoils(ID, unit, StartAddress, ON);
                System.Threading.Thread.Sleep(100);
            }
        }

        private void stopbut3_Click(object sender, EventArgs e)
        {
            pictureBox7.Load("red-led-hi.png");
            bool OFF = false;
            ushort ID = 5;
            byte unit = Convert.ToByte("0");  //byte unit = Convert.ToByte(txtUnit.Text);
            UInt16 StartAddress = 4;  //Posiçao de memoria Start/Stop
            for (int i = 0; i < 3; i++)  //carregar multiplas vezes
            {
                MBmaster.WriteSingleCoils(ID, unit, StartAddress, OFF);
                System.Threading.Thread.Sleep(100);
            }
        }

        private void butconfig_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)  //carregar multiplas vezes
            {
                //System.Diagnostics.Debug.WriteLine("ola");
                ushort ID = 7;
                byte unit = Convert.ToByte("0");  //byte unit = Convert.ToByte(txtUnit.Text);
                UInt16 StartAddress = 101;  //Posiçao de memoria da Tolba 1
                UInt16 StartAddress2 = 102; //Posiçao de memoria da Tolba 2
                UInt16 StartAddress3 = 103; //Posiçao de memoria da Tolba 3
                int num = 2;

                //UInt32 number1 = Convert.ToUInt32(Line1.Text);
                // UInt32 number2 = Convert.ToUInt32(Line2.Text);
                // UInt32 number3 = Convert.ToUInt32(Line3.Text);
                if (string.IsNullOrEmpty(textm1.Text) == false)
                {
                    try
                    {
                        UInt32 number1 = Convert.ToUInt32(textm1.Text);
                        if (number1 < UInt16.MaxValue)
                        {
                            //getdata(2)...1
                            int[] word = new int[2];
                            // int num = 2;
                            // int x = Convert.ToInt16(ctrl.Tag);
                            try { word[0] = Convert.ToInt16(textm1.Text); }
                            catch (SystemException) { word[0] = Convert.ToUInt16(textm1.Text); };
                            data = new Byte[num * 2];
                            for (int x = 0; x < num; x++)
                            {
                                byte[] dat = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)word[x]));
                                data[x * 2] = dat[0];
                                data[x * 2 + 1] = dat[1];
                            }
                            //getdata(2)...1
                            MBmaster.WriteSingleRegister(ID, unit, StartAddress, data);
                        }
                        else
                        {
                            MessageBox.Show("Declive 1 demasiado grande!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textm1.Text = "";
                        }
                    }

                    catch
                    {
                        MessageBox.Show("Declive inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textm1.Text = "";
                    }
                    System.Threading.Thread.Sleep(100);
                }
                if (string.IsNullOrEmpty(textm2.Text) == false)
                {
                    try
                    {
                        UInt32 number2 = Convert.ToUInt32(textm2.Text);
                        if (number2 < UInt16.MaxValue)
                        {
                            //getdata(2)...2
                            int[] word2 = new int[2];
                            try { word2[0] = Convert.ToInt16(textm2.Text); }
                            catch (SystemException) { word2[0] = Convert.ToUInt16(textm2.Text); };
                            data = new Byte[num * 2];
                            for (int x = 0; x < num; x++)
                            {
                                byte[] dat = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)word2[x]));
                                data[x * 2] = dat[0];
                                data[x * 2 + 1] = dat[1];
                            }
                            //getdata(2)...2
                            MBmaster.WriteSingleRegister(ID, unit, StartAddress2, data);
                        }
                        else
                        {
                            MessageBox.Show("Declive 2 demasiado grande!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textm2.Text = "";
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Declive inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textm2.Text = "";
                    }
                }
                System.Threading.Thread.Sleep(100);
                if (string.IsNullOrEmpty(textm3.Text) == false)
                {
                    try
                    {
                        UInt32 number3 = Convert.ToUInt32(textm3.Text);
                        if (number3 < UInt16.MaxValue)
                        {
                            //getdata(2)...3
                            int[] word3 = new int[2];
                            try { word3[0] = Convert.ToInt16(textm3.Text); }
                            catch (SystemException) { word3[0] = Convert.ToUInt16(textm3.Text); };
                            data = new Byte[num * 2];
                            for (int x = 0; x < num; x++)
                            {
                                byte[] dat = BitConverter.GetBytes((short)IPAddress.HostToNetworkOrder((short)word3[x]));
                                data[x * 2] = dat[0];
                                data[x * 2 + 1] = dat[1];
                            }
                            //getdata(2)...3
                            MBmaster.WriteSingleRegister(ID, unit, StartAddress3, data);
                        }
                        else
                        {
                            MessageBox.Show("Declive 3 demasiado grande!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textm3.Text = "";
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Declive inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textm3.Text = "";
                    }
                }
                System.Threading.Thread.Sleep(50);
            }
        }

        private void tarebut_Click(object sender, EventArgs e)
        {
            bool ON = true;
            ushort ID = 5;
            byte unit = Convert.ToByte("0");  //byte unit = Convert.ToByte(txtUnit.Text);
            UInt16 StartAddress = 100;  //Posiçao de memoria Start/Stop
            for (int i = 0; i < 2; i++)  //carregar multiplas vezes
            {
                MBmaster.WriteSingleCoils(ID, unit, StartAddress, ON);
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}

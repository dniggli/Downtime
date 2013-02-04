namespace downtimeC
{
    partial class AliquotForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ComboBoxprinter = new System.Windows.Forms.ComboBox();
            this.Label31 = new System.Windows.Forms.Label();
            this.printdem = new System.Windows.Forms.Button();
            this.Label30 = new System.Windows.Forms.Label();
            this.Label29 = new System.Windows.Forms.Label();
            this.Label28 = new System.Windows.Forms.Label();
            this.ordertechid = new System.Windows.Forms.TextBox();
            this.Label27 = new System.Windows.Forms.Label();
            this.colldate = new downtimeC.StoredTextBox();
            this.DateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Label26 = new System.Windows.Forms.Label();
            this.Label24 = new System.Windows.Forms.Label();
            this.Label23 = new System.Windows.Forms.Label();
            this.Label22 = new System.Windows.Forms.Label();
            this.buttonRead = new System.Windows.Forms.Button();
            this.Label25 = new System.Windows.Forms.Label();
            this.ButtonPrint = new System.Windows.Forms.Button();
            this.Label21 = new System.Windows.Forms.Label();
            this.cal1 = new downtimeC.StoredTextBox();
            this.Label20 = new System.Windows.Forms.Label();
            this.problem = new downtimeC.StoredTextBox();
            this.Label19 = new System.Windows.Forms.Label();
            this.Label18 = new System.Windows.Forms.Label();
            this.Label17 = new System.Windows.Forms.Label();
            this.Label16 = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.DOB = new downtimeC.StoredTextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.mrn = new downtimeC.StoredTextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.priority = new downtimeC.StoredTextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.locationTextBox = new downtimeC.StoredTextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.receivetime = new downtimeC.StoredTextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.lastname = new downtimeC.StoredTextBox();
            this.ButtonWrite = new System.Windows.Forms.Button();
            this.Buttonpopulate = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.firstname = new downtimeC.StoredTextBox();
            this.ordernumber = new downtimeC.StoredTextBox();
            this.OTHERBOX = new downtimeC.TubeTypeTextBox();
            this.Viralloadbox = new downtimeC.TubeTypeTextBox();
            this.fluidbox = new downtimeC.TubeTypeTextBox();
            this.csfbox = new downtimeC.TubeTypeTextBox();
            this.sendout = new downtimeC.TubeTypeTextBox();
            this.ser = new downtimeC.TubeTypeTextBox();
            this.hepp = new downtimeC.TubeTypeTextBox();
            this.comment = new downtimeC.TubeTypeTextBox();
            this.bloodgas = new downtimeC.TubeTypeTextBox();
            this.urinechem = new downtimeC.TubeTypeTextBox();
            this.urinehem = new downtimeC.TubeTypeTextBox();
            this.graytest = new downtimeC.TubeTypeTextBox();
            this.lavchemtest = new downtimeC.TubeTypeTextBox();
            this.greentest = new downtimeC.TubeTypeTextBox();
            this.lavhemtest = new downtimeC.TubeTypeTextBox();
            this.bluetest = new downtimeC.TubeTypeTextBox();
            this.redtest = new downtimeC.TubeTypeTextBox();
            this.collectiontime = new downtimeC.TubeTypeTextBox();
            this.SuspendLayout();
            // 
            // ComboBoxprinter
            // 
            this.ComboBoxprinter.FormattingEnabled = true;
            this.ComboBoxprinter.Location = new System.Drawing.Point(756, 325);
            this.ComboBoxprinter.Name = "ComboBoxprinter";
            this.ComboBoxprinter.Size = new System.Drawing.Size(121, 21);
            this.ComboBoxprinter.TabIndex = 196;
            this.ComboBoxprinter.SelectedIndexChanged += new System.EventHandler(this.ComboBoxprinter_SelectedIndexChanged);
            this.ComboBoxprinter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ComboBoxprinter_KeyPress);
            // 
            // Label31
            // 
            this.Label31.AutoSize = true;
            this.Label31.Location = new System.Drawing.Point(394, 489);
            this.Label31.Name = "Label31";
            this.Label31.Size = new System.Drawing.Size(33, 13);
            this.Label31.TabIndex = 194;
            this.Label31.Text = "Other";
            // 
            // printdem
            // 
            this.printdem.Location = new System.Drawing.Point(727, 398);
            this.printdem.Name = "printdem";
            this.printdem.Size = new System.Drawing.Size(206, 23);
            this.printdem.TabIndex = 193;
            this.printdem.Text = "Print Demographic Labels";
            this.printdem.UseVisualStyleBackColor = true;
            this.printdem.Click += new System.EventHandler(this.printdem_Click);
            // 
            // Label30
            // 
            this.Label30.AutoSize = true;
            this.Label30.Location = new System.Drawing.Point(391, 439);
            this.Label30.Name = "Label30";
            this.Label30.Size = new System.Drawing.Size(78, 13);
            this.Label30.TabIndex = 192;
            this.Label30.Text = "Viral Load Test";
            // 
            // Label29
            // 
            this.Label29.AutoSize = true;
            this.Label29.Location = new System.Drawing.Point(391, 378);
            this.Label29.Name = "Label29";
            this.Label29.Size = new System.Drawing.Size(53, 13);
            this.Label29.TabIndex = 191;
            this.Label29.Text = "Fluid Test";
            // 
            // Label28
            // 
            this.Label28.AutoSize = true;
            this.Label28.Location = new System.Drawing.Point(391, 321);
            this.Label28.Name = "Label28";
            this.Label28.Size = new System.Drawing.Size(51, 13);
            this.Label28.TabIndex = 190;
            this.Label28.Text = "CSF Test";
            // 
            // ordertechid
            // 
            this.ordertechid.Enabled = false;
            this.ordertechid.Location = new System.Drawing.Point(872, 741);
            this.ordertechid.Name = "ordertechid";
            this.ordertechid.Size = new System.Drawing.Size(113, 20);
            this.ordertechid.TabIndex = 189;
            // 
            // Label27
            // 
            this.Label27.AutoSize = true;
            this.Label27.Location = new System.Drawing.Point(910, 724);
            this.Label27.Name = "Label27";
            this.Label27.Size = new System.Drawing.Size(46, 13);
            this.Label27.TabIndex = 188;
            this.Label27.Text = "Tech ID";
            // 
            // colldate
            // 
            this.colldate.DataColumnName = "";
            this.colldate.Location = new System.Drawing.Point(810, 557);
            this.colldate.Name = "colldate";
            this.colldate.Size = new System.Drawing.Size(135, 20);
            this.colldate.TabIndex = 187;
            this.colldate.Visible = false;
            // 
            // DateTimePicker1
            // 
            this.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateTimePicker1.Location = new System.Drawing.Point(756, 29);
            this.DateTimePicker1.Name = "DateTimePicker1";
            this.DateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.DateTimePicker1.TabIndex = 186;
            // 
            // Label26
            // 
            this.Label26.AutoSize = true;
            this.Label26.Location = new System.Drawing.Point(753, 10);
            this.Label26.Name = "Label26";
            this.Label26.Size = new System.Drawing.Size(68, 13);
            this.Label26.TabIndex = 185;
            this.Label26.Text = "Todays Date";
            // 
            // Label24
            // 
            this.Label24.AutoSize = true;
            this.Label24.Location = new System.Drawing.Point(395, 266);
            this.Label24.Name = "Label24";
            this.Label24.Size = new System.Drawing.Size(71, 13);
            this.Label24.TabIndex = 184;
            this.Label24.Text = "Sendout Test";
            // 
            // Label23
            // 
            this.Label23.AutoSize = true;
            this.Label23.Location = new System.Drawing.Point(394, 208);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(72, 13);
            this.Label23.TabIndex = 183;
            this.Label23.Text = "Serology Test";
            // 
            // Label22
            // 
            this.Label22.AutoSize = true;
            this.Label22.Location = new System.Drawing.Point(391, 154);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(72, 13);
            this.Label22.TabIndex = 182;
            this.Label22.Text = "Hepatitis Test";
            // 
            // buttonRead
            // 
            this.buttonRead.Location = new System.Drawing.Point(791, 66);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(75, 23);
            this.buttonRead.TabIndex = 181;
            this.buttonRead.Text = "Read";
            this.buttonRead.UseVisualStyleBackColor = true;
            this.buttonRead.Visible = false;
            this.buttonRead.Click += new System.EventHandler(this.read_click);
            // 
            // Label25
            // 
            this.Label25.AutoSize = true;
            this.Label25.Location = new System.Drawing.Point(788, 309);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(55, 13);
            this.Label25.TabIndex = 180;
            this.Label25.Text = "PRINTER";
            // 
            // ButtonPrint
            // 
            this.ButtonPrint.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.ButtonPrint.Location = new System.Drawing.Point(853, 155);
            this.ButtonPrint.Name = "ButtonPrint";
            this.ButtonPrint.Size = new System.Drawing.Size(80, 23);
            this.ButtonPrint.TabIndex = 179;
            this.ButtonPrint.Text = "Print1";
            this.ButtonPrint.UseVisualStyleBackColor = true;
            this.ButtonPrint.Visible = false;
            // 
            // Label21
            // 
            this.Label21.AutoSize = true;
            this.Label21.Location = new System.Drawing.Point(378, 717);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(50, 13);
            this.Label21.TabIndex = 169;
            this.Label21.Text = "comment";
            // 
            // cal1
            // 
            this.cal1.DataColumnName = "";
            this.cal1.Location = new System.Drawing.Point(381, 669);
            this.cal1.Name = "cal1";
            this.cal1.Size = new System.Drawing.Size(138, 20);
            this.cal1.TabIndex = 175;
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.Location = new System.Drawing.Point(387, 653);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(23, 13);
            this.Label20.TabIndex = 167;
            this.Label20.Text = "call";
            // 
            // problem
            // 
            this.problem.DataColumnName = "";
            this.problem.Location = new System.Drawing.Point(381, 600);
            this.problem.Name = "problem";
            this.problem.Size = new System.Drawing.Size(190, 20);
            this.problem.TabIndex = 174;
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Location = new System.Drawing.Point(378, 584);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(44, 13);
            this.Label19.TabIndex = 165;
            this.Label19.Text = "problem";
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.Location = new System.Drawing.Point(403, 101);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(53, 13);
            this.Label18.TabIndex = 163;
            this.Label18.Text = "blood gas";
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Location = new System.Drawing.Point(400, 59);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(59, 13);
            this.Label17.TabIndex = 161;
            this.Label17.Text = "urine chem";
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Location = new System.Drawing.Point(397, 13);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(53, 13);
            this.Label16.TabIndex = 159;
            this.Label16.Text = "urine hem";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(17, 724);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(47, 13);
            this.Label15.TabIndex = 157;
            this.Label15.Text = "gray test";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(14, 675);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(70, 13);
            this.Label14.TabIndex = 155;
            this.Label14.Text = "lav chem test";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(17, 621);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(54, 13);
            this.Label13.TabIndex = 153;
            this.Label13.Text = "green test";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(23, 576);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(64, 13);
            this.Label12.TabIndex = 151;
            this.Label12.Text = "lav hem test";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(20, 523);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(47, 13);
            this.Label11.TabIndex = 149;
            this.Label11.Text = "blue test";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(17, 466);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(39, 13);
            this.Label10.TabIndex = 147;
            this.Label10.Text = "redtest";
            // 
            // DOB
            // 
            this.DOB.DataColumnName = "dob";
            this.DOB.Location = new System.Drawing.Point(15, 424);
            this.DOB.MaxLength = 10;
            this.DOB.Name = "DOB";
            this.DOB.Size = new System.Drawing.Size(129, 20);
            this.DOB.TabIndex = 146;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(17, 408);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(30, 13);
            this.Label9.TabIndex = 145;
            this.Label9.Text = "DOB";
            // 
            // mrn
            // 
            this.mrn.DataColumnName = "mrn";
            this.mrn.Location = new System.Drawing.Point(17, 371);
            this.mrn.Name = "mrn";
            this.mrn.Size = new System.Drawing.Size(223, 20);
            this.mrn.TabIndex = 144;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(14, 355);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(24, 13);
            this.Label8.TabIndex = 143;
            this.Label8.Text = "mrn";
            // 
            // priority
            // 
            this.priority.DataColumnName = "priority";
            this.priority.Location = new System.Drawing.Point(14, 316);
            this.priority.MaxLength = 1;
            this.priority.Name = "priority";
            this.priority.Size = new System.Drawing.Size(33, 20);
            this.priority.TabIndex = 142;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(14, 300);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(37, 13);
            this.Label7.TabIndex = 141;
            this.Label7.Text = "priority";
            // 
            // locationTextBox
            // 
            this.locationTextBox.DataColumnName = "location";
            this.locationTextBox.Location = new System.Drawing.Point(17, 256);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(223, 20);
            this.locationTextBox.TabIndex = 140;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(14, 240);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(44, 13);
            this.Label6.TabIndex = 139;
            this.Label6.Text = "location";
            // 
            // receivetime
            // 
            this.receivetime.DataColumnName = "receivetime";
            this.receivetime.Location = new System.Drawing.Point(14, 195);
            this.receivetime.Name = "receivetime";
            this.receivetime.Size = new System.Drawing.Size(226, 20);
            this.receivetime.TabIndex = 138;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(11, 179);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(64, 13);
            this.Label5.TabIndex = 137;
            this.Label5.Text = "receive time";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(11, 136);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(74, 13);
            this.Label4.TabIndex = 135;
            this.Label4.Text = "collection time";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(11, 53);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(52, 13);
            this.Label3.TabIndex = 134;
            this.Label3.Text = "last name";
            // 
            // lastname
            // 
            this.lastname.DataColumnName = "lastname";
            this.lastname.Location = new System.Drawing.Point(14, 69);
            this.lastname.Name = "lastname";
            this.lastname.Size = new System.Drawing.Size(226, 20);
            this.lastname.TabIndex = 130;
            // 
            // ButtonWrite
            // 
            this.ButtonWrite.Location = new System.Drawing.Point(727, 355);
            this.ButtonWrite.Name = "ButtonWrite";
            this.ButtonWrite.Size = new System.Drawing.Size(206, 23);
            this.ButtonWrite.TabIndex = 177;
            this.ButtonWrite.Text = "Print All Labels";
            this.ButtonWrite.UseVisualStyleBackColor = true;
            this.ButtonWrite.Click += new System.EventHandler(this.ButtonWrite_Click);
            // 
            // Buttonpopulate
            // 
            this.Buttonpopulate.BackColor = System.Drawing.SystemColors.Control;
            this.Buttonpopulate.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.Buttonpopulate.Location = new System.Drawing.Point(753, 153);
            this.Buttonpopulate.Name = "Buttonpopulate";
            this.Buttonpopulate.Size = new System.Drawing.Size(72, 25);
            this.Buttonpopulate.TabIndex = 178;
            this.Buttonpopulate.Text = "fill boxes";
            this.Buttonpopulate.UseVisualStyleBackColor = true;
            this.Buttonpopulate.Visible = false;
            this.Buttonpopulate.Click += new System.EventHandler(this.ButtonRead_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(8, 97);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(57, 13);
            this.Label2.TabIndex = 132;
            this.Label2.Text = "First Name";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(11, 14);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(41, 13);
            this.Label1.TabIndex = 131;
            this.Label1.Text = "order #";
            // 
            // firstname
            // 
            this.firstname.DataColumnName = "firstname";
            this.firstname.Location = new System.Drawing.Point(14, 113);
            this.firstname.Name = "firstname";
            this.firstname.Size = new System.Drawing.Size(223, 20);
            this.firstname.TabIndex = 133;
            // 
            // ordernumber
            // 
            this.ordernumber.DataColumnName = "ordernumber";
            this.ordernumber.Location = new System.Drawing.Point(14, 30);
            this.ordernumber.MaxLength = 8;
            this.ordernumber.Name = "ordernumber";
            this.ordernumber.Size = new System.Drawing.Size(226, 20);
            this.ordernumber.TabIndex = 129;
            this.ordernumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ordernumber_KeyUp);
            // 
            // OTHERBOX
            // 
            this.OTHERBOX.DataColumnName = "OTHERTEST";
            this.OTHERBOX.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.OTHERBOX.Location = new System.Drawing.Point(394, 506);
            this.OTHERBOX.Name = "OTHERBOX";
            this.OTHERBOX.Size = new System.Drawing.Size(272, 20);
            this.OTHERBOX.SpecimenExtension = "";
            this.OTHERBOX.SpecimenType = "OTH";
            this.OTHERBOX.TabIndex = 195;
            // 
            // Viralloadbox
            // 
            this.Viralloadbox.DataColumnName = "VIRALLOADTEST";
            this.Viralloadbox.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.Viralloadbox.Location = new System.Drawing.Point(391, 455);
            this.Viralloadbox.Name = "Viralloadbox";
            this.Viralloadbox.Size = new System.Drawing.Size(275, 20);
            this.Viralloadbox.SpecimenExtension = "74";
            this.Viralloadbox.SpecimenType = "LAV";
            this.Viralloadbox.TabIndex = 173;
            // 
            // fluidbox
            // 
            this.fluidbox.DataColumnName = "FLUIDTEST";
            this.fluidbox.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.fluidbox.Location = new System.Drawing.Point(391, 401);
            this.fluidbox.Name = "fluidbox";
            this.fluidbox.Size = new System.Drawing.Size(275, 20);
            this.fluidbox.SpecimenExtension = "38";
            this.fluidbox.SpecimenType = "FLD";
            this.fluidbox.TabIndex = 172;
            // 
            // csfbox
            // 
            this.csfbox.DataColumnName = "CSFTEST";
            this.csfbox.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.csfbox.Location = new System.Drawing.Point(391, 337);
            this.csfbox.Name = "csfbox";
            this.csfbox.Size = new System.Drawing.Size(275, 20);
            this.csfbox.SpecimenExtension = "26";
            this.csfbox.SpecimenType = "CSF";
            this.csfbox.TabIndex = 171;
            // 
            // sendout
            // 
            this.sendout.DataColumnName = "SENDOUT";
            this.sendout.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.sendout.Location = new System.Drawing.Point(391, 282);
            this.sendout.Name = "sendout";
            this.sendout.Size = new System.Drawing.Size(275, 20);
            this.sendout.SpecimenExtension = "05";
            this.sendout.SpecimenType = "REF";
            this.sendout.TabIndex = 170;
            // 
            // ser
            // 
            this.ser.DataColumnName = "serology";
            this.ser.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.ser.Location = new System.Drawing.Point(391, 225);
            this.ser.Name = "ser";
            this.ser.Size = new System.Drawing.Size(275, 20);
            this.ser.SpecimenExtension = "41";
            this.ser.SpecimenType = "SRL";
            this.ser.TabIndex = 168;
            // 
            // hepp
            // 
            this.hepp.DataColumnName = "heppetitas";
            this.hepp.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.hepp.Location = new System.Drawing.Point(391, 171);
            this.hepp.Name = "hepp";
            this.hepp.Size = new System.Drawing.Size(275, 20);
            this.hepp.SpecimenExtension = "42";
            this.hepp.SpecimenType = "SHP";
            this.hepp.TabIndex = 166;
            // 
            // comment
            // 
            this.comment.DataColumnName = "";
            this.comment.LabelPrintMode = downtimeC.LabelPrintMode.Comment;
            this.comment.Location = new System.Drawing.Point(381, 738);
            this.comment.Name = "comment";
            this.comment.Size = new System.Drawing.Size(461, 20);
            this.comment.SpecimenExtension = "";
            this.comment.SpecimenType = "CMT";
            this.comment.TabIndex = 176;
            // 
            // bloodgas
            // 
            this.bloodgas.DataColumnName = "bloodgas";
            this.bloodgas.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.bloodgas.Location = new System.Drawing.Point(391, 118);
            this.bloodgas.Name = "bloodgas";
            this.bloodgas.Size = new System.Drawing.Size(275, 20);
            this.bloodgas.SpecimenExtension = "20";
            this.bloodgas.SpecimenType = "SYR";
            this.bloodgas.TabIndex = 164;
            // 
            // urinechem
            // 
            this.urinechem.DataColumnName = "urinechem";
            this.urinechem.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.urinechem.Location = new System.Drawing.Point(391, 76);
            this.urinechem.Name = "urinechem";
            this.urinechem.Size = new System.Drawing.Size(275, 20);
            this.urinechem.SpecimenExtension = "27";
            this.urinechem.SpecimenType = "URC";
            this.urinechem.TabIndex = 162;
            // 
            // urinehem
            // 
            this.urinehem.DataColumnName = "urinehem";
            this.urinehem.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.urinehem.Location = new System.Drawing.Point(391, 30);
            this.urinehem.Name = "urinehem";
            this.urinehem.Size = new System.Drawing.Size(275, 20);
            this.urinehem.SpecimenExtension = "UA";
            this.urinehem.SpecimenType = "UAC";
            this.urinehem.TabIndex = 160;
            // 
            // graytest
            // 
            this.graytest.DataColumnName = "grytest";
            this.graytest.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.graytest.Location = new System.Drawing.Point(14, 741);
            this.graytest.Name = "graytest";
            this.graytest.Size = new System.Drawing.Size(275, 20);
            this.graytest.SpecimenExtension = "19";
            this.graytest.SpecimenType = "GRY";
            this.graytest.TabIndex = 158;
            // 
            // lavchemtest
            // 
            this.lavchemtest.DataColumnName = "lavchemtest";
            this.lavchemtest.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.lavchemtest.Location = new System.Drawing.Point(17, 690);
            this.lavchemtest.Name = "lavchemtest";
            this.lavchemtest.Size = new System.Drawing.Size(190, 20);
            this.lavchemtest.SpecimenExtension = "79";
            this.lavchemtest.SpecimenType = "LAV";
            this.lavchemtest.TabIndex = 156;
            // 
            // greentest
            // 
            this.greentest.DataColumnName = "greentest";
            this.greentest.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.greentest.Location = new System.Drawing.Point(14, 637);
            this.greentest.Name = "greentest";
            this.greentest.Size = new System.Drawing.Size(193, 20);
            this.greentest.SpecimenExtension = "40";
            this.greentest.SpecimenType = "GRN";
            this.greentest.TabIndex = 154;
            // 
            // lavhemtest
            // 
            this.lavhemtest.DataColumnName = "lavhemtest";
            this.lavhemtest.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.lavhemtest.Location = new System.Drawing.Point(14, 588);
            this.lavhemtest.Name = "lavhemtest";
            this.lavhemtest.Size = new System.Drawing.Size(226, 20);
            this.lavhemtest.SpecimenExtension = "18";
            this.lavhemtest.SpecimenType = "LAV";
            this.lavhemtest.TabIndex = 152;
            // 
            // bluetest
            // 
            this.bluetest.DataColumnName = "bluetest";
            this.bluetest.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.bluetest.Location = new System.Drawing.Point(17, 539);
            this.bluetest.Name = "bluetest";
            this.bluetest.Size = new System.Drawing.Size(223, 20);
            this.bluetest.SpecimenExtension = "23";
            this.bluetest.SpecimenType = "BLU";
            this.bluetest.TabIndex = 150;
            // 
            // redtest
            // 
            this.redtest.DataColumnName = "redtest";
            this.redtest.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.redtest.Location = new System.Drawing.Point(20, 483);
            this.redtest.Name = "redtest";
            this.redtest.Size = new System.Drawing.Size(220, 20);
            this.redtest.SpecimenExtension = "00";
            this.redtest.SpecimenType = "SST";
            this.redtest.TabIndex = 148;
            // 
            // collectiontime
            // 
            this.collectiontime.DataColumnName = "collectiontime";
            this.collectiontime.LabelPrintMode = downtimeC.LabelPrintMode.Demographic;
            this.collectiontime.Location = new System.Drawing.Point(17, 152);
            this.collectiontime.Name = "collectiontime";
            this.collectiontime.Size = new System.Drawing.Size(223, 20);
            this.collectiontime.SpecimenExtension = "";
            this.collectiontime.SpecimenType = "";
            this.collectiontime.TabIndex = 136;
            // 
            // AliquotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 777);
            this.Controls.Add(this.ComboBoxprinter);
            this.Controls.Add(this.OTHERBOX);
            this.Controls.Add(this.Label31);
            this.Controls.Add(this.printdem);
            this.Controls.Add(this.Viralloadbox);
            this.Controls.Add(this.Label30);
            this.Controls.Add(this.fluidbox);
            this.Controls.Add(this.Label29);
            this.Controls.Add(this.csfbox);
            this.Controls.Add(this.Label28);
            this.Controls.Add(this.ordertechid);
            this.Controls.Add(this.Label27);
            this.Controls.Add(this.colldate);
            this.Controls.Add(this.DateTimePicker1);
            this.Controls.Add(this.Label26);
            this.Controls.Add(this.sendout);
            this.Controls.Add(this.Label24);
            this.Controls.Add(this.ser);
            this.Controls.Add(this.Label23);
            this.Controls.Add(this.hepp);
            this.Controls.Add(this.Label22);
            this.Controls.Add(this.buttonRead);
            this.Controls.Add(this.Label25);
            this.Controls.Add(this.ButtonPrint);
            this.Controls.Add(this.comment);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.cal1);
            this.Controls.Add(this.Label20);
            this.Controls.Add(this.problem);
            this.Controls.Add(this.Label19);
            this.Controls.Add(this.bloodgas);
            this.Controls.Add(this.Label18);
            this.Controls.Add(this.urinechem);
            this.Controls.Add(this.Label17);
            this.Controls.Add(this.urinehem);
            this.Controls.Add(this.Label16);
            this.Controls.Add(this.graytest);
            this.Controls.Add(this.Label15);
            this.Controls.Add(this.lavchemtest);
            this.Controls.Add(this.Label14);
            this.Controls.Add(this.greentest);
            this.Controls.Add(this.Label13);
            this.Controls.Add(this.lavhemtest);
            this.Controls.Add(this.Label12);
            this.Controls.Add(this.bluetest);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.redtest);
            this.Controls.Add(this.Label10);
            this.Controls.Add(this.DOB);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.mrn);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.priority);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.locationTextBox);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.receivetime);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.collectiontime);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.lastname);
            this.Controls.Add(this.ButtonWrite);
            this.Controls.Add(this.Buttonpopulate);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.firstname);
            this.Controls.Add(this.ordernumber);
            this.Name = "AliquotForm";
            this.Text = "AliquotForm";
            this.Load += new System.EventHandler(this.aliquotform_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox ComboBoxprinter;
        internal TubeTypeTextBox OTHERBOX;
        internal System.Windows.Forms.Label Label31;
        internal System.Windows.Forms.Button printdem;
        internal TubeTypeTextBox Viralloadbox;
        internal System.Windows.Forms.Label Label30;
        internal TubeTypeTextBox fluidbox;
        internal System.Windows.Forms.Label Label29;
        internal TubeTypeTextBox csfbox;
        internal System.Windows.Forms.Label Label28;
        internal System.Windows.Forms.TextBox ordertechid;
        internal System.Windows.Forms.Label Label27;
        internal StoredTextBox colldate;
        internal System.Windows.Forms.DateTimePicker DateTimePicker1;
        internal System.Windows.Forms.Label Label26;
        internal TubeTypeTextBox sendout;
        internal System.Windows.Forms.Label Label24;
        internal TubeTypeTextBox ser;
        internal System.Windows.Forms.Label Label23;
        internal TubeTypeTextBox hepp;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.Button buttonRead;
        internal System.Windows.Forms.Label Label25;
        internal System.Windows.Forms.Button ButtonPrint;
        internal TubeTypeTextBox comment;
        internal System.Windows.Forms.Label Label21;
        internal StoredTextBox cal1;
        internal System.Windows.Forms.Label Label20;
        internal StoredTextBox problem;
        internal System.Windows.Forms.Label Label19;
        internal TubeTypeTextBox bloodgas;
        internal System.Windows.Forms.Label Label18;
        internal TubeTypeTextBox urinechem;
        internal System.Windows.Forms.Label Label17;
        internal TubeTypeTextBox urinehem;
        internal System.Windows.Forms.Label Label16;
        internal TubeTypeTextBox graytest;
        internal System.Windows.Forms.Label Label15;
        internal TubeTypeTextBox lavchemtest;
        internal System.Windows.Forms.Label Label14;
        internal TubeTypeTextBox greentest;
        internal System.Windows.Forms.Label Label13;
        internal TubeTypeTextBox lavhemtest;
        internal System.Windows.Forms.Label Label12;
        internal TubeTypeTextBox bluetest;
        internal System.Windows.Forms.Label Label11;
        internal TubeTypeTextBox redtest;
        internal System.Windows.Forms.Label Label10;
        internal StoredTextBox DOB;
        internal System.Windows.Forms.Label Label9;
        internal StoredTextBox mrn;
        internal System.Windows.Forms.Label Label8;
        internal StoredTextBox priority;
        internal System.Windows.Forms.Label Label7;
        internal StoredTextBox locationTextBox;
        internal System.Windows.Forms.Label Label6;
        internal StoredTextBox receivetime;
        internal System.Windows.Forms.Label Label5;
        internal TubeTypeTextBox collectiontime;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal StoredTextBox lastname;
        internal System.Windows.Forms.Button ButtonWrite;
        internal System.Windows.Forms.Button Buttonpopulate;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal StoredTextBox firstname;
        internal StoredTextBox ordernumber;
    }
}
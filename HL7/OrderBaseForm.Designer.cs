﻿namespace HL7
{
    partial class OrderBaseForm
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
            this.ComboboxPrinter = new System.Windows.Forms.ComboBox();
            this.OTHERBOX = new downtimeC.TubeTypeTextBox();
            this.Label31 = new System.Windows.Forms.Label();
            this.Viralloadbox = new downtimeC.TubeTypeTextBox();
            this.Label30 = new System.Windows.Forms.Label();
            this.fluidbox = new downtimeC.TubeTypeTextBox();
            this.Label29 = new System.Windows.Forms.Label();
            this.csfbox = new downtimeC.TubeTypeTextBox();
            this.Label28 = new System.Windows.Forms.Label();
            this.TextBoxTechId = new System.Windows.Forms.TextBox();
            this.Label27 = new System.Windows.Forms.Label();
            this.TextboxCollectDate = new downtimeC.StoredTextBox();
            this.DateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Label26 = new System.Windows.Forms.Label();
            this.sendout = new downtimeC.TubeTypeTextBox();
            this.Label24 = new System.Windows.Forms.Label();
            this.ser = new downtimeC.TubeTypeTextBox();
            this.Label23 = new System.Windows.Forms.Label();
            this.hepp = new downtimeC.TubeTypeTextBox();
            this.Label22 = new System.Windows.Forms.Label();
            this.DebugButtonRead = new System.Windows.Forms.Button();
            this.Label25 = new System.Windows.Forms.Label();
            this.comment = new downtimeC.TubeTypeTextBox();
            this.Label21 = new System.Windows.Forms.Label();
            this.cal1 = new downtimeC.StoredTextBox();
            this.Label20 = new System.Windows.Forms.Label();
            this.problem = new downtimeC.StoredTextBox();
            this.Label19 = new System.Windows.Forms.Label();
            this.bloodgas = new downtimeC.TubeTypeTextBox();
            this.Label18 = new System.Windows.Forms.Label();
            this.urinechem = new downtimeC.TubeTypeTextBox();
            this.Label17 = new System.Windows.Forms.Label();
            this.urinehem = new downtimeC.TubeTypeTextBox();
            this.Label16 = new System.Windows.Forms.Label();
            this.graytest = new downtimeC.TubeTypeTextBox();
            this.Label15 = new System.Windows.Forms.Label();
            this.lavchemtest = new downtimeC.TubeTypeTextBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.greentest = new downtimeC.TubeTypeTextBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.lavhemtest = new downtimeC.TubeTypeTextBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.bluetest = new downtimeC.TubeTypeTextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.redtest = new downtimeC.TubeTypeTextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.DOB = new downtimeC.StoredTextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.mrn = new downtimeC.StoredTextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.labelWard = new System.Windows.Forms.Label();
            this.receivetime = new downtimeC.StoredTextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.collectiontime = new downtimeC.TubeTypeTextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.lastname = new downtimeC.StoredTextBox();
            this.DebugButtonFill = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.firstname = new downtimeC.StoredTextBox();
            this.ordernumber = new downtimeC.StoredTextBox();
            this.Label33 = new System.Windows.Forms.Label();
            this.TextBoxbillingnumber = new System.Windows.Forms.TextBox();
            this.comboBoxWard = new downtimeC.StoredComboBox();
            this.Label34 = new System.Windows.Forms.Label();
            this.TextBoxIMMUNO = new downtimeC.TubeTypeTextBox();
            this.editorder = new System.Windows.Forms.Button();
            this.Buttoneditprevious = new System.Windows.Forms.Button();
            this.Label32 = new System.Windows.Forms.Label();
            this.ComboBoxoldorder = new System.Windows.Forms.ComboBox();
            this.labelCollectDate = new System.Windows.Forms.Label();
            this.ComboBoxPriority = new downtimeC.PriorityComboBox();
            this.ButtonPrint = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.ComboboxPrintType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ComboboxPrinter
            // 
            this.ComboboxPrinter.FormattingEnabled = true;
            this.ComboboxPrinter.Location = new System.Drawing.Point(770, 203);
            this.ComboboxPrinter.Name = "ComboboxPrinter";
            this.ComboboxPrinter.Size = new System.Drawing.Size(121, 21);
            this.ComboboxPrinter.TabIndex = 30;
            this.ComboboxPrinter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ComboBoxprinter_KeyUp);
            // 
            // OTHERBOX
            // 
            this.OTHERBOX.DataColumnName = "OTHERTEST";
            this.OTHERBOX.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.OTHERBOX.Location = new System.Drawing.Point(391, 601);
            this.OTHERBOX.Name = "OTHERBOX";
            this.OTHERBOX.Size = new System.Drawing.Size(272, 20);
            this.OTHERBOX.SpecimenExtension = "";
            this.OTHERBOX.SpecimenExtensionHighland = "";
            this.OTHERBOX.SpecimenType = "OTH";
            this.OTHERBOX.SpecimenTypeHighland = "";
            this.OTHERBOX.TabIndex = 26;
            // 
            // Label31
            // 
            this.Label31.AutoSize = true;
            this.Label31.Location = new System.Drawing.Point(391, 584);
            this.Label31.Name = "Label31";
            this.Label31.Size = new System.Drawing.Size(33, 13);
            this.Label31.TabIndex = 262;
            this.Label31.Text = "Other";
            // 
            // Viralloadbox
            // 
            this.Viralloadbox.DataColumnName = "VIRALLOADTEST";
            this.Viralloadbox.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.Viralloadbox.Location = new System.Drawing.Point(391, 550);
            this.Viralloadbox.Name = "Viralloadbox";
            this.Viralloadbox.Size = new System.Drawing.Size(275, 20);
            this.Viralloadbox.SpecimenExtension = "74";
            this.Viralloadbox.SpecimenExtensionHighland = "";
            this.Viralloadbox.SpecimenType = "LAV";
            this.Viralloadbox.SpecimenTypeHighland = "";
            this.Viralloadbox.TabIndex = 25;
            // 
            // Label30
            // 
            this.Label30.AutoSize = true;
            this.Label30.Location = new System.Drawing.Point(391, 534);
            this.Label30.Name = "Label30";
            this.Label30.Size = new System.Drawing.Size(78, 13);
            this.Label30.TabIndex = 260;
            this.Label30.Text = "Viral Load Test";
            // 
            // fluidbox
            // 
            this.fluidbox.DataColumnName = "FLUIDTEST";
            this.fluidbox.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.fluidbox.Location = new System.Drawing.Point(391, 493);
            this.fluidbox.Name = "fluidbox";
            this.fluidbox.Size = new System.Drawing.Size(275, 20);
            this.fluidbox.SpecimenExtension = "38";
            this.fluidbox.SpecimenExtensionHighland = "";
            this.fluidbox.SpecimenType = "FLD";
            this.fluidbox.SpecimenTypeHighland = "";
            this.fluidbox.TabIndex = 24;
            // 
            // Label29
            // 
            this.Label29.AutoSize = true;
            this.Label29.Location = new System.Drawing.Point(391, 477);
            this.Label29.Name = "Label29";
            this.Label29.Size = new System.Drawing.Size(53, 13);
            this.Label29.TabIndex = 259;
            this.Label29.Text = "Fluid Test";
            // 
            // csfbox
            // 
            this.csfbox.DataColumnName = "CSFTEST";
            this.csfbox.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.csfbox.Location = new System.Drawing.Point(391, 440);
            this.csfbox.Name = "csfbox";
            this.csfbox.Size = new System.Drawing.Size(275, 20);
            this.csfbox.SpecimenExtension = "26";
            this.csfbox.SpecimenExtensionHighland = "";
            this.csfbox.SpecimenType = "CSF";
            this.csfbox.SpecimenTypeHighland = "";
            this.csfbox.TabIndex = 23;
            // 
            // Label28
            // 
            this.Label28.AutoSize = true;
            this.Label28.Location = new System.Drawing.Point(391, 424);
            this.Label28.Name = "Label28";
            this.Label28.Size = new System.Drawing.Size(51, 13);
            this.Label28.TabIndex = 258;
            this.Label28.Text = "CSF Test";
            // 
            // TextBoxTechId
            // 
            this.TextBoxTechId.Enabled = false;
            this.TextBoxTechId.Location = new System.Drawing.Point(770, 550);
            this.TextBoxTechId.Name = "TextBoxTechId";
            this.TextBoxTechId.Size = new System.Drawing.Size(113, 20);
            this.TextBoxTechId.TabIndex = 257;
            this.TextBoxTechId.TabStop = false;
            this.TextBoxTechId.TextChanged += new System.EventHandler(this.TextBoxTechId_TextChanged);
            // 
            // Label27
            // 
            this.Label27.AutoSize = true;
            this.Label27.Location = new System.Drawing.Point(770, 529);
            this.Label27.Name = "Label27";
            this.Label27.Size = new System.Drawing.Size(46, 13);
            this.Label27.TabIndex = 256;
            this.Label27.Text = "Tech ID";
            // 
            // TextboxCollectDate
            // 
            this.TextboxCollectDate.DataColumnName = "collectdate";
            this.TextboxCollectDate.Location = new System.Drawing.Point(770, 440);
            this.TextboxCollectDate.Name = "TextboxCollectDate";
            this.TextboxCollectDate.Size = new System.Drawing.Size(135, 20);
            this.TextboxCollectDate.TabIndex = 255;
            this.TextboxCollectDate.TabStop = false;
            this.TextboxCollectDate.Visible = false;
            // 
            // DateTimePicker1
            // 
            this.DateTimePicker1.Enabled = false;
            this.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateTimePicker1.Location = new System.Drawing.Point(770, 37);
            this.DateTimePicker1.Name = "DateTimePicker1";
            this.DateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.DateTimePicker1.TabIndex = 254;
            this.DateTimePicker1.TabStop = false;
            // 
            // Label26
            // 
            this.Label26.AutoSize = true;
            this.Label26.Location = new System.Drawing.Point(770, 18);
            this.Label26.Name = "Label26";
            this.Label26.Size = new System.Drawing.Size(68, 13);
            this.Label26.TabIndex = 253;
            this.Label26.Text = "Todays Date";
            // 
            // sendout
            // 
            this.sendout.DataColumnName = "SENDOUT";
            this.sendout.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.sendout.Location = new System.Drawing.Point(391, 385);
            this.sendout.Name = "sendout";
            this.sendout.Size = new System.Drawing.Size(275, 20);
            this.sendout.SpecimenExtension = "05";
            this.sendout.SpecimenExtensionHighland = "";
            this.sendout.SpecimenType = "REF";
            this.sendout.SpecimenTypeHighland = "";
            this.sendout.TabIndex = 22;
            // 
            // Label24
            // 
            this.Label24.AutoSize = true;
            this.Label24.Location = new System.Drawing.Point(391, 369);
            this.Label24.Name = "Label24";
            this.Label24.Size = new System.Drawing.Size(94, 13);
            this.Label24.TabIndex = 252;
            this.Label24.Text = "Sendout Test (1N)";
            // 
            // ser
            // 
            this.ser.DataColumnName = "serology";
            this.ser.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.ser.Location = new System.Drawing.Point(391, 298);
            this.ser.Name = "ser";
            this.ser.Size = new System.Drawing.Size(275, 20);
            this.ser.SpecimenExtension = "41";
            this.ser.SpecimenExtensionHighland = "";
            this.ser.SpecimenType = "SRL";
            this.ser.SpecimenTypeHighland = "";
            this.ser.TabIndex = 20;
            // 
            // Label23
            // 
            this.Label23.AutoSize = true;
            this.Label23.Location = new System.Drawing.Point(391, 281);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(93, 13);
            this.Label23.TabIndex = 251;
            this.Label23.Text = "Serology Test (41)";
            // 
            // hepp
            // 
            this.hepp.DataColumnName = "heppetitas";
            this.hepp.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.hepp.Location = new System.Drawing.Point(391, 254);
            this.hepp.Name = "hepp";
            this.hepp.Size = new System.Drawing.Size(275, 20);
            this.hepp.SpecimenExtension = "42";
            this.hepp.SpecimenExtensionHighland = "";
            this.hepp.SpecimenType = "SHP";
            this.hepp.SpecimenTypeHighland = "";
            this.hepp.TabIndex = 19;
            // 
            // Label22
            // 
            this.Label22.AutoSize = true;
            this.Label22.Location = new System.Drawing.Point(391, 237);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(93, 13);
            this.Label22.TabIndex = 250;
            this.Label22.Text = "Hepatitis Test (42)";
            // 
            // DebugButtonRead
            // 
            this.DebugButtonRead.Location = new System.Drawing.Point(770, 74);
            this.DebugButtonRead.Name = "DebugButtonRead";
            this.DebugButtonRead.Size = new System.Drawing.Size(75, 23);
            this.DebugButtonRead.TabIndex = 249;
            this.DebugButtonRead.TabStop = false;
            this.DebugButtonRead.Text = "Read";
            this.DebugButtonRead.UseVisualStyleBackColor = true;
            this.DebugButtonRead.Visible = false;
            this.DebugButtonRead.Click += new System.EventHandler(this.DebugButtonRead_click);
            // 
            // Label25
            // 
            this.Label25.AutoSize = true;
            this.Label25.Location = new System.Drawing.Point(770, 187);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(37, 13);
            this.Label25.TabIndex = 248;
            this.Label25.Text = "Printer";
            // 
            // comment
            // 
            this.comment.DataColumnName = "ORDERCOMMENT";
            this.comment.LabelPrintMode = downtimeC.LabelPrintMode.Comment;
            this.comment.Location = new System.Drawing.Point(391, 746);
            this.comment.Name = "comment";
            this.comment.Size = new System.Drawing.Size(592, 20);
            this.comment.SpecimenExtension = "";
            this.comment.SpecimenExtensionHighland = "";
            this.comment.SpecimenType = "CMT";
            this.comment.SpecimenTypeHighland = "";
            this.comment.TabIndex = 29;
            // 
            // Label21
            // 
            this.Label21.AutoSize = true;
            this.Label21.Location = new System.Drawing.Point(391, 725);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(51, 13);
            this.Label21.TabIndex = 237;
            this.Label21.Text = "Comment";
            // 
            // cal1
            // 
            this.cal1.DataColumnName = "calls";
            this.cal1.Location = new System.Drawing.Point(391, 702);
            this.cal1.Name = "cal1";
            this.cal1.Size = new System.Drawing.Size(138, 20);
            this.cal1.TabIndex = 28;
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.Location = new System.Drawing.Point(391, 686);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(24, 13);
            this.Label20.TabIndex = 235;
            this.Label20.Text = "Call";
            // 
            // problem
            // 
            this.problem.DataColumnName = "problem";
            this.problem.Location = new System.Drawing.Point(391, 655);
            this.problem.Name = "problem";
            this.problem.Size = new System.Drawing.Size(190, 20);
            this.problem.TabIndex = 27;
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Location = new System.Drawing.Point(391, 639);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(45, 13);
            this.Label19.TabIndex = 233;
            this.Label19.Text = "Problem";
            // 
            // bloodgas
            // 
            this.bloodgas.DataColumnName = "bloodgas";
            this.bloodgas.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.bloodgas.Location = new System.Drawing.Point(391, 210);
            this.bloodgas.Name = "bloodgas";
            this.bloodgas.Size = new System.Drawing.Size(275, 20);
            this.bloodgas.SpecimenExtension = "20";
            this.bloodgas.SpecimenExtensionHighland = "";
            this.bloodgas.SpecimenType = "SYR";
            this.bloodgas.SpecimenTypeHighland = "";
            this.bloodgas.TabIndex = 18;
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.Location = new System.Drawing.Point(391, 193);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(77, 13);
            this.Label18.TabIndex = 231;
            this.Label18.Text = "Blood Gas (20)";
            // 
            // urinechem
            // 
            this.urinechem.DataColumnName = "urinechem";
            this.urinechem.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.urinechem.Location = new System.Drawing.Point(391, 168);
            this.urinechem.Name = "urinechem";
            this.urinechem.Size = new System.Drawing.Size(275, 20);
            this.urinechem.SpecimenExtension = "27";
            this.urinechem.SpecimenExtensionHighland = "";
            this.urinechem.SpecimenType = "URC";
            this.urinechem.SpecimenTypeHighland = "";
            this.urinechem.TabIndex = 17;
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Location = new System.Drawing.Point(391, 151);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(83, 13);
            this.Label17.TabIndex = 229;
            this.Label17.Text = "Urine Chem (27)";
            // 
            // urinehem
            // 
            this.urinehem.DataColumnName = "urinehem";
            this.urinehem.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.urinehem.Location = new System.Drawing.Point(391, 122);
            this.urinehem.Name = "urinehem";
            this.urinehem.Size = new System.Drawing.Size(275, 20);
            this.urinehem.SpecimenExtension = "UA";
            this.urinehem.SpecimenExtensionHighland = "";
            this.urinehem.SpecimenType = "UAC";
            this.urinehem.SpecimenTypeHighland = "";
            this.urinehem.TabIndex = 16;
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Location = new System.Drawing.Point(391, 105);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(81, 13);
            this.Label16.TabIndex = 227;
            this.Label16.Text = "Urine Hem (UA)";
            // 
            // graytest
            // 
            this.graytest.DataColumnName = "grytest";
            this.graytest.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.graytest.Location = new System.Drawing.Point(391, 74);
            this.graytest.Name = "graytest";
            this.graytest.Size = new System.Drawing.Size(275, 20);
            this.graytest.SpecimenExtension = "19";
            this.graytest.SpecimenExtensionHighland = "";
            this.graytest.SpecimenType = "GRY";
            this.graytest.SpecimenTypeHighland = "";
            this.graytest.TabIndex = 15;
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(391, 57);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(74, 13);
            this.Label15.TabIndex = 225;
            this.Label15.Text = "Gray Test (19)";
            // 
            // lavchemtest
            // 
            this.lavchemtest.DataColumnName = "lavchemtest";
            this.lavchemtest.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.lavchemtest.Location = new System.Drawing.Point(391, 27);
            this.lavchemtest.Name = "lavchemtest";
            this.lavchemtest.Size = new System.Drawing.Size(190, 20);
            this.lavchemtest.SpecimenExtension = "79";
            this.lavchemtest.SpecimenExtensionHighland = "";
            this.lavchemtest.SpecimenType = "LAV";
            this.lavchemtest.SpecimenTypeHighland = "";
            this.lavchemtest.TabIndex = 14;
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(391, 12);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(100, 13);
            this.Label14.TabIndex = 223;
            this.Label14.Text = "Lav Chem Test (79)";
            // 
            // greentest
            // 
            this.greentest.DataColumnName = "greentest";
            this.greentest.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.greentest.Location = new System.Drawing.Point(42, 754);
            this.greentest.Name = "greentest";
            this.greentest.Size = new System.Drawing.Size(193, 20);
            this.greentest.SpecimenExtension = "40";
            this.greentest.SpecimenExtensionHighland = "";
            this.greentest.SpecimenType = "GRN";
            this.greentest.SpecimenTypeHighland = "";
            this.greentest.TabIndex = 13;
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(42, 738);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(81, 13);
            this.Label13.TabIndex = 221;
            this.Label13.Text = "Green Test (40)";
            // 
            // lavhemtest
            // 
            this.lavhemtest.DataColumnName = "lavhemtest";
            this.lavhemtest.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.lavhemtest.Location = new System.Drawing.Point(42, 705);
            this.lavhemtest.Name = "lavhemtest";
            this.lavhemtest.Size = new System.Drawing.Size(226, 20);
            this.lavhemtest.SpecimenExtension = "18";
            this.lavhemtest.SpecimenExtensionHighland = "";
            this.lavhemtest.SpecimenType = "LAV";
            this.lavhemtest.SpecimenTypeHighland = "";
            this.lavhemtest.TabIndex = 12;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(42, 689);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(144, 13);
            this.Label12.TabIndex = 219;
            this.Label12.Text = "Lav HEMATOLOGY test (18)";
            // 
            // bluetest
            // 
            this.bluetest.DataColumnName = "bluetest";
            this.bluetest.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.bluetest.Location = new System.Drawing.Point(42, 656);
            this.bluetest.Name = "bluetest";
            this.bluetest.Size = new System.Drawing.Size(223, 20);
            this.bluetest.SpecimenExtension = "23";
            this.bluetest.SpecimenExtensionHighland = "";
            this.bluetest.SpecimenType = "BLU";
            this.bluetest.SpecimenTypeHighland = "";
            this.bluetest.TabIndex = 11;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(42, 640);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(69, 13);
            this.Label11.TabIndex = 217;
            this.Label11.Text = "Blue test (23)";
            // 
            // redtest
            // 
            this.redtest.DataColumnName = "redtest";
            this.redtest.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.redtest.Location = new System.Drawing.Point(42, 600);
            this.redtest.Name = "redtest";
            this.redtest.Size = new System.Drawing.Size(220, 20);
            this.redtest.SpecimenExtension = "00";
            this.redtest.SpecimenExtensionHighland = "";
            this.redtest.SpecimenType = "SST";
            this.redtest.SpecimenTypeHighland = "";
            this.redtest.TabIndex = 10;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(42, 583);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(73, 13);
            this.Label10.TabIndex = 215;
            this.Label10.Text = "SST Test (00)";
            // 
            // DOB
            // 
            this.DOB.DataColumnName = "dob";
            this.DOB.Location = new System.Drawing.Point(42, 304);
            this.DOB.MaxLength = 10;
            this.DOB.Name = "DOB";
            this.DOB.Size = new System.Drawing.Size(129, 20);
            this.DOB.TabIndex = 4;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(42, 288);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(66, 13);
            this.Label9.TabIndex = 213;
            this.Label9.Text = "Date of Birth";
            // 
            // mrn
            // 
            this.mrn.DataColumnName = "mrn";
            this.mrn.Location = new System.Drawing.Point(42, 346);
            this.mrn.Name = "mrn";
            this.mrn.Size = new System.Drawing.Size(223, 20);
            this.mrn.TabIndex = 5;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(42, 330);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(122, 13);
            this.Label8.TabIndex = 211;
            this.Label8.Text = "Medical Record Number";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(42, 383);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(38, 13);
            this.Label7.TabIndex = 209;
            this.Label7.Text = "Priority";
            // 
            // labelWard
            // 
            this.labelWard.AutoSize = true;
            this.labelWard.Location = new System.Drawing.Point(42, 524);
            this.labelWard.Name = "labelWard";
            this.labelWard.Size = new System.Drawing.Size(77, 13);
            this.labelWard.TabIndex = 207;
            this.labelWard.Text = "Ward Location";
            // 
            // receivetime
            // 
            this.receivetime.DataColumnName = "receivetime";
            this.receivetime.Location = new System.Drawing.Point(42, 497);
            this.receivetime.Name = "receivetime";
            this.receivetime.Size = new System.Drawing.Size(226, 20);
            this.receivetime.TabIndex = 8;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(42, 481);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(73, 13);
            this.Label5.TabIndex = 205;
            this.Label5.Text = "Receive Time";
            // 
            // collectiontime
            // 
            this.collectiontime.DataColumnName = "collectiontime";
            this.collectiontime.LabelPrintMode = downtimeC.LabelPrintMode.Demographic;
            this.collectiontime.Location = new System.Drawing.Point(42, 454);
            this.collectiontime.Name = "collectiontime";
            this.collectiontime.Size = new System.Drawing.Size(223, 20);
            this.collectiontime.SpecimenExtension = "";
            this.collectiontime.SpecimenExtensionHighland = "";
            this.collectiontime.SpecimenType = "";
            this.collectiontime.SpecimenTypeHighland = "";
            this.collectiontime.TabIndex = 7;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(42, 438);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(79, 13);
            this.Label4.TabIndex = 203;
            this.Label4.Text = "Collection Time";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(42, 195);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(58, 13);
            this.Label3.TabIndex = 202;
            this.Label3.Text = "Last Name";
            // 
            // lastname
            // 
            this.lastname.DataColumnName = "lastname";
            this.lastname.Location = new System.Drawing.Point(42, 211);
            this.lastname.Name = "lastname";
            this.lastname.Size = new System.Drawing.Size(226, 20);
            this.lastname.TabIndex = 2;
            // 
            // DebugButtonFill
            // 
            this.DebugButtonFill.BackColor = System.Drawing.SystemColors.Control;
            this.DebugButtonFill.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.DebugButtonFill.Location = new System.Drawing.Point(892, 73);
            this.DebugButtonFill.Name = "DebugButtonFill";
            this.DebugButtonFill.Size = new System.Drawing.Size(72, 25);
            this.DebugButtonFill.TabIndex = 246;
            this.DebugButtonFill.TabStop = false;
            this.DebugButtonFill.Text = "Fill Boxes";
            this.DebugButtonFill.UseVisualStyleBackColor = true;
            this.DebugButtonFill.Visible = false;
            this.DebugButtonFill.Click += new System.EventHandler(this.DebugButtonFill_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(42, 239);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(57, 13);
            this.Label2.TabIndex = 200;
            this.Label2.Text = "First Name";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(42, 92);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(43, 13);
            this.Label1.TabIndex = 199;
            this.Label1.Text = "Order #";
            // 
            // firstname
            // 
            this.firstname.DataColumnName = "firstname";
            this.firstname.Location = new System.Drawing.Point(42, 255);
            this.firstname.Name = "firstname";
            this.firstname.Size = new System.Drawing.Size(223, 20);
            this.firstname.TabIndex = 3;
            // 
            // ordernumber
            // 
            this.ordernumber.DataColumnName = "ordernumber";
            this.ordernumber.Location = new System.Drawing.Point(42, 108);
            this.ordernumber.MaxLength = 8;
            this.ordernumber.Name = "ordernumber";
            this.ordernumber.Size = new System.Drawing.Size(115, 20);
            this.ordernumber.TabIndex = 0;
            // 
            // Label33
            // 
            this.Label33.AutoSize = true;
            this.Label33.Location = new System.Drawing.Point(42, 145);
            this.Label33.Name = "Label33";
            this.Label33.Size = new System.Drawing.Size(74, 13);
            this.Label33.TabIndex = 266;
            this.Label33.Text = "Billing Number";
            // 
            // TextBoxbillingnumber
            // 
            this.TextBoxbillingnumber.Location = new System.Drawing.Point(42, 161);
            this.TextBoxbillingnumber.MaxLength = 13;
            this.TextBoxbillingnumber.Name = "TextBoxbillingnumber";
            this.TextBoxbillingnumber.Size = new System.Drawing.Size(224, 20);
            this.TextBoxbillingnumber.TabIndex = 1;
            // 
            // comboBoxWard
            // 
            this.comboBoxWard.DataColumnName = "location";
            this.comboBoxWard.FormattingEnabled = true;
            this.comboBoxWard.Location = new System.Drawing.Point(42, 541);
            this.comboBoxWard.Name = "comboBoxWard";
            this.comboBoxWard.Size = new System.Drawing.Size(223, 21);
            this.comboBoxWard.TabIndex = 9;
            // 
            // Label34
            // 
            this.Label34.AutoSize = true;
            this.Label34.Location = new System.Drawing.Point(391, 326);
            this.Label34.Name = "Label34";
            this.Label34.Size = new System.Drawing.Size(110, 13);
            this.Label34.TabIndex = 269;
            this.Label34.Text = "Immunology Test (2R)";
            // 
            // TextBoxIMMUNO
            // 
            this.TextBoxIMMUNO.DataColumnName = "IMMUNOTEST";
            this.TextBoxIMMUNO.LabelPrintMode = downtimeC.LabelPrintMode.Aliquot;
            this.TextBoxIMMUNO.Location = new System.Drawing.Point(391, 343);
            this.TextBoxIMMUNO.Name = "TextBoxIMMUNO";
            this.TextBoxIMMUNO.Size = new System.Drawing.Size(275, 20);
            this.TextBoxIMMUNO.SpecimenExtension = "2R";
            this.TextBoxIMMUNO.SpecimenExtensionHighland = "";
            this.TextBoxIMMUNO.SpecimenType = "SST";
            this.TextBoxIMMUNO.SpecimenTypeHighland = "";
            this.TextBoxIMMUNO.TabIndex = 21;
            // 
            // editorder
            // 
            this.editorder.Location = new System.Drawing.Point(156, 106);
            this.editorder.Name = "editorder";
            this.editorder.Size = new System.Drawing.Size(105, 23);
            this.editorder.TabIndex = 270;
            this.editorder.TabStop = false;
            this.editorder.Text = "Edit Order";
            this.editorder.UseVisualStyleBackColor = true;
            // 
            // Buttoneditprevious
            // 
            this.Buttoneditprevious.Location = new System.Drawing.Point(156, 25);
            this.Buttoneditprevious.Name = "Buttoneditprevious";
            this.Buttoneditprevious.Size = new System.Drawing.Size(114, 23);
            this.Buttoneditprevious.TabIndex = 271;
            this.Buttoneditprevious.TabStop = false;
            this.Buttoneditprevious.Text = "Edit Most Recent Order";
            this.Buttoneditprevious.UseVisualStyleBackColor = true;
            this.Buttoneditprevious.Visible = false;
            // 
            // Label32
            // 
            this.Label32.AutoSize = true;
            this.Label32.Location = new System.Drawing.Point(42, 9);
            this.Label32.Name = "Label32";
            this.Label32.Size = new System.Drawing.Size(76, 13);
            this.Label32.TabIndex = 273;
            this.Label32.Text = "Recent Orders";
            this.Label32.Visible = false;
            // 
            // ComboBoxoldorder
            // 
            this.ComboBoxoldorder.FormattingEnabled = true;
            this.ComboBoxoldorder.Location = new System.Drawing.Point(42, 26);
            this.ComboBoxoldorder.Name = "ComboBoxoldorder";
            this.ComboBoxoldorder.Size = new System.Drawing.Size(114, 21);
            this.ComboBoxoldorder.TabIndex = 272;
            this.ComboBoxoldorder.TabStop = false;
            this.ComboBoxoldorder.Visible = false;
            // 
            // labelCollectDate
            // 
            this.labelCollectDate.AutoSize = true;
            this.labelCollectDate.Location = new System.Drawing.Point(770, 416);
            this.labelCollectDate.Name = "labelCollectDate";
            this.labelCollectDate.Size = new System.Drawing.Size(65, 13);
            this.labelCollectDate.TabIndex = 274;
            this.labelCollectDate.Text = "Collect Date";
            this.labelCollectDate.Visible = false;
            // 
            // ComboBoxPriority
            // 
            this.ComboBoxPriority.DataColumnName = "priority";
            this.ComboBoxPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxPriority.FormattingEnabled = true;
            this.ComboBoxPriority.Items.AddRange(new object[] {
            "R",
            "S",
            "U"});
            this.ComboBoxPriority.Location = new System.Drawing.Point(42, 399);
            this.ComboBoxPriority.Name = "ComboBoxPriority";
            this.ComboBoxPriority.Size = new System.Drawing.Size(121, 21);
            this.ComboBoxPriority.TabIndex = 6;
            // 
            // ButtonPrint
            // 
            this.ButtonPrint.Location = new System.Drawing.Point(770, 297);
            this.ButtonPrint.Name = "ButtonPrint";
            this.ButtonPrint.Size = new System.Drawing.Size(121, 23);
            this.ButtonPrint.TabIndex = 275;
            this.ButtonPrint.Text = "Print";
            this.ButtonPrint.UseVisualStyleBackColor = true;
            this.ButtonPrint.Click += new System.EventHandler(this.ButtonPrint_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(770, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 278;
            this.label6.Text = "Print Type";
            this.label6.Visible = false;
            // 
            // ComboboxPrintType
            // 
            this.ComboboxPrintType.FormattingEnabled = true;
            this.ComboboxPrintType.Items.AddRange(new object[] {
            "Print All Labels",
            "Print Demographic Labels"});
            this.ComboboxPrintType.Location = new System.Drawing.Point(770, 255);
            this.ComboboxPrintType.Name = "ComboboxPrintType";
            this.ComboboxPrintType.Size = new System.Drawing.Size(121, 21);
            this.ComboboxPrintType.TabIndex = 277;
            this.ComboboxPrintType.Visible = false;
            // 
            // OrderBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 788);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ComboboxPrintType);
            this.Controls.Add(this.ButtonPrint);
            this.Controls.Add(this.ComboBoxPriority);
            this.Controls.Add(this.labelCollectDate);
            this.Controls.Add(this.Label32);
            this.Controls.Add(this.ComboBoxoldorder);
            this.Controls.Add(this.Buttoneditprevious);
            this.Controls.Add(this.editorder);
            this.Controls.Add(this.Label34);
            this.Controls.Add(this.TextBoxIMMUNO);
            this.Controls.Add(this.comboBoxWard);
            this.Controls.Add(this.Label33);
            this.Controls.Add(this.TextBoxbillingnumber);
            this.Controls.Add(this.ComboboxPrinter);
            this.Controls.Add(this.OTHERBOX);
            this.Controls.Add(this.Label31);
            this.Controls.Add(this.Viralloadbox);
            this.Controls.Add(this.Label30);
            this.Controls.Add(this.fluidbox);
            this.Controls.Add(this.Label29);
            this.Controls.Add(this.csfbox);
            this.Controls.Add(this.Label28);
            this.Controls.Add(this.TextBoxTechId);
            this.Controls.Add(this.Label27);
            this.Controls.Add(this.TextboxCollectDate);
            this.Controls.Add(this.DateTimePicker1);
            this.Controls.Add(this.Label26);
            this.Controls.Add(this.sendout);
            this.Controls.Add(this.Label24);
            this.Controls.Add(this.ser);
            this.Controls.Add(this.Label23);
            this.Controls.Add(this.hepp);
            this.Controls.Add(this.Label22);
            this.Controls.Add(this.DebugButtonRead);
            this.Controls.Add(this.Label25);
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
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.labelWard);
            this.Controls.Add(this.receivetime);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.collectiontime);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.lastname);
            this.Controls.Add(this.DebugButtonFill);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.firstname);
            this.Controls.Add(this.ordernumber);
            this.Name = "OrderBaseForm";
            this.Text = "OrderBaseForm";
            this.Load += new System.EventHandler(this.OrderBaseForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label31;
        internal System.Windows.Forms.Label Label30;
        internal System.Windows.Forms.Label Label29;
        internal System.Windows.Forms.Label Label28;
        internal System.Windows.Forms.Label Label27;
        internal System.Windows.Forms.Label Label26;
        internal System.Windows.Forms.Label Label24;
        internal System.Windows.Forms.Label Label23;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.Label Label21;
        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.Label Label18;
        internal System.Windows.Forms.Label Label17;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label labelWard;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        public downtimeC.StoredTextBox ordernumber;
        public System.Windows.Forms.TextBox TextBoxbillingnumber;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label33;
        internal System.Windows.Forms.Label Label34;
        private System.Windows.Forms.Label labelCollectDate;
        public downtimeC.StoredComboBox comboBoxWard;
        public downtimeC.TubeTypeTextBox OTHERBOX;
        public downtimeC.TubeTypeTextBox Viralloadbox;
        public downtimeC.TubeTypeTextBox fluidbox;
        public downtimeC.TubeTypeTextBox csfbox;
        public System.Windows.Forms.TextBox TextBoxTechId;
        public downtimeC.StoredTextBox TextboxCollectDate;
        public System.Windows.Forms.DateTimePicker DateTimePicker1;
        public downtimeC.TubeTypeTextBox sendout;
        public downtimeC.TubeTypeTextBox ser;
        public downtimeC.TubeTypeTextBox hepp;
        public System.Windows.Forms.Button DebugButtonRead;
        public downtimeC.TubeTypeTextBox comment;
        public downtimeC.StoredTextBox cal1;
        public downtimeC.StoredTextBox problem;
        public downtimeC.TubeTypeTextBox bloodgas;
        public downtimeC.TubeTypeTextBox urinechem;
        public downtimeC.TubeTypeTextBox urinehem;
        public downtimeC.TubeTypeTextBox graytest;
        public downtimeC.TubeTypeTextBox lavchemtest;
        public downtimeC.TubeTypeTextBox greentest;
        public downtimeC.TubeTypeTextBox lavhemtest;
        public downtimeC.TubeTypeTextBox bluetest;
        public downtimeC.TubeTypeTextBox redtest;
        public downtimeC.StoredTextBox DOB;
        public downtimeC.StoredTextBox mrn;
        public downtimeC.StoredTextBox receivetime;
        public downtimeC.TubeTypeTextBox collectiontime;
        public downtimeC.StoredTextBox lastname;
        public System.Windows.Forms.Button DebugButtonFill;
        public downtimeC.StoredTextBox firstname;
        public downtimeC.TubeTypeTextBox TextBoxIMMUNO;
        public System.Windows.Forms.Button editorder;
        public System.Windows.Forms.Button Buttoneditprevious;
        public System.Windows.Forms.ComboBox ComboBoxoldorder;
        public downtimeC.PriorityComboBox ComboBoxPriority;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox ComboboxPrintType;
        public System.Windows.Forms.Label Label32;
        private System.Windows.Forms.Label Label25;
        private System.Windows.Forms.Button ButtonPrint;
        public System.Windows.Forms.ComboBox ComboboxPrinter;
    }
}
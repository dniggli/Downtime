using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FunctionalCSharp;
using CodeBase2.Database;
using downtimeC.LabelPrinting;
using HL7;

namespace downtimeC
{

    public enum Hospital
    {
        Strong,
        Highland
        
    }

    public enum LabelPrintMode
    {
        Collection,
        Demographic,
        Comment,
        Aliquot
    }

    public enum HL7Destination
    {
        None,
        DI,
        MOLIS
    }

    public partial class TubeTypeTextBox : TextBox, IStoredControl
    {
        public TubeTypeTextBox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private string specimenType = "";

        [Browsable(true)]
        public string SpecimenType
        {
            get { return this.specimenType; }
            set { this.specimenType = value; }
        }

        private string specimenExtension = "";

        [Browsable(true)]
        public string SpecimenExtension
        {
            get { return this.specimenExtension; }
            set { this.specimenExtension = value; }
        }

        private string specimenTypeHighland = "";

        [Browsable(true)]
        public string SpecimenTypeHighland
        {
            get { return this.specimenTypeHighland; }
            set { this.specimenTypeHighland = value; }
        }

        private string specimenExtensionHighland = "";

        [Browsable(true)]
        public string SpecimenExtensionHighland
        {
            get { return this.specimenExtensionHighland; }
            set { this.specimenExtensionHighland = value; }
        }

        private HL7Destination sendHL7 = HL7Destination.None;

        [Browsable(true)]
        public HL7Destination SendHL7
        {
            get { return this.sendHL7; }
            set { this.sendHL7 = value; }
        }

        private LabelPrintMode labelPrintMode;

        [Browsable(true)]
        public LabelPrintMode LabelPrintMode
        {
            get { return this.labelPrintMode; }
            set { this.labelPrintMode = value; }
        }

        private string dataColumnName = "";

        [Browsable(true)]
        public string DataColumnName
        {
            get { return this.dataColumnName; }
            set { this.dataColumnName = value; }
        }

        public void setValue(string value)
        {
            this.Text = value;
        }

       public SpecimenType getSpecimenType(Hospital hospital, SetupTableData tableData) {
           
           return (hospital == Hospital.Strong) 
               ?  new SpecimenType { extension = this.SpecimenExtension, diSpecimenType = tableData.DISpecimenTranslation.get(this.SpecimenType) }
               : new SpecimenType { extension = this.SpecimenExtensionHighland, diSpecimenType = tableData.DISpecimenTranslation.get(this.SpecimenTypeHighland) };
       }
        public void LabelAppend(LabelData labelData, Priority priority)
        {
            if ((this.Text == string.Empty))
            {
                return;
            }

            if (LabelPrintMode == LabelPrintMode.Collection)
            {
                labelData.LabelAppendCollection(this.Text,this.SpecimenType,this.SpecimenExtension);
            }
            else if (LabelPrintMode == LabelPrintMode.Demographic)
            {
                labelData.LabelAppendDemographic(this.Text, this.SpecimenType, this.SpecimenExtension);
            }
            else if (LabelPrintMode == LabelPrintMode.Comment)
            {
                labelData.LabelAppendComment(this.Text, this.SpecimenType, this.SpecimenExtension);
            }
            else if (LabelPrintMode == LabelPrintMode.Aliquot)
            {
                if (priority == Priority.Routine)
                {
                    labelData.LabelAppendAliquotRoutine(this.Text, this.SpecimenType, this.SpecimenExtension);
                }
                else if (priority == Priority.Stat)
                {
                    labelData.LabelAppendAliquotStat(this.Text, this.SpecimenType, this.SpecimenExtension);
                }

            }
            else
            {
                throw new Exception("Unknown LabelPrintMode");
            }
        }
    }
}

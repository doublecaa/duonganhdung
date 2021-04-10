
namespace QLThietBiVatTu
{
    partial class FormBC
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.QLTBDataSet = new QLThietBiVatTu.QLTBDataSet();
            this.ThietBiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ThietBiTableAdapter = new QLThietBiVatTu.QLTBDataSetTableAdapters.ThietBiTableAdapter();
            this.QLTBDataSet1 = new QLThietBiVatTu.QLTBDataSet1();
            this.vwBCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vwBCTableAdapter = new QLThietBiVatTu.QLTBDataSet1TableAdapters.vwBCTableAdapter();
            this.btnQL = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.QLTBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThietBiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLTBDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwBCBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.vwBCBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLThietBiVatTu.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-1, 1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(671, 290);
            this.reportViewer1.TabIndex = 1;
            // 
            // QLTBDataSet
            // 
            this.QLTBDataSet.DataSetName = "QLTBDataSet";
            this.QLTBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ThietBiBindingSource
            // 
            this.ThietBiBindingSource.DataMember = "ThietBi";
            this.ThietBiBindingSource.DataSource = this.QLTBDataSet;
            // 
            // ThietBiTableAdapter
            // 
            this.ThietBiTableAdapter.ClearBeforeFill = true;
            // 
            // QLTBDataSet1
            // 
            this.QLTBDataSet1.DataSetName = "QLTBDataSet1";
            this.QLTBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vwBCBindingSource
            // 
            this.vwBCBindingSource.DataMember = "vwBC";
            this.vwBCBindingSource.DataSource = this.QLTBDataSet1;
            // 
            // vwBCTableAdapter
            // 
            this.vwBCTableAdapter.ClearBeforeFill = true;
            // 
            // btnQL
            // 
            this.btnQL.Location = new System.Drawing.Point(678, 226);
            this.btnQL.Name = "btnQL";
            this.btnQL.Size = new System.Drawing.Size(75, 23);
            this.btnQL.TabIndex = 2;
            this.btnQL.Text = "Quay lại";
            this.btnQL.UseVisualStyleBackColor = true;
            this.btnQL.Click += new System.EventHandler(this.btnQL_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(678, 269);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 22);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // FormBC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 292);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnQL);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FormBC";
            this.Text = "FormBC";
            this.Load += new System.EventHandler(this.FormBC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QLTBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThietBiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLTBDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwBCBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ThietBiBindingSource;
        private QLTBDataSet QLTBDataSet;
        private QLTBDataSetTableAdapters.ThietBiTableAdapter ThietBiTableAdapter;
        private System.Windows.Forms.BindingSource vwBCBindingSource;
        private QLTBDataSet1 QLTBDataSet1;
        private QLTBDataSet1TableAdapters.vwBCTableAdapter vwBCTableAdapter;
        private System.Windows.Forms.Button btnQL;
        private System.Windows.Forms.Button btnThoat;
    }
}
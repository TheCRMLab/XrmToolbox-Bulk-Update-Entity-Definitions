using XrmToolBox.Extensibility;

namespace Cobalt.XrmToolbox.EntityUpdater
{
    partial class EntityUpdaterControl : PluginControlBase
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.loadMetadataButton = new System.Windows.Forms.ToolStripButton();
            this.entityDataGrid = new System.Windows.Forms.DataGridView();
            this.entityNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.changeTrackingEnabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.slimEntityMetadataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.submitUpdateBtn = new System.Windows.Forms.Button();
            this.unmanagedSolutionsList = new System.Windows.Forms.ListBox();
            this.unmanagedSolutionLabel = new System.Windows.Forms.Label();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entityDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slimEntityMetadataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1,
            this.loadMetadataButton});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(735, 25);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(86, 22);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // loadMetadataButton
            // 
            this.loadMetadataButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.loadMetadataButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadMetadataButton.Name = "loadMetadataButton";
            this.loadMetadataButton.Size = new System.Drawing.Size(90, 22);
            this.loadMetadataButton.Text = "Load Metadata";
            this.loadMetadataButton.Click += new System.EventHandler(this.loadMetadataButton_Click);
            // 
            // entityDataGrid
            // 
            this.entityDataGrid.AllowUserToAddRows = false;
            this.entityDataGrid.AllowUserToDeleteRows = false;
            this.entityDataGrid.AutoGenerateColumns = false;
            this.entityDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.entityDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.entityNameDataGridViewTextBoxColumn,
            this.changeTrackingEnabledDataGridViewCheckBoxColumn});
            this.entityDataGrid.DataSource = this.slimEntityMetadataBindingSource;
            this.entityDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entityDataGrid.Location = new System.Drawing.Point(0, 25);
            this.entityDataGrid.MaximumSize = new System.Drawing.Size(550, 0);
            this.entityDataGrid.MultiSelect = false;
            this.entityDataGrid.Name = "entityDataGrid";
            this.entityDataGrid.RowHeadersVisible = false;
            this.entityDataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.entityDataGrid.Size = new System.Drawing.Size(550, 556);
            this.entityDataGrid.TabIndex = 5;
            this.entityDataGrid.Visible = false;
            // 
            // entityNameDataGridViewTextBoxColumn
            // 
            this.entityNameDataGridViewTextBoxColumn.DataPropertyName = "DisplayLabel";
            this.entityNameDataGridViewTextBoxColumn.HeaderText = "Entity Name";
            this.entityNameDataGridViewTextBoxColumn.MinimumWidth = 100;
            this.entityNameDataGridViewTextBoxColumn.Name = "entityNameDataGridViewTextBoxColumn";
            this.entityNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.entityNameDataGridViewTextBoxColumn.Width = 400;
            // 
            // changeTrackingEnabledDataGridViewCheckBoxColumn
            // 
            this.changeTrackingEnabledDataGridViewCheckBoxColumn.DataPropertyName = "ChangeTrackingEnabled";
            this.changeTrackingEnabledDataGridViewCheckBoxColumn.HeaderText = "Change Tracking Enabled";
            this.changeTrackingEnabledDataGridViewCheckBoxColumn.Name = "changeTrackingEnabledDataGridViewCheckBoxColumn";
            // 
            // slimEntityMetadataBindingSource
            // 
            this.slimEntityMetadataBindingSource.DataSource = typeof(Cobalt.XrmToolbox.EntityUpdater.EntityUpdaterControl.SlimEntityMetadata);
            // 
            // submitUpdateBtn
            // 
            this.submitUpdateBtn.Location = new System.Drawing.Point(595, 149);
            this.submitUpdateBtn.Name = "submitUpdateBtn";
            this.submitUpdateBtn.Size = new System.Drawing.Size(92, 23);
            this.submitUpdateBtn.TabIndex = 6;
            this.submitUpdateBtn.Text = "Update";
            this.submitUpdateBtn.UseVisualStyleBackColor = true;
            this.submitUpdateBtn.Visible = false;
            this.submitUpdateBtn.Click += new System.EventHandler(this.submitUpdateBtn_Click);
            // 
            // unmanagedSolutionsList
            // 
            this.unmanagedSolutionsList.FormattingEnabled = true;
            this.unmanagedSolutionsList.Location = new System.Drawing.Point(556, 48);
            this.unmanagedSolutionsList.Name = "unmanagedSolutionsList";
            this.unmanagedSolutionsList.Size = new System.Drawing.Size(171, 95);
            this.unmanagedSolutionsList.TabIndex = 7;
            this.unmanagedSolutionsList.Visible = false;
            // 
            // unmanagedSolutionLabel
            // 
            this.unmanagedSolutionLabel.AutoSize = true;
            this.unmanagedSolutionLabel.Location = new System.Drawing.Point(557, 29);
            this.unmanagedSolutionLabel.Name = "unmanagedSolutionLabel";
            this.unmanagedSolutionLabel.Size = new System.Drawing.Size(152, 13);
            this.unmanagedSolutionLabel.TabIndex = 8;
            this.unmanagedSolutionLabel.Text = "Targeted Unmanaged Solution";
            this.unmanagedSolutionLabel.Visible = false;
            // 
            // EntityUpdaterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.unmanagedSolutionLabel);
            this.Controls.Add(this.unmanagedSolutionsList);
            this.Controls.Add(this.submitUpdateBtn);
            this.Controls.Add(this.entityDataGrid);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "EntityUpdaterControl";
            this.Size = new System.Drawing.Size(735, 581);
            this.Load += new System.EventHandler(this.EntityUpdaterControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entityDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slimEntityMetadataBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.ToolStripButton loadMetadataButton;
        private System.Windows.Forms.DataGridView entityDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn entityNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn changeTrackingEnabledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.BindingSource slimEntityMetadataBindingSource;
        private System.Windows.Forms.Button submitUpdateBtn;
        private System.Windows.Forms.ListBox unmanagedSolutionsList;
        private System.Windows.Forms.Label unmanagedSolutionLabel;
    }
}

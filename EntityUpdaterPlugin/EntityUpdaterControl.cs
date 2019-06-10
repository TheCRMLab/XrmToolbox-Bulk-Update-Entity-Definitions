using System;
using System.Collections.Generic;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Messages;
using System.Linq;
using System.Drawing;

namespace Cobalt.XrmToolbox.EntityUpdater
{
    public partial class EntityUpdaterControl : PluginControlBase
    {
        private Settings mySettings;
        public EntityUpdaterControl()
        {
            InitializeComponent();
        }
        private void EntityUpdaterControl_Load(object sender, EventArgs e)
        {
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }
        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }
        private void LoadMetadata(bool initalLoad = false)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = initalLoad ? "Retrieving Entity Metadata" : "Updating and Publishing to CRM",
                Work = (worker, args) =>
                {
                    RetrieveAllEntitiesRequest request = new RetrieveAllEntitiesRequest();
                    request.EntityFilters = Microsoft.Xrm.Sdk.Metadata.EntityFilters.Entity;
                    var response = Service.Execute(request) as RetrieveAllEntitiesResponse;

                    List<SlimEntityMetadata> metadata = new List<SlimEntityMetadata>();
                    foreach (var ent in response.EntityMetadata
                        .Where(x => x.DisplayName != null && x.DisplayName.UserLocalizedLabel != null 
                            //&& x.IsValidForAdvancedFind != null && x.IsValidForAdvancedFind.Value
                            && x.CanChangeTrackingBeEnabled != null && x.CanChangeTrackingBeEnabled.Value)
                        .OrderBy(x => x.DisplayName.UserLocalizedLabel.Label))
                    {
                        metadata.Add(new SlimEntityMetadata()
                        {
                            EntityName = ent.DisplayName.UserLocalizedLabel.Label,
                            ChangeTrackingEnabled = ent.ChangeTrackingEnabled.HasValue && ent.ChangeTrackingEnabled.Value,
                            SchemaName = ent.SchemaName,
                            LogicalName = ent.LogicalName
                        });
                    }
                    args.Result = metadata;
                },
                // Work is completed, results can be shown to user  
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        // Binding result data to ListBox Control  
                        entityDataGrid.Visible = true;
                        entityDataGrid.DataSource = null;
                        this.unmanagedSolutionsList.DataSource = this.Solutions;

                        var lstResults = (args.Result as List<SlimEntityMetadata>);
                        entityDataGrid.DataSource = lstResults;

                        for (int index = 0; index < lstResults.Count; index ++)
                        {
                            var item = lstResults[index];
                            if(item.ChangeTrackingEnabled)
                            {
                                entityDataGrid.Rows[index].ReadOnly = true;

                                foreach(var cell in entityDataGrid.Rows[index].Cells)
                                    (cell as DataGridViewCell).Style.BackColor = Color.LightGray;
                            }
                        }
                    }

                    submitUpdateBtn.Visible = true;
                    unmanagedSolutionsList.Visible = true;
                    unmanagedSolutionLabel.Visible = true;
                    loadMetadataButton.Visible = false;
                },
                IsCancelable = false               
            });
        }

        private void loadMetadataButton_Click(object sender, EventArgs e)
        {
            LoadMetadata(true);
        }
        private void submitUpdateBtn_Click(object sender, EventArgs e)
        {
            submitUpdateBtn.Visible = false;
            UpdateCrm(this.unmanagedSolutionsList.SelectedItem.ToString());
        }
        private void UpdateCrm(string solutionName)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Updating CRM",
                Work = (worker, args) =>
                {
                    bool publishRequired = false;
                    foreach (DataGridViewRow row in this.entityDataGrid.Rows)
                    {
                        SlimEntityMetadata metaData = row.DataBoundItem as SlimEntityMetadata;

                        if (metaData.ChangeTrackingEnabled)
                        {
                            bool selectedForChangeTrackingUpdate = false;
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                if (cell is DataGridViewCheckBoxCell && !(cell as DataGridViewCheckBoxCell).ReadOnly)
                                    selectedForChangeTrackingUpdate = true;
                            }

                            if (selectedForChangeTrackingUpdate)
                            {
                                publishRequired = true;
                                UpdateEntityRequest entrequest = new UpdateEntityRequest()
                                {
                                    Entity = new Microsoft.Xrm.Sdk.Metadata.EntityMetadata()
                                    {
                                        ChangeTrackingEnabled = true,
                                        LogicalName = metaData.LogicalName,
                                    },
                                    SolutionUniqueName = solutionName
                                };

                                Service.Execute(entrequest);
                            }
                        }
                    }

                    if(publishRequired)
                    {
                        PublishAllXmlRequest pubCustomizationRequest = new PublishAllXmlRequest();
                        Service.Execute(pubCustomizationRequest);
                    }

                    RetrieveAllEntitiesRequest request = new RetrieveAllEntitiesRequest();
                    request.EntityFilters = Microsoft.Xrm.Sdk.Metadata.EntityFilters.Entity;
                    var response = Service.Execute(request) as RetrieveAllEntitiesResponse;

                    List<SlimEntityMetadata> metadata = new List<SlimEntityMetadata>();
                    foreach (var ent in response.EntityMetadata
                        .Where(x => x.DisplayName != null && x.DisplayName.UserLocalizedLabel != null
                            //&& x.IsValidForAdvancedFind != null && x.IsValidForAdvancedFind.Value
                            && x.CanChangeTrackingBeEnabled != null && x.CanChangeTrackingBeEnabled.Value)
                        .OrderBy(x => x.DisplayName.UserLocalizedLabel.Label))
                    {
                        metadata.Add(new SlimEntityMetadata()
                        {
                            EntityName = ent.DisplayName.UserLocalizedLabel.Label,
                            ChangeTrackingEnabled = ent.ChangeTrackingEnabled.HasValue && ent.ChangeTrackingEnabled.Value,
                            SchemaName = ent.SchemaName,
                            LogicalName = ent.LogicalName
                        });
                    }

                    args.Result = metadata;
                },
                // Work is completed, results can be shown to user  
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        // Binding result data to ListBox Control  
                        entityDataGrid.Visible = true;
                        entityDataGrid.DataSource = null;
                        this.unmanagedSolutionsList.DataSource = this.Solutions;

                        var lstResults = (args.Result as List<SlimEntityMetadata>);
                        entityDataGrid.DataSource = lstResults;

                        for (int index = 0; index < lstResults.Count; index++)
                        {
                            var item = lstResults[index];
                            if (item.ChangeTrackingEnabled)
                            {
                                entityDataGrid.Rows[index].ReadOnly = true;

                                foreach (var cell in entityDataGrid.Rows[index].Cells)
                                    (cell as DataGridViewCell).Style.BackColor = Color.LightGray;
                            }
                        }
                    }

                    submitUpdateBtn.Visible = true;
                    unmanagedSolutionsList.Visible = true;
                    unmanagedSolutionLabel.Visible = true;
                    loadMetadataButton.Visible = false;
                },
                IsCancelable = false
            });
        }

        private List<string> solutions = null;
        public List<string> Solutions
        {
            get
            {
                if(solutions == null)
                {
                    solutions = new List<string>();
                    QueryExpression unmanagedSolutionQuery = new QueryExpression("solution");
                    unmanagedSolutionQuery.ColumnSet = new ColumnSet(true);
                    FilterExpression filterExpression = new FilterExpression(LogicalOperator.And);
                    ConditionExpression managedConditionExpression = new ConditionExpression("ismanaged", ConditionOperator.Equal, false);

                    filterExpression.AddCondition(managedConditionExpression);
                    unmanagedSolutionQuery.Criteria = filterExpression;

                    var solutionResponse = Service.RetrieveMultiple(unmanagedSolutionQuery);

                    foreach (var solution in solutionResponse.Entities)
                    {
                        solutions.Add(solution["uniquename"].ToString());
                    }
                }

                return solutions;
            }
        }

        public class SlimEntityMetadata
        {
            public string DisplayLabel
            {
                get
                {
                    return $"{EntityName} ({SchemaName})";
                }
            }
            public string EntityName { get; set; }
            public bool ChangeTrackingEnabled { get; set; }
            public string SchemaName { get; set; }
            public string LogicalName { get; set; }
        }
    }
}
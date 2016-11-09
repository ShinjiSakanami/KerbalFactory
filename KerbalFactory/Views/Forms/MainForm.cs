using KFUtil;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KerbalFactory.Views
{
    public partial class MainForm : BaseForm
    {
        private static MainForm _instance;

        private PartList _parts;

        private PartResourceDefinitionList _resources;

        public static MainForm Instance
        {
            get
            {
                return MainForm._instance;
            }
        }

        public MainForm() : base()
        {
            MainForm._instance = this;
            this.InitializeComponent();
            this.InitSettings();
            this.InitDebug();
        }

        private void InitSettings()
        {
            KFSettings.Instance.Load();
        }

        private void InitDebug()
        {
            Debug.SetLogHandler(new KFLogHandler());
        }

        public async void LoadGameDatabase()
        {
            this.TabControl.SelectTab(2);
            this.PartsTable.Clear();
            this.ResourcesTable.Clear();
            GamePath kspPath = KFSettings.Instance.CurrentPath;
            if (kspPath != null)
            {
                this.AddMessage("Start game database load...");
                await Task.Run(() => GameDatabase.Instance.LoadGameDatabase(kspPath.FullPath));
                this.AddMessage("Game database loaded.");
                this.AddMessage("Start resource definitions load...");
                await Task.Run(() => GameDatabase.Instance.LoadResourceDefinitions());
                this._resources = GameDatabase.Instance.ResourceDefinitions;
                int count = this._resources.Count;
                this.AddMessage(count + " resource definitions loaded.");
                this.AddMessage("Start parts load...");
                await Task.Run(() => GameDatabase.Instance.LoadParts());
                this._parts = GameDatabase.Instance.Parts;
                count = this._parts.Count;
                this.AddMessage(count + " parts loaded.");
                this.Text = "KerbalFactory " + KFSettings.AppVersion + " - KSP " + kspPath.Version + " (" + kspPath.FullPath + ")";
                this.LoadDataTest();
                this.PartsTable.UpdateCountLabel();
                this.ResourcesTable.UpdateCountLabel();
                this.openKSPDirectoryToolStripMenuItem.Enabled = true;
                this.refreshDataToolStripMenuItem.Enabled = true;
                this.TabControl.SelectTab(0);
            }
            else
            {
                this.AddMessage("No valid KSP folder selected!");
                this.Text = "KerbalFactory " + KFSettings.AppVersion;
                this.openKSPDirectoryToolStripMenuItem.Enabled = false;
                this.refreshDataToolStripMenuItem.Enabled = false;
            }
        }

        private void LoadDataTest()
        {
            List<string> resources = new List<string>();
            List<string> resourceMods = new List<string>();
            List<string> partMods = new List<string>();
            List<string> authors = new List<string>();
            List<string> manufacturers = new List<string>();
            List<string> categories = new List<string>();
            List<string> techs = new List<string>();
            this.InitResourcesTable();
            this.InitPartsTableStart();
            foreach (PartResourceDefinition resource in this._resources)
            {
                if (!resources.Contains(resource.name))
                {
                    resources.Add(resource.name);
                }
                if (!resourceMods.Contains(resource.Mod))
                {
                    resourceMods.Add(resource.Mod);
                }
                if (resource.name != "ElectricCharge")
                {
                    this.PartsTable.AddColumn(resource.name + " (u)", "Resources", 100, false);
                    this.PartsTable.AddColumn(resource.name + " (L)", "Resources Volume (L)", 100, false);
                    this.PartsTable.AddColumn(resource.name + " (t)", "Resources Mass (t)", 100, false);
                    this.PartsTable.AddColumn(resource.name + " (f)", "Resources Cost (f)", 100, false);
                }
                this.ResourcesTable.AddRow(new object[]
                {
                    resource.name,
                    resource.Mod,
                    resource.abbreviation,
                    resource.unitCost,
                    resource.volume,
                    (resource.volume/1000),
                    resource.density,
                    ((resource.density*1000)/(resource.volume/1000)),
                    resource.hsp,
                    resource.isTweakable,
                    resource.isVisible,
                    resource.flowMode,
                    resource.transfer,
                    ConfigNode.WriteColor(resource.color)
                });
            }
            this.InitPartsTableEnd();
            foreach (Part part in this._parts)
            {
                if (!partMods.Contains(part.Mod))
                {
                    partMods.Add(part.Mod);
                }
                if (!authors.Contains(part.author))
                {
                    authors.Add(part.author);
                }
                if (!manufacturers.Contains(part.manufacturer))
                {
                    manufacturers.Add(part.manufacturer);
                }
                if (!categories.Contains(part.category.ToString()))
                {
                    categories.Add(part.category.ToString());
                }
                if (!techs.Contains(part.TechRequired))
                {
                    techs.Add(part.TechRequired);
                }
                double skinMaxTemp = part.skinMaxTemp;
                if (skinMaxTemp < 0)
                {
                    skinMaxTemp = part.maxTemp;
                }
                string internalName = string.Empty;
                if (part.InternalConfig != null)
                {
                    internalName = part.InternalConfig.GetValue("name");
                }
                List<object> resValues = new List<object>();
                double resTotal = 0.0;
                double resVolume = 0.0;
                double resMass = 0.0;
                double resCost = 0.0;
                double electricCharge = 0.0;
                foreach (string resName in resources)
                {
                    if (part.Resources.Contains(resName))
                    {
                        PartResource resource = part.Resources.Get(resName);
                        if (resource != null)
                        {
                            if (resource.name == "ElectricCharge")
                            {
                                electricCharge = resource.maxAmount;
                            }
                            else
                            {
                                PartResourceDefinition info = resource.Info;
                                resValues.Add(resource.maxAmount);
                                resValues.Add(resource.maxAmount * info.volume);
                                resValues.Add(resource.maxAmount * info.density);
                                resValues.Add(resource.maxAmount * info.unitCost);
                                resTotal += resource.maxAmount;
                                resVolume += resource.maxAmount * info.volume;
                                resMass += resource.maxAmount * info.density;
                                resCost += resource.maxAmount * info.unitCost;
                            }
                        }
                    }
                    else
                    {
                        resValues.Add(0.0);
                        resValues.Add(0.0);
                        resValues.Add(0.0);
                        resValues.Add(0.0);
                    }
                }
                List<object> values = new List<object>()
                {
                    part.name,
                    part.Mod,
                    part.author,
                    part.mesh,
                    part.scale,
                    part.rescaleFactor,
                    part.attachRules,
                    part.bulkheadProfiles,
                    part.CoMOffset,
                    part.CoLOffset,
                    part.CoPOffset,
                    part.CenterOfDisplacement,
                    part.CenterOfBuoyancy,
                    part.buoyancy,
                    part.title,
                    part.category,
                    part.manufacturer,
                    part.TechRequired,
                    part.entryCost,
                    part.cost,
                    part.mass,
                    part.dragModelType,
                    part.maximum_drag,
                    part.minimum_drag,
                    part.angularDrag,
                    part.crashTolerance,
                    part.vesselType,
                    part.CrewCapacity,
                    internalName,
                    part.maxTemp,
                    skinMaxTemp,
                    electricCharge
                };
                values.AddRange(resValues);
                values.Add(resTotal);
                values.Add(resVolume);
                values.Add(resMass);
                values.Add(resCost);
                values.Add(part.mass);
                values.Add(part.cost);
                this.PartsTable.AddRow(values.ToArray());
            }
            this.ResourcesTable.AddFilter("Mod", resourceMods.ToArray());
            this.PartsTable.AddFilter("Mod", partMods.ToArray());
            this.PartsTable.AddFilter("Author", authors.ToArray());
            this.PartsTable.AddFilter("Manufacturer", manufacturers.ToArray());
            this.PartsTable.AddFilter("Category", categories.ToArray());
            this.PartsTable.AddFilter("Technology", techs.ToArray());
            this.PartsTable.AddFilter("Resources", resources.ToArray());
        }

        private void InitPartsTableStart()
        {
            this.PartsTable.AddColumn("Name", "General Parameters", 150);
            this.PartsTable.AddColumn("Mod", "General Parameters", 100);
            this.PartsTable.AddColumn("Author", "General Parameters", 150);

            this.PartsTable.AddColumn("Mesh", "Asset Parameters", 100, false);
            this.PartsTable.AddColumn("Scale", "Asset Parameters", 100, false);
            this.PartsTable.AddColumn("Resclae Factor", "Asset Parameters", 100, false);

            this.PartsTable.AddColumn("Attach Rules", "Node Definitions", 120, false);
            this.PartsTable.AddColumn("Bulkhead Profiles", "Node Definitions", 120, false);
            this.PartsTable.AddColumn("Center of Mass", "Node Definitions", 80, false);
            this.PartsTable.AddColumn("Center of Lift", "Node Definitions", 80, false);
            this.PartsTable.AddColumn("Center of Pressure", "Node Definitions", 80, false);
            this.PartsTable.AddColumn("Center of Displacement", "Node Definitions", 80, false);
            this.PartsTable.AddColumn("Center of Buoyancy", "Node Definitions", 80, false);
            this.PartsTable.AddColumn("Buoyancy", "Node Definitions", 80, false);

            this.PartsTable.AddColumn("Title", "Editor Parameters", 300);
            this.PartsTable.AddColumn("Category", "Editor Parameters", 100);
            this.PartsTable.AddColumn("Manufacturer", "Editor Parameters", 150);
            this.PartsTable.AddColumn("Technology", "Editor Parameters", 150);
            this.PartsTable.AddColumn("Unlock Cost (f)", "Editor Parameters", 80);
            this.PartsTable.AddColumn("Full Cost (f)", "Editor Parameters", 80);

            this.PartsTable.AddColumn("Dry Mass (t)", "Standard Part Parameters", 80);
            this.PartsTable.AddColumn("Drag Model", "Standard Part Parameters", 100);
            this.PartsTable.AddColumn("Maximum Drag", "Standard Part Parameters", 80);
            this.PartsTable.AddColumn("Minimum Drag", "Standard Part Parameters", 80);
            this.PartsTable.AddColumn("Angular Drag", "Standard Part Parameters", 80);
            this.PartsTable.AddColumn("Crash Tolerance (m/s)", "Standard Part Parameters", 120);
            this.PartsTable.AddColumn("Vessel Type", "Standard Part Parameters", 120);

            this.PartsTable.AddColumn("Crew Capacity", "Internal Setup", 80, false);
            this.PartsTable.AddColumn("Internal Name", "Internal Setup", 120, false);

            this.PartsTable.AddColumn("Max. Temperature (K)", "Thermal Parameters", 120);
            this.PartsTable.AddColumn("Skin Max. Temperature (K)", "Thermal Parameters", 120);

            this.PartsTable.AddColumn("Electric Capacity (kW)", "Resources", 100, false);
        }

        private void InitPartsTableEnd()
        {
            this.PartsTable.AddColumn("Total Resources (u)", "Calculations", 120, false);
            this.PartsTable.AddColumn("Total Resources Volume (L)", "Calculations", 120, false);
            this.PartsTable.AddColumn("Total Resources Mass (t)", "Calculations", 120, false);
            this.PartsTable.AddColumn("Total Resources Cost (f)", "Calculations", 120, false);
            this.PartsTable.AddColumn("Full Mass (t)", "Calculations", 100, false);
            this.PartsTable.AddColumn("Dry Cost (f)", "Calculations", 100, false);
        }

        private void InitResourcesTable()
        {
            this.ResourcesTable.AddColumn("Name", "General Parameters", 150);
            this.ResourcesTable.AddColumn("Mod", "General Parameters", 100);
            this.ResourcesTable.AddColumn("Abbreviation", "General Parameters", 80);
            this.ResourcesTable.AddColumn("Unit Cost (f/u)", "General Parameters", 80);
            this.ResourcesTable.AddColumn("Volume (L/u)", "General Parameters", 80);
            this.ResourcesTable.AddColumn("Volume (m3/u)", "Calculations", 80);
            this.ResourcesTable.AddColumn("Density (t/u)", "General Parameters", 80);
            this.ResourcesTable.AddColumn("Density (kg/m3)", "Calculations", 80);
            this.ResourcesTable.AddColumn("Specific Heat Capacity (kJ/t-K)", "General Parameters", 120);
            this.ResourcesTable.AddColumn("Is Tweakable", "General Parameters", 80);
            this.ResourcesTable.AddColumn("Is Visible", "General Parameters", 80);
            this.ResourcesTable.AddColumn("Flow Mode", "General Parameters", 160);
            this.ResourcesTable.AddColumn("Transfer Mode", "General Parameters", 120);
            this.ResourcesTable.AddColumn("Color (RGBA)", "General Parameters", 80);
        }
        
        public void AddMessage(string message, bool log = true)
        {
            string text = KFLogHandler.FormatMessage(Logger.LogType.Log, message);
            this.InvokeIfRequired(() => this.LogControl.LogMessage(text));
            if (log)
            {
                Debug.Log(message, this);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void refreshDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadGameDatabase();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.toolsToolStripMenuItem.Visible = false;
            this.Location = KFSettings.Instance.WindowLoc;
            this.Size = KFSettings.Instance.WindowSize;
            this.Text = "KerbalFactory " + KFSettings.AppVersion;
            this.LoadGameDatabase();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.ShowDialog(this);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            KFSettings.Instance.WindowLoc = this.Location;
            KFSettings.Instance.WindowSize = this.Size;
            KFSettings.Instance.Save();
        }

        private void openKSPDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GamePath kspPath = KFSettings.Instance.CurrentPath;
            if (kspPath != null)
            {
                System.Diagnostics.Process.Start(kspPath.FullPath);
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm();
            form.ShowDialog(this);
        }

        private void selectKSPPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PathsForm form = new PathsForm();
            form.ShowDialog(this);
        }
    }
}

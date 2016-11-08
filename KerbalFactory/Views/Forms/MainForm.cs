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
                //this.LoadResourcesTable();
                int count = this._resources.Count;
                this.AddMessage(count + " resource definitions loaded.");
                this.AddMessage("Start parts load...");
                await Task.Run(() => GameDatabase.Instance.LoadParts());
                this._parts = GameDatabase.Instance.Parts;
               // this.LoadPartsTable();
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

        private void InitPartsTable()
        {
            this.PartsTable.AddColumn("Name", "General Parameters", 150);
            this.PartsTable.AddColumn("Mod", "General Parameters", 100);
            this.PartsTable.AddColumn("Author", "General Parameters", 150);
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
            this.PartsTable.AddColumn("Max. Temperature (K)", "Thermal Parameters", 120);
            this.PartsTable.AddColumn("Skin Max. Temperature (K)", "Thermal Parameters", 120);
            this.PartsTable.AddColumn("Electric Capacity (kW)", "Resources", 100, false);
            foreach (PartResourceDefinition resource in this._resources)
            {
                if (resource.name != "ElectricCharge")
                {
                    this.PartsTable.AddColumn(resource.name + " (u)", "Resources", 100, false);
                    this.PartsTable.AddColumn(resource.name + " (L)", "Resources Volume (L)", 100, false);
                    this.PartsTable.AddColumn(resource.name + " (t)", "Resources Mass (t)", 100, false);
                    this.PartsTable.AddColumn(resource.name + " (f)", "Resources Cost (f)", 100, false);
                }
            }
            this.PartsTable.AddColumn("Total Resources (u)", "Calculations", 120, false);
            this.PartsTable.AddColumn("Total Resources Volume (L)", "Calculations", 120, false);
            this.PartsTable.AddColumn("Total Resources Mass (t)", "Calculations", 120, false);
            this.PartsTable.AddColumn("Total Resources Cost (f)", "Calculations", 120, false);
            this.PartsTable.AddColumn("Full Mass (t)", "Calculations", 100, false);
            this.PartsTable.AddColumn("Dry Cost (f)", "Calculations", 100, false);
        }

        private void InitPartsFilters()
        {
            List<string> mods = new List<string>();
            List<string> authors = new List<string>();
            List<string> manufacturers = new List<string>();
            List<string> categories = new List<string>();
            List<string> techs = new List<string>();
            List<string> resources = new List<string>();
            foreach (Part part in this._parts)
            {
                mods.Add(part.Mod);
                authors.Add(part.author);
                manufacturers.Add(part.manufacturer);
                categories.Add(part.category.ToString());
                techs.Add(part.TechRequired);
            }
            foreach(PartResourceDefinition def in this._resources)
            {
                resources.Add(def.name);
            }
            this.PartsTable.AddFilter("Mod", mods.ToArray());
            this.PartsTable.AddFilter("Author", authors.ToArray());
            this.PartsTable.AddFilter("Manufacturer",  manufacturers.ToArray());
            this.PartsTable.AddFilter("Category",  categories.ToArray());
            this.PartsTable.AddFilter("Technology",  techs.ToArray());
            this.PartsTable.AddFilter("Resources", resources.ToArray());
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

        private void InitResourcesFilters()
        {
            List<string> mods = new List<string>();
            foreach (PartResourceDefinition resource in this._resources)
            {
                mods.Add(resource.Mod);
            }
            this.ResourcesTable.AddFilter("Mod", mods.ToArray());
        }
        
        private void LoadPartsTable()
        {
            this.InitPartsTable();
            foreach (Part part in this._parts)
            {
                double skinMaxTemp = part.skinMaxTemp;
                if (skinMaxTemp < 0)
                {
                    skinMaxTemp = part.maxTemp;
                }
                List<object> resValues = new List<object>();
                double resTotal = 0.0;
                double resVolume = 0.0;
                double resMass = 0.0;
                double resCost = 0.0;
                double electricCharge = 0.0;
                foreach (PartResourceDefinition info in this._resources)
                {
                    PartResource resource = part.Resources.Get(info.name);
                    if (resource != null)
                    {
                        if (resource.name == "ElectricCharge")
                        {
                            electricCharge = resource.maxAmount;
                        }
                        else
                        {
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
            this.InitPartsFilters();
        }

        private void LoadResourcesTable()
        {
            this.InitResourcesTable();
            foreach(PartResourceDefinition res in this._resources)
            {
                this.ResourcesTable.AddRow(new object[]
                {
                    res.name,
                    res.Mod,
                    res.abbreviation,
                    res.unitCost,
                    res.volume,
                    (res.volume/1000),
                    res.density,
                    ((res.density*1000)/(res.volume/1000)),
                    res.hsp,
                    res.isTweakable,
                    res.isVisible,
                    res.flowMode,
                    res.transfer,
                    ConfigNode.WriteColor(res.color)
                });
            }
            this.InitResourcesFilters();
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

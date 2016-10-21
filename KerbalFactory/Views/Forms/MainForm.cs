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
                this.LoadResourcesTable();
                int count = this._resources.Count;
                this.AddMessage(count + " resource definitions loaded.");
                this.AddMessage("Start parts load...");
                await Task.Run(() => GameDatabase.Instance.LoadParts());
                this._parts = GameDatabase.Instance.Parts;
                this.LoadPartsTable();
                count = this._parts.Count;
                this.AddMessage(count + " parts loaded.");
                this.Text = "KerbalFactory " + KFSettings.AppVersion + " - KSP " + kspPath.Version + " (" + kspPath.FullPath + ")";
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

        private void InitPartsTable()
        {
            this.PartsTable.AddColumn("Name", "General Parameters", 150);
            this.PartsTable.AddColumn("Mod", "General Parameters", 100);
            this.PartsTable.AddColumn("Author", "General Parameters", 150);
            this.PartsTable.AddColumn("Title", "Editor Parameters", 300);
            this.PartsTable.AddColumn("Category", "Editor Parameters", 100);
            this.PartsTable.AddColumn("Manufacturer", "Editor Parameters", 150);
            this.PartsTable.AddColumn("Tech Required", "Editor Parameters", 150);
            this.PartsTable.AddColumn("Entry Cost (f)", "Editor Parameters", 80);
            this.PartsTable.AddColumn("Full Cost (f)", "Editor Parameters", 80);
            this.PartsTable.AddColumn("Dry Mass (t)", "Standard Part Parameters", 80);
            this.PartsTable.AddColumn("Drag Model", "Standard Part Parameters", 100);
            this.PartsTable.AddColumn("Maximum Drag", "Standard Part Parameters", 80);
            this.PartsTable.AddColumn("Minimum Drag", "Standard Part Parameters", 80);
            this.PartsTable.AddColumn("Angular Drag", "Standard Part Parameters", 80);
            this.PartsTable.AddColumn("Crash Tolerance", "Standard Part Parameters", 80);
            this.PartsTable.AddColumn("Max Temperature", "Thermal Parameters", 80);
            this.PartsTable.AddColumn("Skin Max Temperature", "Thermal Parameters", 80);
            foreach (PartResourceDefinition resource in this._resources)
            {
                this.PartsTable.AddColumn(resource.name + " (u)", "Resources", 100);
            }
            foreach (PartResourceDefinition resource in this._resources)
            {
                if (resource.name == "ElectricCharge")
                {
                    this.PartsTable.AddColumn(resource.name + " (W)", "Calculations", 100);
                }
                else
                {
                    this.PartsTable.AddColumn(resource.name + " (L)", "Calculations", 100);
                }
            }
            this.PartsTable.AddColumn("Total Resources (u)", "Calculations", 100);
            this.PartsTable.AddColumn("Total Resources (L)", "Calculations", 100);
            this.PartsTable.AddColumn("Resources Cost (f)", "Calculations", 100);
            this.PartsTable.AddColumn("Resources Mass (t)", "Calculations", 100);
            this.PartsTable.AddColumn("Dry Cost (f)", "Calculations", 100);
            this.PartsTable.AddColumn("Full Mass (t)", "Calculations", 100);
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
            this.PartsTable.AddFilter("Tech Required",  techs.ToArray());
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
                    skinMaxTemp
                };
                double total = 0;
                double mass = 0;
                double cost = 0;
                foreach (PartResourceDefinition def in this._resources)
                {
                    if (part.Resources.Contains(def.name))
                    {
                        PartResource res = part.Resources[def.name];
                        values.Add(res.maxAmount);
                        total += res.maxAmount;
                        cost += res.maxAmount * def.unitCost;
                        mass += res.maxAmount * def.density;
                    }
                    else
                    {
                        values.Add(0);
                    }
                }
                double total2 = 0;
                foreach (PartResourceDefinition def in this._resources)
                {
                    if (part.Resources.Contains(def.name))
                    {
                        PartResource res = part.Resources[def.name];
                        if (res.name == "ElectricCharge")
                        {
                            values.Add(res.maxAmount * 1000);
                        }
                        else
                        {
                            values.Add(res.maxAmount * def.volume);
                            total2 += res.maxAmount * def.volume;
                        }
                    }
                    else
                    {
                        values.Add(0);
                    }
                }
                values.Add(total);
                values.Add(total2);
                values.Add(cost);
                values.Add(mass);
                values.Add(part.cost - cost);
                values.Add(part.mass + mass);
                this.PartsTable.AddRow(values.ToArray());
            }
            this.InitPartsFilters();
            this.PartsTable.CheckTrees();
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
            this.ResourcesTable.CheckTrees();
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

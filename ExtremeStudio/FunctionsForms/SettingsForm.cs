using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExtremeCore.Classes;
using ExtremeStudio.Classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Resources;

namespace ExtremeStudio.FunctionsForms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            FormClosing += FormClosingCompiler;
            FormClosing += ServerCfgFormClosing;
            FormClosing += SettingsForm_FormClosing;
        }

        string _configDirPath;

        //A function for external execution.
        public void ReloadInfoAll()
        {
            if (IsGlobal)
            {
                serverCFGTabPage.Enabled = false;
            }
            else
            {
                serverCFGTabPage.Enabled = true;
            }

            CheckPath();

            LoadColors();
            LoadCompiler();
            if(!IsGlobal) LoadServerCfg();
            LoadHotkeys();
        }

        [Localizable(false)]
        private void CheckPath()
        {
            //Just make sure the _configDirPath is not null.
            if (Directory.Exists(_configDirPath) == false)
            {
                _configDirPath = Program.MainForm.CurrentProject.ProjectPath + "/configs/";
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            ReloadInfoAll();
        }

        bool _isGlobal;

        public bool IsGlobal
        {
            set
            {
                if (value)
                {
                    _isGlobal = true;
                    _configDirPath = Program.MainForm.ApplicationFiles + "/configs/";
                    Text = translations.SettingsForm_IsGlobal_SettingsGLOBAL;
                    ReloadInfoAll();
                }
                else
                {
                    _isGlobal = false;
                    _configDirPath = Program.MainForm.CurrentProject.ProjectPath + "/configs/";
                    Text = translations.SettingsForm_IsGlobal_SettingsPROJECT;
                    ReloadInfoAll();
                }
            }
            get => _isGlobal;
        }

        #region Colorizer Stuff

        //The main colors info:
        public SyntaxInfo ColorsInfo = new SyntaxInfo();

        public delegate void OnColorsSettingsChangeEventHandler();

        private OnColorsSettingsChangeEventHandler _onColorsSettingsChangeEvent;

        public event OnColorsSettingsChangeEventHandler OnColorsSettingsChange
        {
            add => _onColorsSettingsChangeEvent =
                (OnColorsSettingsChangeEventHandler) Delegate.Combine(_onColorsSettingsChangeEvent, value);
            remove => _onColorsSettingsChangeEvent =
                (OnColorsSettingsChangeEventHandler) Delegate.Remove(_onColorsSettingsChangeEvent, value);
        }


        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfigsHandler configHandler =
                new ConfigsHandler(_configDirPath + "/themeInfo.json") {["Colors"] = ColorsInfo};
            configHandler.Save();
        }

        private void colorsSettings_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            _onColorsSettingsChangeEvent?.Invoke();
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog
            {
                Title = Convert.ToString(translations.SettingsForm_exportBtn_Click_OpenFileDialogTitle),
                Filter = "ExtremeStudio Theme (*.estheme) |*.estheme"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ConfigsHandler configHandler = new ConfigsHandler(dlg.FileName);
                configHandler["Colors"] = ColorsInfo;
                configHandler.Save();
                MessageBox.Show(translations.SettingsForm_exportBtn_Click_ExporteSuccess, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Title = Convert.ToString(translations.SettingsForm_importBtn_Click_OpenFileDialogTitle),
                Filter = "ExtremeStudio Theme (*.estheme) |*.estheme"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ConfigsHandler configHandler = new ConfigsHandler(dlg.FileName);
                ColorsInfo = ((JObject)configHandler["Colors"]).ToObject<SyntaxInfo>();
                colorsSettings.SelectedObject = ColorsInfo;
            }
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(translations.SettingsForm_resetBtn_Click_ResetDefaultSettings, "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                //Delete Old:
                File.Delete(
                    _configDirPath + "/themeInfo.json");

                //Get New
                ConfigsHandler configHandler = new ConfigsHandler(_configDirPath + "/themeInfo.json", Properties.Resources.defaultThemeInfo);
                ColorsInfo = ((JObject)configHandler["Colors"]).ToObject<SyntaxInfo>();
                colorsSettings.SelectedObject = ColorsInfo;
            }
        }

        [Localizable(false)]
        private void LoadColors()
        {
            CheckPath();

            ConfigsHandler configHandler = new ConfigsHandler(_configDirPath + "/themeInfo.json",
                Properties.Resources.defaultThemeInfo);
            ColorsInfo = ((JObject)configHandler["Colors"]).ToObject<SyntaxInfo>();
            colorsSettings.SelectedObject = ColorsInfo;
            if (_onColorsSettingsChangeEvent != null)
                _onColorsSettingsChangeEvent();
        }

        #endregion

        #region Compiler Stuff

        private void reportGenCheck_CheckedChanged(object sender, EventArgs e)
        {
            reportGenDirText.Enabled = reportGenCheck.Checked;
        }

        [Localizable(false)]
        private void FormClosingCompiler(object sender, EventArgs e)
        {
            ConfigsHandler configHandler =
                new ConfigsHandler(_configDirPath + "/compiler.json")
                {
                    ["activeDir"] = activeDirText.Text,
                    ["includesDir"] = includesDirText.Text,
                    ["ouputDir"] = ouputDirText.Text,
                    ["reportGenCheck"] = reportGenCheck.Checked,
                    ["reportGenDir"] = reportGenDirText.Text,
                    ["debugLevel"] = debugLevelUpDown.Value,
                    ["optiLevel"] = optiLevelUpDown.Value,
                    ["tabSize"] = tabSizeUpDown.Value,
                    ["skipLines"] = skipLinesUpDown.Value,
                    ["parentheses"] = parenthesesCheck.Checked,
                    ["semicolon"] = semiColonCheck.Checked,
                    ["customArgs"] = customArgsText.Text
                };
            configHandler.Save();
        }

        [Localizable(false)]
        private void LoadCompiler()
        {
            CheckPath();

            //Basically, If its not been found, We will set the boxes with the default ourselves.
            try
            {
                ConfigsHandler configHandler = new ConfigsHandler(_configDirPath + "/compiler.json");
                activeDirText.Text = (string) configHandler["activeDir"];
                includesDirText.Text = (string) configHandler["includesDir"];
                ouputDirText.Text = (string) configHandler["ouputDir"];
                reportGenCheck.Checked = (bool) configHandler["reportGenCheck"];
                reportGenDirText.Text = (string) configHandler["reportGenDir"];
                debugLevelUpDown.Value = (decimal)(double)configHandler["debugLevel"];
                try //For version 1.0.0.1 when the default was 2.
                {
                    optiLevelUpDown.Value = (decimal)(double) configHandler["optiLevel"];
                }
                catch (ArgumentOutOfRangeException)
                {
                    optiLevelUpDown.Value = 1;
                }

                tabSizeUpDown.Value = (decimal)(double) configHandler["tabSize"];
                skipLinesUpDown.Value = (decimal)(double) configHandler["skipLines"];
                parenthesesCheck.Checked = (bool) configHandler["parentheses"];
                semiColonCheck.Checked = (bool) configHandler["semicolon"];
                customArgsText.Text = (string) configHandler["customArgs"];
            }
            catch (KeyNotFoundException)
            {
                ResetDefaultCompiler(this, null);
                FormClosingCompiler(this, null);
            }
        }

        private void ResetDefaultCompiler(object sender, EventArgs e)
        {
            activeDirText.Text = "";
            includesDirText.Text = "";
            ouputDirText.Text = "";
            reportGenCheck.Checked = false;
            reportGenDirText.Text = "";
            debugLevelUpDown.Value = 0.0M;
            optiLevelUpDown.Value = 1.0M;
            tabSizeUpDown.Value = 4.0M;
            skipLinesUpDown.Value = 0.0M;
            parenthesesCheck.Checked = true;
            semiColonCheck.Checked = true;
            customArgsText.Text = "";
        }

        [Localizable(false)]
        public string GetCompilerArgs()
        {
            LoadCompiler();

            StringBuilder allArgs = new StringBuilder();
            if (activeDirText.Text != "")
            {
                allArgs.Append(" " + "-D=" + "\"" + activeDirText.Text + "\"");
            }

            if (includesDirText.Text != "")
            {
                allArgs.Append(" " + "-i=" + "\"" + includesDirText.Text + "\"");
            }

            if (ouputDirText.Text != "")
            {
                allArgs.Append(" " + "-o=" + "\"" + ouputDirText.Text + "\"");
            }

            if (reportGenCheck.Checked)
            {
                allArgs.Append(" " + "-r=" + "\"" + reportGenDirText.Text + "\"");
            }

            allArgs.Append(" " + "-d=" + debugLevelUpDown.Text);
            allArgs.Append(" " + "-O=" + optiLevelUpDown.Text);
            allArgs.Append(" " + "-t=" + tabSizeUpDown.Text);
            allArgs.Append(" " + "-s=" + skipLinesUpDown.Text);
            if (parenthesesCheck.Checked)
            {
                allArgs.Append(" " + "-(+");
            }
            else
            {
                allArgs.Append(" " + "-(-");
            }

            if (semiColonCheck.Checked)
            {
                allArgs.Append(" " + "-;+");
            }
            else
            {
                allArgs.Append(" " + "-;-");
            }

            allArgs.Append(" " + customArgsText.Text);

            return allArgs.ToString().Trim();
        }

        #endregion

        #region Server.CFG

        [Localizable(false)]
        public void LoadServerCfg()
        {
            serverCfgGrid.Rows.Clear();
            var props = typeof(RuntimeInfo).GetProperties();
            foreach (var prop in props)
            {
                serverCfgGrid.Rows.Add(prop.Name, prop.GetValue(Program.MainForm.CurrentProject.SampCtlData.runtime));
            }
        }

        [Localizable(false)]
        private void ServerCfgFormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsGlobal)
                return;

            foreach (DataGridViewRow row in serverCfgGrid.Rows)
            {
                var prop = typeof(RuntimeInfo).GetProperties().First(x => x.Name == (string)row.Cells[0].Value);
                object value;
                if (prop.PropertyType == typeof(int))
                {
                    value = int.Parse(row.Cells[1].Value.ToString());
                }
                else if (prop.PropertyType == typeof(bool))
                {
                    value = bool.Parse(row.Cells[1].Value.ToString());
                }
                else if (prop.PropertyType == typeof(float))
                {
                    value = float.Parse(row.Cells[1].Value.ToString());
                }
                else
                {
                    value = row.Cells[1].Value.ToString();
                }
                prop.SetValue(Program.MainForm.CurrentProject.SampCtlData.runtime, value);
            }
            Program.MainForm.CurrentProject.SaveSampCtlData();
        }

        #endregion

        private void ResetLangBtn_Click(object sender, EventArgs e)
        {
            if (File.Exists(Program.MainForm.ApplicationFiles + "\\configs\\lang.cfg"))
            {
                File.Delete(Program.MainForm.ApplicationFiles + "\\configs\\lang.cfg");
                MessageBox.Show(
                    Convert.ToString(translations.SettingsForm_ResetLangBtn_Click_LocalizationSettingsDeleted));
                Application.Exit();
            }
        }

        #region HotKeyStuff

        [Localizable(false)]
        public void LoadHotkeys()
        {
            try
            {
                ConfigsHandler configHandler = new ConfigsHandler(_configDirPath + "/hotkeys.json");
                Keys key = default(Keys);
                Keys modif = default(Keys);
                var arr = configHandler["SaveHotkey"].ToString().Split('|').ToArray();
                Keys.TryParse(Convert.ToString(arr[0]), out key);
                Keys.TryParse(Convert.ToString(arr[1]), out modif);
                SaveHotkey.Hotkey = key;
                SaveHotkey.HotkeyModifiers = modif;

                arr = configHandler["SaveAllHotkey"].ToString().Split('|').ToArray();
                Keys.TryParse(Convert.ToString(arr[0]), out key);
                Keys.TryParse(Convert.ToString(arr[1]), out modif);
                SaveAllHotkey.Hotkey = key;
                SaveAllHotkey.HotkeyModifiers = modif;

                arr = configHandler["GotoHotkey"].ToString().Split('|').ToArray();
                Keys.TryParse(Convert.ToString(arr[0]), out key);
                Keys.TryParse(Convert.ToString(arr[1]), out modif);
                GotoHotkey.Hotkey = key;
                GotoHotkey.HotkeyModifiers = modif;

                arr = configHandler["SearchHotkey"].ToString().Split('|').ToArray();
                Keys.TryParse(Convert.ToString(arr[0]), out key);
                Keys.TryParse(Convert.ToString(arr[1]), out modif);
                SearchHotkey.Hotkey = key;
                SearchHotkey.HotkeyModifiers = modif;

                arr = configHandler["ReplaceHotkey"].ToString().Split('|').ToArray();
                Keys.TryParse(Convert.ToString(arr[0]), out key);
                Keys.TryParse(Convert.ToString(arr[1]), out modif);
                ReplaceHotkey.Hotkey = key;
                ReplaceHotkey.HotkeyModifiers = modif;

                arr = configHandler["GotoNextHotkey"].ToString().Split('|').ToArray();
                Keys.TryParse(Convert.ToString(arr[0]), out key);
                Keys.TryParse(Convert.ToString(arr[1]), out modif);
                GotoNextHotkey.Hotkey = key;
                GotoNextHotkey.HotkeyModifiers = modif;

                arr = configHandler["GotoBeforeHotkey"].ToString().Split('|').ToArray();
                Keys.TryParse(Convert.ToString(arr[0]), out key);
                Keys.TryParse(Convert.ToString(arr[1]), out modif);
                GotoBeforeHotkey.Hotkey = key;
                GotoBeforeHotkey.HotkeyModifiers = modif;

                arr = configHandler["BuildHotkey"].ToString().Split('|').ToArray();
                Keys.TryParse(Convert.ToString(arr[0]), out key);
                Keys.TryParse(Convert.ToString(arr[1]), out modif);
                BuildHotkey.Hotkey = key;
                BuildHotkey.HotkeyModifiers = modif;

                arr = configHandler["GotoDef"].ToString().Split('|').ToArray();
                Keys.TryParse(Convert.ToString(arr[0]), out key);
                Keys.TryParse(Convert.ToString(arr[1]), out modif);
                GotoDefHotkey.Hotkey = key;
                GotoDefHotkey.HotkeyModifiers = modif;
            }
            catch (Exception)
            {
                SaveHotkey.Hotkey = Keys.S;
                SaveHotkey.HotkeyModifiers = Keys.Control;
                SaveAllHotkey.Hotkey = Keys.S;
                SaveAllHotkey.HotkeyModifiers = Keys.Control | Keys.Shift;
                GotoHotkey.Hotkey = Keys.G;
                GotoHotkey.HotkeyModifiers = Keys.Control;
                SearchHotkey.Hotkey = Keys.F;
                SearchHotkey.HotkeyModifiers = Keys.Control;
                ReplaceHotkey.Hotkey = Keys.H;
                ReplaceHotkey.HotkeyModifiers = Keys.Control;
                GotoNextHotkey.Hotkey = Keys.F3;
                GotoNextHotkey.HotkeyModifiers = Keys.None;
                GotoBeforeHotkey.Hotkey = Keys.F3;
                GotoBeforeHotkey.HotkeyModifiers = Keys.Shift;
                BuildHotkey.Hotkey = Keys.F5;
                BuildHotkey.HotkeyModifiers = Keys.None;
                GotoDefHotkey.Hotkey = Keys.F12;
                GotoDefHotkey.HotkeyModifiers = Keys.None;
                Button2_Click(this, EventArgs.Empty);
            }
        }

        [Localizable(false)]
        private void Button2_Click(object sender, EventArgs e)
        {
            ConfigsHandler configHandler = new ConfigsHandler(_configDirPath + "/hotkeys.json")
            {
                ["SaveHotkey"] = SaveHotkey.Hotkey.ToString() + '|' + SaveHotkey.HotkeyModifiers,
                ["SaveAllHotkey"] = SaveAllHotkey.Hotkey.ToString() + '|' + SaveAllHotkey.HotkeyModifiers,
                ["GotoHotkey"] = GotoHotkey.Hotkey.ToString() + '|' + GotoHotkey.HotkeyModifiers,
                ["SearchHotkey"] = SearchHotkey.Hotkey.ToString() + '|' + SearchHotkey.HotkeyModifiers,
                ["ReplaceHotkey"] = ReplaceHotkey.Hotkey.ToString() + '|' + ReplaceHotkey.HotkeyModifiers,
                ["GotoNextHotkey"] = GotoNextHotkey.Hotkey.ToString() + '|' + GotoNextHotkey.HotkeyModifiers,
                ["GotoBeforeHotkey"] =
                    GotoBeforeHotkey.Hotkey.ToString() + '|' + GotoBeforeHotkey.HotkeyModifiers,
                ["BuildHotkey"] = BuildHotkey.Hotkey.ToString() + '|' + BuildHotkey.HotkeyModifiers,
                ["GotoDef"] = GotoDefHotkey.Hotkey.ToString() + '|' + GotoDefHotkey.HotkeyModifiers
            };
            configHandler.Save();
        }

        #endregion
    }


    #region Syntax Colorizing Stuff

    #region NoTypeConverterJsonConverter

    public class NoTypeConverterJsonConverter<T> : JsonConverter
    {
        static readonly IContractResolver resolver = new NoTypeConverterContractResolver();

        private class NoTypeConverterContractResolver : DefaultContractResolver
        {
            protected override JsonContract CreateContract(Type objectType)
            {
                if (typeof(T).IsAssignableFrom(objectType))
                {
                    var contract = CreateObjectContract(objectType);
                    contract.Converter = null;
                    // Also null out the converter to prevent infinite recursion.
                    return contract;
                }

                return base.CreateContract(objectType);
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        public override dynamic ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            return JsonSerializer.CreateDefault(new JsonSerializerSettings {ContractResolver = resolver})
                .Deserialize(reader, objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JsonSerializer.CreateDefault(new JsonSerializerSettings {ContractResolver = resolver})
                .Serialize(writer, value);
        }
    }

    #endregion

    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonConverter(typeof(NoTypeConverterJsonConverter<StyleItem>))]
    public class StyleItem
    {
        public StyleItem()
        {
            // VBConversions Note: Non-static class variable initialization is below.  Class variables cannot be initially assigned non-static values in C#.
            ForeColor = Color.Transparent;
            BackColor = Color.Transparent;

        }

        public Font Font { get; set; } = null;
        public Color ForeColor { get; set; } = Color.Transparent;
        public Color BackColor { get; set; } = Color.Transparent;
    }

    public class SyntaxInfo
    {
        [DisplayName("Default"), Category("Language Syntax Highlighting")]
        public StyleItem SDefault { get; set; } = new StyleItem();

        [DisplayName("Integers"), Category("Language Syntax Highlighting")]
        public StyleItem SInteger { get; set; } = new StyleItem();

        [DisplayName("Strings"), Category("Language Syntax Highlighting")]
        public StyleItem SString { get; set; } = new StyleItem();

        [DisplayName("Symbols"), Category("Language Syntax Highlighting")]
        public StyleItem SSymbols { get; set; } = new StyleItem();

        [DisplayName("SingleLine Comments"), Category("Language Syntax Highlighting")]
        public StyleItem SSlComments { get; set; } = new StyleItem();

        [DisplayName("MultiLine Comments"), Category("Language Syntax Highlighting")]
        public StyleItem SMlComments { get; set; } = new StyleItem();

        [DisplayName("PawnDoc"), Category("Language Syntax Highlighting")]
        public StyleItem SPawnDoc { get; set; } = new StyleItem();

        [DisplayName("Pawn PreProcessor"), Category("Language Syntax Highlighting")]
        public StyleItem SPawnPre { get; set; } = new StyleItem();

        [DisplayName("Pawn KeyWords"), Category("Language Syntax Highlighting")]
        public StyleItem SPawnKeys { get; set; } = new StyleItem();

        [DisplayName("Functions"), Category("WordSets Syntax Highlighting")]
        public StyleItem SFunctions { get; set; } = new StyleItem();

        [DisplayName("Publics"), Category("WordSets Syntax Highlighting")]
        public StyleItem SPublics { get; set; } = new StyleItem();

        [DisplayName("Stocks"), Category("WordSets Syntax Highlighting")]
        public StyleItem SStocks { get; set; } = new StyleItem();

        [DisplayName("Natives"), Category("WordSets Syntax Highlighting")]
        public StyleItem SNatives { get; set; } = new StyleItem();

        [DisplayName("Defines"), Category("WordSets Syntax Highlighting")]
        public StyleItem SDefines { get; set; } = new StyleItem();

        [DisplayName("Macros"), Category("WordSets Syntax Highlighting")]
        public StyleItem SMacros { get; set; } = new StyleItem();

        [DisplayName("Enums"), Category("WordSets Syntax Highlighting")]
        public StyleItem SEnums { get; set; } = new StyleItem();

        [DisplayName("Global Variables"), Category("WordSets Syntax Highlighting")]
        public StyleItem SGlobalVars { get; set; } = new StyleItem();
    }

    #endregion
}
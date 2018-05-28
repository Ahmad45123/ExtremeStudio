using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ExtremeCore.Classes
{
    public class ConfigsHandler
    {
        private Dictionary<string, object> _values = new Dictionary<string, object>();
        private readonly bool _autoSave;
        private readonly string _dataFile;

        public ConfigsHandler(string filePath, string defaultData = "", bool isAutoSave = false)
        {
            _autoSave = isAutoSave;
            _dataFile = filePath;

            if (File.Exists(_dataFile) == false & defaultData != "")
                File.WriteAllText(_dataFile, defaultData);

            if (File.Exists(_dataFile))
                Load();
        }

        public object this[string key]
        {
            get => _values[key];
            set
            {
                _values[key] = value;

                if (_autoSave)
                    Save();
            }
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(_values, Formatting.Indented);
            File.WriteAllText(_dataFile, json);
        }

        public void Delete(string key)
        {
            _values.Remove(key);

            if (_autoSave)
                Save();
        }

        private void Load()
        {
            string json = File.ReadAllText(_dataFile);
            _values = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
        }
    }
}

using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ExtremeStudio.Core.Modules
{
	public class ConfigsHandler
	{
		private Dictionary<string, object> _values = new Dictionary<string, object>();
		private bool _autoSave;
		private string _dataFile;
		
		public ConfigsHandler(string filePath, string defaultData = "", bool isAutoSave = false)
		{
			_autoSave = isAutoSave;
			_dataFile = filePath;
			
			if (File.Exists(_dataFile) == false && defaultData != "")
			{
				File.WriteAllText(_dataFile, defaultData);
			}
			
			if (File.Exists(_dataFile) == true)
			{
				Load();
			}
		}
		
        public dynamic this[string key]
		{
			get
			{
				return _values[key];
			}
			set
			{
				_values[key] = value;
				
				if (_autoSave)
				{
					Save();
				}
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
			{
				Save();
			}
		}
		
		private void Load()
		{
			string json = File.ReadAllText(_dataFile);
			_values = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
		}
	}
}

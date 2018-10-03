using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows;
using System.Windows.Forms;
using System.IO;

namespace Clips
{
    class Settings
    {
        private string appDir = Path.GetDirectoryName(Application.ExecutablePath);
        private string customPath;
        
        public Settings()
        {
            customPath = Path.Combine(appDir, "settings.cfg");
        }

        public string CfgFile
        {
            set 
            {
                if (value != null)
                {
                    try
                    {
                        string dir = Path.GetDirectoryName(value);
                        string file = Path.GetFileName(value);

                        if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                        customPath = Path.Combine(dir, file);
                    }

                    catch { }
                }
            }

            get
            {
                return customPath;
            }

        }

        public string LoadSetting(string key)
        {
            return LoadSetting(key, "string", "");
        }

        public dynamic LoadSetting(string key, string type, string def)
        {
            string result;

            try
            {
                ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                configFileMap.ExeConfigFilename = customPath;

                var configFile = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                try { result = settings[key].Value ?? null; }
                catch { result = null; }
            }

            catch { result = null; }

            if (type == "int")
            {
                if (result == null) return Convert.ToInt32(def);
                else return Convert.ToInt32(result);
            }

            if (type == "dec")
            {
                if (result == null) return Convert.ToDecimal(def);
                else return Convert.ToDecimal(result);
            }

            if (type == "timespan")
            {
                if (result == null) return TimeSpan.Parse(def);
                else return TimeSpan.Parse(result);
            }

            if (type == "float")
            {
                if (result == null) return float.Parse(def);
                else return float.Parse(result);
            }
                    
            if (type == "bool")
            {
                if (result == null) return Convert.ToBoolean(def);
                else return Convert.ToBoolean(result);
            }

            if (type == "string")
            {
                if (result == null) return def;
                else return result;
            }

            else return result;
        }

        public void SaveSetting(string key, string value)
        {
            try
            {
                ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                configFileMap.ExeConfigFilename = customPath;

                var configFile = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }

            catch //(Exception e) //(ConfigurationErrorsException)
            {
                //MessageBox.Show(e.ToString());
            }
        }

        public void EraseSetting(string key)
        {
            try
            {
                ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                configFileMap.ExeConfigFilename = customPath;

                var configFile = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                if (settings[key] != null)
                {
                    settings.Remove(key);
                }

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }

            catch // (Exception e) //(ConfigurationErrorsException)
            {
                //MessageBox.Show(e.ToString());
            }
        }

        private void showError()
        {
            MessageBox.Show("Cannot save config, write access denied.", "Error saving configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    
    }
}

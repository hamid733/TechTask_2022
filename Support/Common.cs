using System;
using System.Collections.Generic;
using System.Configuration;


namespace TechTask_2022.Support
    {
    public class Common
    {
        public Common() { }
        public static string readConfig(string key)
        {
            try
            {
                string cfg_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App.config");
                ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                configFileMap.ExeConfigFilename = cfg_path;
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
                AppSettingsSection section = (AppSettingsSection)config.GetSection("appSettings");
                return section.Settings[key].Value;
            }
            catch (Exception)
            {

                throw;
            }

            
        }

        public List<string> get_table_values(string column, Table table)
        {
            List<string> val_list = new List<string>();
            foreach (var row in table.Rows)
            {
                val_list.Add(row[column]);
            }
            return val_list;
        }

       
        
    }
}

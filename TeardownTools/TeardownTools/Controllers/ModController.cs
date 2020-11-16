using Gameloop.Vdf;
using Gameloop.Vdf.Linq;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeardownTools.Models;

namespace TeardownTools.Controllers
{
    public static class ModController
    {
        // CONSTANTS
        private const string TDTOOLSTEMPLATE = "TDTools = {\n}";


        // FIELDS
        private static string teardownPath = GetTeardownPath();
        private static string tDToolsPath = teardownPath + "tdtools.lua";
        private static bool tDToolsExists = File.Exists(tDToolsPath);
        private static FileStream tDToolsStream = tDToolsExists ? File.Open(tDToolsPath, FileMode.Open) : null;


        // PROPERTIES
        public static ModModel BaseMod { get; set; }
        public static bool TDToolsExists
        {
            get { return tDToolsExists; }
        }


        // PUBLIC METHODS
        public static bool Update(List<ModModel> mods)
        {
            foreach (ModModel mod in mods)
            {
                if (mod.Version > GetVersion(mod))
                {
                    Uninstall(mod);
                    Install(mod);
                }
            }
            return true;
        }

        public static bool Install(ModModel mod)
        {
            if (!tDToolsExists)
            {
                CreateTDTools();
            }

            string table = "m" + mod.Id + " = {\n" +
                "\t-- version: " + GetVersion(mod) + "\n";

            int count;
            foreach (KeyValuePair<string, List<ChangeModel>> kv in mod.Changes)
            {
                count = 1;
                foreach (ChangeModel change in kv.Value)
                {
                    table += "\t" + PathToFunctionName(kv.Key, count) + " = function()\n";

                    foreach (string code in change.Code)
                    {
                        table += "\t\t" + code + "\n";
                    }

                    table += "\tend,\n";

                    count++;
                }
            }

            return true;
        }

        public static bool Uninstall(ModModel mod)
        {
            return true;
        }

        public static bool UninstallAll()
        {
            if (tDToolsExists)
            {
                DeleteTDTools();
            }
            return true;
        }

        public static bool CheckInstalled(ModModel mod)
        {
            return true;
        }


        // PRIVATE METHODS
        private static string PathToFunctionName(string path, int count)
        {
            return path.Substring(0, path.Length - 4).Replace("\\", "_") + "_" + count;
        }

        private static float GetVersion(ModModel mod)
        {
            return 1.0f;
        }

        private static void CreateTDTools()
        {
            tDToolsStream = File.Open(tDToolsPath, FileMode.Create);
            tDToolsExists = true;
        }

        private static void DeleteTDTools()
        {
            tDToolsStream.Close();
            tDToolsStream = null;
            File.Delete(tDToolsPath);
            tDToolsExists = false;
        }

        private static string GetTeardownPath()
        {
            string steamPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Valve\Steam", "InstallPath", null);

            List<string> pathsToCheck = new List<string>() { steamPath };

            dynamic libraryFolders = VdfConvert.Deserialize(File.ReadAllText(steamPath + @"\steamapps\libraryfolders.vdf"));

            int i = 1;
            VValue obj;
            while (true)
            {
                obj = libraryFolders.Value[i.ToString()];
                if (obj == null)
                    break;

                pathsToCheck.Add(obj.ToString());
                i++;
            }

            foreach (string path in pathsToCheck)
            {
                if (File.Exists(path + @"\steamapps\appmanifest_1167630.acf"))
                {
                    return path + @"\steamapps\common\Teardown\data\";
                }
            }

            return string.Empty;
        }
    }
}

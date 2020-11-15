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
        // FIELDS
        private static string teardownPath = GetTeardownPath();
        private static string tDToolsPath = teardownPath + "tdtools.lua";
        private static bool tDToolsExists = File.Exists(tDToolsPath);
        private static FileStream tDToolsStream = tDToolsExists ? File.Open(tDToolsPath, FileMode.Open) : null;


        // PROPERTIES
        public static ModModel BaseMod { get; set; }


        // PUBLIC METHODS
        public static bool Install(ModModel mod)
        {
            if (!tDToolsExists)
            {
                CreateTDTools();
            }
            return true;
        }

        public static bool Uninstall(ModModel mod)
        {
            return true;
        }

        public static bool UninstallAll(ModModel mod)
        {
            if (tDToolsExists)
            {
                DeleteTDTools();
            }
            return true;
        }

        public static bool Update(ModModel mod)
        {
            if (tDToolsExists)
            {
                if (CheckModInstalled(mod))
                {
                    if (mod.Version > GetModVersion(mod))
                    {
                        Uninstall(mod);
                        Install(mod);
                    }
                }
            }
            return true;
        }


        // PRIVATE METHODS
        private static bool CheckModInstalled(ModModel mod)
        {
            return true;
        }

        private static float GetModVersion(ModModel mod)
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

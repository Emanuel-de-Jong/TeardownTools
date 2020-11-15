using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeardownTools.Models
{
    public class ModModel
    {
        // FIELDS
        private Dictionary<string, List<ChangeModel>> changes;


        // PROPERTIES
        public string Name { get; set; }
        public double Version { get; set; }
        public Dictionary<string, List<ChangeModel>> Changes
        {
            get { return changes; }
            set { changes = value; }
        }


        // CONSTRUCTORS
        public ModModel(string _name, double _version, Dictionary<string, List<ChangeModel>> _changes)
        {
            Name = _name;
            Version = _version;
            changes = _changes;
        }
        public ModModel(string _name, double _version)
        {
            Name = _name;
            Version = _version;
            changes = new Dictionary<string, List<ChangeModel>>();
        }
        public ModModel()
        {
            Name = string.Empty;
            Version = 0;
            changes = new Dictionary<string, List<ChangeModel>>();
        }


        // METHODS
        public void AddChange(ChangeModel change, string path)
        {
            if (!changes.ContainsKey(path))
            {
                changes[path] = new List<ChangeModel>();
            }

            changes[path].Add(change);
        }
    }
}

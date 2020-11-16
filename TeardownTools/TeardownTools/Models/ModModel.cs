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
        public int Id { get; set; }
        public double Version { get; set; }
        public Dictionary<string, List<ChangeModel>> Changes
        {
            get { return changes; }
            set { changes = value; }
        }


        // CONSTRUCTORS
        public ModModel(int _id, double _version, Dictionary<string, List<ChangeModel>> _changes)
        {
            Id = _id;
            Version = _version;
            changes = _changes;
        }
        public ModModel(int _id, double _version)
        {
            Id = _id;
            Version = _version;
            changes = new Dictionary<string, List<ChangeModel>>();
        }
        public ModModel()
        {
            Id = 0;
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

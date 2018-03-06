using System;
using System.Collections.Generic;
using System.Text;

namespace Schaffner_Server.Common.Models
{
    public class Stop : IStop
    {
        private int _id;
        private string _name;

        public int Id
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
        }

        public Stop(int id, string name)
        {
            this._id = id;
            this._name = name;
        }
    }
}

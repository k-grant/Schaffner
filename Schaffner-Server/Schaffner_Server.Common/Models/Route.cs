using System;
using System.Collections.Generic;
using System.Text;

namespace Schaffner_Server.Common.Models
{
    public class Route : IRoute
    {
        private int _id;
        private string _name;

        public Route(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public int Id
        {
            get { return _id; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Schaffner_Server.Common.Models
{
    public class Route : IRoute
    {
        private int _id;
        private string _name;
        private int _direction;

        public Route(int id, string name, int direction = 0)
        {
            _id = id;
            _name = name;
            _direction = direction;
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

        public int Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }
    }
}

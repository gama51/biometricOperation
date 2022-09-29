using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camara
{
    public class Resolutions
    {
        int _Id;
        string _Name;
        public Resolutions(int id,string name)
        {

            _Id = id;
            _Name = name;
        }

        public int Id
        {
            get
            {
                return _Id;
            }

            set
            {
                _Id = value;
            }
        }

        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                _Name = value;
            }
        }
    }
}

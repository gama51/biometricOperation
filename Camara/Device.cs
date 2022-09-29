using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camara
{
    

    public class Device
    {
        int _Id;
        string _Name;
        string _MonikerString;

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

        public string MonikerString
        {
            get
            {
                return _MonikerString;
            }

            set
            {
                _MonikerString = value;
            }
        }

        public Device(int id,string name)
        {
            _Id = id;
            _Name = name;

        }

    }
}

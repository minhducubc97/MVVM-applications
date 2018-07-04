using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewSample.Model
{
    public class EquationParameters
    {
        public int _id { get; set; }
        public double _m1 { get; set; }
        public double _m2 { get; set; }
        public double _r { get; set; }
        public double _result { get; set; }

        public EquationParameters(int id)
        {
            this._id = id;
        }
    }
}

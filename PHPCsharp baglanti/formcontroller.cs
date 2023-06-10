using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PHPCsharp_baglanti
{
    internal class formcontroller
    {

        public Form StartForm(bool isOk)
        {
            if(isOk)
            {
                return new Form2();
            }
            return new Form1();
        }

    }
}

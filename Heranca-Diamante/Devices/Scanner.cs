using System;
using System.Collections.Generic;
using System.Text;

namespace Heranca_Diamante.Devices
{
    class Scanner : Device, IScanner  //não herda, implementa as interfaces (cumpre o contrato)
    {

        public override void ProcessDoc(string document)
        {
            Console.WriteLine("Scanner processing: " + document);
        }

        public string Scan()
        {
            return "Scanner scan result";
        }
    }
}

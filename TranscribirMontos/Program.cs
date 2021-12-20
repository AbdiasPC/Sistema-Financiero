using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranscribirMontos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Introduzca un monto en digitos: ");
            string monto = Console.ReadLine();

            Transcribir.LeerMonto(monto);

            Console.Write("Probando VS Code Web")

            
        }
    }
}

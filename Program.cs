using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StringFormat;

namespace tablas {
    class Program {
        static void Main(string[] args) {
            // Definir las columnas
            string[] col = { "Nombre", "Edad", "Ciudad" };

            // Imprimir filas
            string[] fila1 = { "Juan", "25", "Guatemala" };
            string[] fila2 = { "María", "30", "Quetzaltenango" };

            Console.WriteLine(Txt.title("Cajero automatico", 5));

            Txt.setHeder(col);
            Txt.SetRow(fila1);
            Txt.SetRow(fila2);

            Txt.PrintTable();

            Console.WriteLine("|{0}|", Txt.centeredString("Hello", 10));
            Console.WriteLine(Txt.RepeatChar('-', 12));
            Console.WriteLine("|{0}|", Txt.leftString("World!", 10));
            Console.WriteLine(Txt.RepeatChar('-', 12));
            Console.WriteLine("|{0}|", Txt.rightString("Hola", 10));

        }

        
    }
}

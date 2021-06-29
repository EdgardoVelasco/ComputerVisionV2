using System;
using ComputerVC.Computer;

namespace ComputerVC
{
    class Program
    {
         static void Main(string[] args)
        {
            Menu();
            var opc = int.Parse(Console.ReadLine());
            var url = "";
            while (opc!=6) {
                switch (opc) {
                    case 1:
                        Console.WriteLine("-.-.-.-.Describe la imagen -.-.-.");
                        Console.WriteLine("Escribe url de imagen: ");
                        url=Console.ReadLine();
                        ComputerServices.DescribeImagen(url).Wait();
                        break;
                    case 2:
                        Console.WriteLine("-.-.-.-.-.Rostros-.-.-.-.-.-.");
                        Console.WriteLine("Escribe url de imagen: ");
                        url = Console.ReadLine();
                        ComputerServices.Rostros(url).Wait();
                        break;
                    case 3:
                        Console.WriteLine("-.-.-.-.-.Colores-.-.-.-.-.-.");
                        Console.WriteLine("Escribe url de imagen: ");
                        url = Console.ReadLine();
                        ComputerServices.Colores(url).Wait();
                        break;
                    case 4:
                        Console.WriteLine("-.-.-.-.-.Adulto-.-.-.-.-.-.");
                        Console.WriteLine("Escribe url de imagen: ");
                        url = Console.ReadLine();
                        ComputerServices.Adulto(url).Wait();
                        break;
                    case 5:
                        Console.WriteLine("-.-.-.-.-.Texto en imagen -.-.-.-.-.-.");
                        Console.WriteLine("Escribe url de imagen: ");
                        url = Console.ReadLine();
                        ComputerServices.TextoImagen(url).Wait();
                        break;
                    default:
                        Console.WriteLine("opción inválida intenta de nuevo");
                        break;

                }
                Menu();
                opc = int.Parse(Console.ReadLine());
            }

        }

        public static void Menu() {
            Console.WriteLine("\t-*-*-*-*-*-*-*Menu-*-*-*-*-*-*-*-*");
            Console.WriteLine("\t-*-*-*1.- Descripción         -*-*");
            Console.WriteLine("\t-*-*-*2.- Rostros             -*-*");
            Console.WriteLine("\t-*-*-*3.- Colores             -*-*");
            Console.WriteLine("\t-*-*-*4.- Adulto              -*-*");
            Console.WriteLine("\t-*-*-*5.- Texto en imagen     -*-*");
            Console.WriteLine("\t-*-*-*6.- Salir               -*-*");
            Console.WriteLine("\t-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
            Console.WriteLine("\t-*-*-*Selecciona opción:      -*-*");

        }
    }
}

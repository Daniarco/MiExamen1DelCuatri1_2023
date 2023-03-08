using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DanielExamen1Peaje
{
    internal class ClsMenu
    {


        public static int[] vehiculosfactura = new int[15];
        public static String[] vehiculosplaca = new String[15];
        public static String[] vehiculosfecha = new String[15];
        public static String[] vehiculoshora = new String[15];
        public static String[] vehiculostipo = new String[15];
        public static double[] vehiculosapagar = new double[15];
        public static double[] vehiculospago = new double[15];
        public static double[] vehiculosvuelto = new double[15];
        public static int[] vehiculoscaseta = new int[15];

        public static Boolean unoodos = false;
        public static int posicionglobal = 0;


        public static void gotomenu()
        {
            ClsMenu.menu();
        }


        private static void menu() 
        {
            char opcionmenu = '0';
            do {
                Console.WriteLine("Sistema de Peajes");
                Console.WriteLine("");
                Console.WriteLine("1. Inicializar Vectores");
                Console.WriteLine("2. Ingresar Pase Vehicular");
                Console.WriteLine("3. Consulta de Vehículos por Número de placa");
                Console.WriteLine("4. Modificar Datos de Vehículos por Número de Placa");
                Console.WriteLine("5. Reporte Todos los Datos de los Vectores");
                Console.WriteLine("6. Salir.");
                opcionmenu = char.Parse(Console.ReadLine());

                switch (opcionmenu)
                {
                        case '1':
                        Console.Clear();
                        for (int k = 0; k < vehiculosfactura.Length; k++) {
                            vehiculosfactura[k] = 0;
                            vehiculosplaca[k] = "";
                            vehiculosfecha[k] = "";
                            vehiculoshora[k] = "";
                            vehiculostipo[k] = "";
                            vehiculosapagar[k] = 0;
                            vehiculospago[k] = 0;
                            vehiculosvuelto[k] = 0;
                            vehiculoscaseta[k] = 0;
                        }
                        posicionglobal = 0;
                        Console.WriteLine("Valores de vehiculos han sido reseteados");
                        break;
                        case '2':
                        int elbite = 0;
                        do
                        {
                            ClsTransacciones.gotoingresar();
                            Console.WriteLine("Desea Continuar ingresando? (0 menor = si / 1 o mayor = no");
                            elbite = int.Parse(Console.ReadLine());
                            Console.Clear();
                        } while (elbite <= 0);
                        break;
                        case '3':
                        ClsTransacciones.gotoconsultar();
                        break;
                        case '4':
                        unoodos = true;
                        ClsTransacciones.gotoconsultar();
                        break;
                        case '5':
                        ClsTransacciones.gotomostrartodo();
                        break;
                    default:
                        break;
                }

            } while (opcionmenu != '6');
            

        }


    }
}

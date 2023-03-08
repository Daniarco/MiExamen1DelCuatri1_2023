using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanielExamen1Peaje
{
    internal class ClsTransacciones
    {


        public static void gotoingresar()
        {
            ClsTransacciones.ingresar();
        }

        public static void gotoconsultar()
        {
            ClsTransacciones.consultar();
        }

        public static void gotomostrartodo()
        {
            muestratodo();
        }


        private static void ingresar() {

            int p = ClsMenu.posicionglobal;
            char opciontipo = '0';
            char opcioncaseta = '0';
            Boolean talvez = false;
            Boolean kindof = false;
            float montopagar = 0;

            Console.Clear();
            ClsMenu.vehiculosfactura[p] = (p + 1);
            Console.WriteLine("Factura de transaccion:" + ClsMenu.vehiculosfactura[p]);
            Console.WriteLine("Ingrese el numero de placa del vehiculo actual");
                ClsMenu.vehiculosplaca[p] = Console.ReadLine();
            Console.WriteLine("Ingrese la fecha actual ej: d/m/a");
            ClsMenu.vehiculosfecha[p] = Console.ReadLine();
            Console.WriteLine("Ingrese la hora actual ej: hh:mm");
            ClsMenu.vehiculoshora[p] = Console.ReadLine();
            do
            {
                Console.WriteLine("Ingrese el tipo de vehiculo");
                Console.WriteLine("1=moto 2=liviano 3=pesado 4=autobús");
                opciontipo = char.Parse(Console.ReadLine());

                switch (opciontipo)
                {
                    case '1':
                        ClsMenu.vehiculostipo[p] = "moto";
                        talvez = true;
                        montopagar = 500;
                        break;
                    case '2':
                        ClsMenu.vehiculostipo[p] = "liviano";
                        talvez = true;
                        montopagar = 700;
                        break;
                    case '3':
                        ClsMenu.vehiculostipo[p] = "pesado";
                        talvez = true;
                        montopagar = 2700;
                        break;
                    case '4':
                        ClsMenu.vehiculostipo[p] = "autobús";
                        talvez = true;
                        montopagar = 3700;
                        break;
                    default: Console.WriteLine("Opcion no valida");
                        break;

                }

            } while (talvez == false);

            do
            {
                Console.WriteLine("Ingrese el numero de caseta");
                opcioncaseta = char.Parse(Console.ReadLine());

                switch (opcioncaseta)
                {

                    case '1':
                        ClsMenu.vehiculoscaseta[p] = 1;
                        kindof = true;
                        break;
                    case '2':
                        ClsMenu.vehiculoscaseta[p] = 2;
                        kindof = true;
                        break;
                    case '3':
                        ClsMenu.vehiculoscaseta[p] = 3;
                        kindof = true;
                        break;
                    default: Console.WriteLine("Opcion no valida");
                        break;

                }

            } while (kindof == false);

            ClsMenu.vehiculosapagar[p] = montopagar;
            Console.WriteLine("Monto a pagar: " + montopagar);

            Boolean quetal = false;
            do { 
            Console.WriteLine("Ingrese el monto con el que se pagará");
            double loquepaga = double.Parse(Console.ReadLine());
                if (loquepaga >= montopagar) { ClsMenu.vehiculospago[p] = loquepaga; quetal = true; } else { Console.WriteLine("Insuficiente"); }
        }while(quetal == false);

            double vuelto = (ClsMenu.vehiculospago[p] - ClsMenu.vehiculosapagar[p]);
            Console.WriteLine("Vuelto: " + vuelto);
            ClsMenu.vehiculosvuelto[p] = vuelto;


            Console.WriteLine("Informacion ingresada.");
            ClsMenu.posicionglobal += 1;
        
        }

        private static void consultar()
        {
            int placaconsulta = 0;
            Console.WriteLine("Ingrese el numero de factura");
            placaconsulta = int.Parse(Console.ReadLine());
            placaconsulta -= 1;
            if (existefactura(placaconsulta) > 0)
            {
                Console.Clear();
                Console.WriteLine("Se ha encontrado el vehiculo");
                Console.WriteLine("Numero factura: " + ClsMenu.vehiculosfactura[placaconsulta]);
                Console.WriteLine("Monto por pagar: " + ClsMenu.vehiculosapagar[placaconsulta]);
                Console.WriteLine("Pago realizado: " + ClsMenu.vehiculospago[placaconsulta]);
                Console.WriteLine("Vuelto del pago: " + ClsMenu.vehiculosvuelto[placaconsulta]);
                Console.WriteLine("1. Placa: " + ClsMenu.vehiculosplaca[placaconsulta]);
                Console.WriteLine("2. Fecha: " + ClsMenu.vehiculosfecha[placaconsulta]);
                Console.WriteLine("3. Hora: " + ClsMenu.vehiculoshora[placaconsulta]);
                Console.WriteLine("4. Tipo de vehiculo: " + ClsMenu.vehiculostipo[placaconsulta]);
                Console.WriteLine("5. Caseta: " + ClsMenu.vehiculoscaseta[placaconsulta]);


                if (ClsMenu.unoodos == true) { cambiar(placaconsulta); }
            }
            else { Console.WriteLine("Vehiculo no encontrado"); }
               
           
        }

        public static byte existefactura(int comprueba)
        {
            byte cas = 0;
            for(int h = 0; h < ClsMenu.vehiculosfactura.Length; h++)
            {
                if (comprueba == ClsMenu.vehiculosfactura[h]) { cas += 1; }
            }
            return cas;
        }

        private static void cambiar( int lafacturita)
        {
            Console.WriteLine("6. salir");
            char opcioncambio = '0';
            do
            {
                Console.WriteLine("Cual desea modificar?");
                opcioncambio = char.Parse(Console.ReadLine());
                switch (opcioncambio)
                {
                    case '1':
                        Console.WriteLine("Escriba el nuevo contenido:");
                        ClsMenu.vehiculosplaca[lafacturita] = Console.ReadLine();
                        break;
                    case '2':
                        Console.WriteLine("Escriba el nuevo contenido:");
                        ClsMenu.vehiculosfecha[lafacturita] = Console.ReadLine();
                        break;
                    case '3':
                        Console.WriteLine("Escriba el nuevo contenido:");
                        ClsMenu.vehiculoshora[lafacturita] = Console.ReadLine();
                        break;
                    case '4':
                        Console.WriteLine("Escriba el nuevo contenido:");
                        ClsMenu.vehiculostipo[lafacturita] = Console.ReadLine();
                        break;
                    case '5':
                        Console.WriteLine("Escriba el nuevo numero:");
                        int lacaseta = int.Parse(Console.ReadLine());
                        if (lacaseta > 0)
                        {
                            if (lacaseta < 4) { ClsMenu.vehiculoscaseta[lafacturita] = lacaseta; }
                            else
                            {
                                Console.WriteLine(
                            "No es posible hacer esto");
                            }
                        }
                        else
                        {
                            Console.WriteLine(
                            "No se puede realizar este cambio");
                        }

                        break;
                    case '6': Console.Clear(); Console.WriteLine("Saliendo"); break;
                    default:Console.WriteLine("Opcion no valida");
                        break;
                }
            } while (opcioncambio != '6');
        }

        private static void muestratodo()
        {
            Console.Clear();
            for (int y = 0; y < ClsMenu.vehiculosfactura.Length; y++)
            {
                Console.WriteLine("");
                Console.WriteLine("Numero factura: " + ClsMenu.vehiculosfactura[y]);
                Console.WriteLine("");
                Console.WriteLine("Monto por pagar: " + ClsMenu.vehiculosapagar[y]);
                Console.WriteLine("Pago realizado: " + ClsMenu.vehiculospago[y]);
                Console.WriteLine("Vuelto del pago: " + ClsMenu.vehiculosvuelto[y]);
                Console.WriteLine("Placa: " + ClsMenu.vehiculosplaca[y]);
                Console.WriteLine("Fecha: " + ClsMenu.vehiculosfecha[y]);
                Console.WriteLine("Hora: " + ClsMenu.vehiculoshora[y]);
                Console.WriteLine("Tipo de vehiculo: " + ClsMenu.vehiculostipo[y]);
                Console.WriteLine("Caseta: " + ClsMenu.vehiculoscaseta[y]);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorio
{
    internal class Program
    {
        static string[] codigos = { "OC-101", "OC-102", "OC-103", "OC-104", "OC-105", "OC-106" };
        static string[] proveedores = { "TechCorp1", "LogiExpress", "InsumosGlobal", "TechCorp2", "AlfaSuministro", "ServiRedes" };
        static double[] preciosUni = { 150, 450, 80, 1200, 25, 600 };
        static double[] cantidades = { 10, 2, 50, 1, 100, 3 };

        static double[] montos = new double[codigos.Length];
        static string linea1 = new string('-', 75);
        static string linea2 = new string('=', 75);
        static void MostrarDatos(double sumaMontos, int contador)
        {
            Console.Clear();
            Console.WriteLine(linea2);
            Console.WriteLine("CONTROL DE ORDENES DE COMPRA");
            Console.WriteLine(linea2);
            Console.WriteLine("Reporte ordenado:");
            Console.WriteLine(linea1);
            Console.WriteLine("Nro\t\t|Código\t\t|Proveedor\t\t|Monto");
            Console.WriteLine(linea1);
            for (int i = 0; i < codigos.Length; i++)
            {
                Console.WriteLine($"{i + 1}\t\t|{codigos[i]}\t\t|{proveedores[i]}\t\t|{montos[i]}");
            }
            Console.WriteLine(linea1);
            Console.WriteLine("Resumen de métricas:");
            Console.WriteLine($"* Monto total de las compras: ${sumaMontos:f2}");
            Console.WriteLine($"* Compras críticas [> $1,000]: {contador} ordenes");
            Console.ReadKey();
        }
        
        static void Validacion()
        {
            for (int i = 0; i < codigos.Length; i++)
            {
                if (preciosUni[i] <= 0 || cantidades[i] <= 0)
                {
                    Console.WriteLine($"Error: El precio o la cantidad del producto {codigos[i]} es inválido.");
                    return;
                }
            }
            Console.WriteLine("//Datos cargados de exitosamente!");
            Console.Write("Presione \"Enter\" para iniciar...");
            Console.ReadKey();
            ProcesoDeDatos();
        }
        static void ProcesoDeDatos()
        {
            double sumaMontos = 0;
            int contador = 0;
            for (int i = 0; i < codigos.Length; i++)
            {
                montos[i] = preciosUni[i] * cantidades[i];
                sumaMontos += montos[i];
                if (montos[i] > 1000)
                {
                    contador++;
                }
            }
            Burbuja(sumaMontos, contador);
        }
        static void Burbuja(double sumaMontos, int contador)
        {
            for (int i = 0; i < montos.Length - 1; i++)
            {
                for (int j = 0; j < montos.Length - i - 1; j++)
                {
                    if (montos[j] < montos[j + 1])
                    {
                        double tempMonto = montos[j];
                        montos[j] = montos[j + 1];
                        montos[j + 1] = tempMonto;
                        string tempCodigo = codigos[j];
                        codigos[j] = codigos[j + 1];
                        codigos[j + 1] = tempCodigo;
                        string tempProveedor = proveedores[j];
                        proveedores[j] = proveedores[j + 1];
                        proveedores[j + 1] = tempProveedor;
                        double tempPrecioUni = preciosUni[j];
                        preciosUni[j] = preciosUni[j + 1];
                        preciosUni[j + 1] = tempPrecioUni;
                        double tempCantidad = cantidades[j];
                        cantidades[j] = cantidades[j + 1];
                        cantidades[j + 1] = tempCantidad;
                    }
                }
            }
            MostrarDatos(sumaMontos, contador);
        }
        static void Main(string[] args)
        {
            Validacion();
        }
    }
}

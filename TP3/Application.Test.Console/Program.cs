using System;
using Application.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Repositorios;
using Application.Models.Logs;

namespace Application.Test.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            MateriaPrima materiaPrimaDelDia = new MateriaPrima(255, 588, 1.25, "mp 1");
            try
            {
                MateriaPrima.GuardarMateriaPrima(materiaPrimaDelDia);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"No se puede agregar el lacteo: {ex.Message}", "error");
                Logger.LogException(ex.Message);
            }
            Lacteo lacteo = new Leche();
            lacteo.MateriaPrimaAutorizada = true;
            lacteo.Enfriado = true;
            lacteo.Estandarizado = true;
            lacteo.Pasteurizado = true;

            RepositorioAditivos aditivos1 = new RepositorioAditivos();
            RepositorioLacteos lacteos = new RepositorioLacteos();
            aditivos1.Create(new AditivoProducto(0.25, "Mm", "Espesante"));
            aditivos1.Create(new AditivoProducto(0.3, "ttt", "Espesante"));
            aditivos1.Create(new AditivoProducto(1.25, "Mm 55", "Potenciador del sabor"));
            lacteo.Aditivos = aditivos1.GetAll();

            lacteo.ProcesarProducto(materiaPrimaDelDia, 12, "alta temperatura ");
            if(lacteo.MateriaPrimaAutorizada && lacteo.Enfriado  && lacteo.Estandarizado && lacteo.Pasteurizado)
            {
                System.Console.WriteLine("Procesamiento correcto del producto");
            }
            lacteos.Create(lacteo);
            if(lacteos.GetAll().Count ==1)
            {
                System.Console.WriteLine("Se agrego correctamente a la coleccion el lacteo");
            }

            Lacteo lacteo1 = new Yogurth();
            lacteo1.MateriaPrimaAutorizada = true;
            lacteo1.Enfriado = true;
            lacteo1.Estandarizado = true;
            lacteo1.Pasteurizado = true;

            RepositorioAditivos aditivos2 = new RepositorioAditivos();
            aditivos2.Create(new AditivoProducto(0.45, "tyyy", "Espesante"));
            aditivos2.Create(new AditivoProducto(0.31, "ttssst", "Espesante"));
            aditivos2.Create(new AditivoProducto(1.65, "Mm --55", "Potenciador del sabor"));
            lacteo1.Aditivos = aditivos2.GetAll();
            lacteo1.ProcesarProducto(materiaPrimaDelDia, 1, "Baja temperatura ");

            if (lacteo1.MateriaPrimaAutorizada && lacteo1.Enfriado && lacteo1.Estandarizado && lacteo1.Pasteurizado)
            {
                System.Console.WriteLine("Procesamiento correcto del producto");
            }

            lacteos.Create(lacteo1);
            if (lacteos.GetAll().Count == 2)
            {
                System.Console.WriteLine("Se agrego correctamente a la coleccion el lacteo");
            }

            lacteo1.Pasteurizado = true;
            lacteo1.Enfriado = false;
            if(!(lacteo1.Pasteurizado && lacteo1.Enfriado))
            {
                System.Console.WriteLine("Se actualizado correctamente el lacteo");
            }

            lacteos.Update(lacteo1);


            lacteos.Remove(lacteo);

            if (lacteos.GetAll().Count > 1)
            {
                System.Console.WriteLine("Error al actualizar la lista de productos");
            }
            else
            {
                System.Console.WriteLine("Remocion correcta de la lista de productos");
            }


        }
    }
}

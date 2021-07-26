using Application.Models;
using Application.Models.DATOS;
using Application.Models.Logs;
using Application.Models.Repositorios;
using System;
using System.Linq;

namespace Application.Test.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            MateriaPrima materiaPrimaDelDia = new MateriaPrima(59, 598, 1.25, "mp 88");
            Persona tecnicoAutorizante = new Persona(130, 33258987, "prueba", "prueba", "revisor", "M", true);
            Tamizador tamizador = new Tamizador(4, "Tamizador 4");

            try
            {
                if (TamizadorDAO.Save(tamizador))
                {
                    System.Console.WriteLine("tamizador guardado ok");
                }
                if (tecnicoAutorizante.Guardar())
                {
                    System.Console.WriteLine("tecnico guardado ok");
                }

                if (MateriaPrima.GuardarMateriaPrima(materiaPrimaDelDia))
                {
                    System.Console.WriteLine("Materia prima guardada ok");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"No se puede agregar el lacteo: {ex.Message}", "error");
                Logger.LogException(ex.Message);
            }


            //Creo una lacteo

            int idInformePast = 0;
            int idInformeEst = 0;
            int idInformeInoculado = 0;
            int idInformeIncubadoYBatido = 0;
            int idInformeEnvasado = 0;
            //Genero los informes 
            InformePasteurizado infPast = new InformePasteurizado(tecnicoAutorizante.Legajo, 40, true, 20, true, true, "Baja temperatura", 33, idInformePast);
            InformeEstandarizado infEst = new InformeEstandarizado(tamizador.IdTamizador, tecnicoAutorizante.Legajo, 30, 1.2, 1.9, true, true, true, true, idInformeEst);
            InformeInoculado informeInoculado = new InformeInoculado(tecnicoAutorizante.Legajo, 38, true, 20, true, true, true, idInformeInoculado);
            InformeIncubacionYMezclado informeIncubacionYMezclado = new InformeIncubacionYMezclado(tecnicoAutorizante.Legajo, 38, 40, 2, 1.5, 1.8, 2.3, 33, true, true, true, true, idInformeIncubadoYBatido);
            InformeEnvasado informeEnvasado = new InformeEnvasado(tecnicoAutorizante.Legajo, "tetrabik", 8, true, true, 12258, true, idInformeEnvasado);
            try
            {
                idInformePast = infPast.Grabar();
                if (idInformePast > 0)
                {
                    System.Console.WriteLine("Se guardo ok el informe de pasteurizacion");
                }
                idInformeEst = infEst.Grabar();
                if (idInformeEst > 0)
                {
                    System.Console.WriteLine("Se guardo ok el informe de estandarizacion");
                }

                idInformeInoculado = informeInoculado.Grabar();
                if (idInformeInoculado > 0)
                {
                    System.Console.WriteLine("Se guardo ok el informe de inoculacion");
                }

                idInformeIncubadoYBatido = informeIncubacionYMezclado.Grabar();
                if (idInformeIncubadoYBatido > 0)
                {
                    System.Console.WriteLine("Se guardo ok el informe de batido e incubado");
                }
                idInformeEnvasado = informeEnvasado.Grabar();
                if (idInformeEnvasado > 0)
                {
                    System.Console.WriteLine("Se guardo ok el informe de envasado");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error guardando el informe  ex:" + ex.ToString());
            }

            RepositorioAditivos aditivos1 = new RepositorioAditivos();
            RepositorioLacteos lacteos = new RepositorioLacteos();
            aditivos1.Create(new AditivoProducto(10, "Mm", "Espesante", 1));
            aditivos1.Create(new AditivoProducto(0.3, "ttt", "Espesante", 2));
            aditivos1.Create(new AditivoProducto(1.25, "Mm 55", "Potenciador del sabor", 3));

            //Creo una lacteo
            Yogurth lacteo = new Yogurth();
            lacteo.IdMateriaPrima = materiaPrimaDelDia.IdMateriaPrima;
            lacteo.TipoProducto = "Yogurth";
            lacteo.Aditivos = aditivos1.GetAll();
            lacteo.IncubadoyMezclado = true;
            lacteo.InformeIncubacionYMezcla = idInformeIncubadoYBatido;
            lacteo.InformeEnvasado = idInformeEnvasado;
            lacteo.Envasado = true;
            lacteo.InformeInoculado = idInformeInoculado;
            lacteo.Inoculado = true;
            lacteo.Estandarizado = true;
            lacteo.InformeEstandarizado = idInformeEst;
            lacteo.Pasteurizado = true;
            lacteo.InformePasteurizado = idInformePast;

            try
            {
                if (LacteoDAO.Save(lacteo))
                {
                    System.Console.WriteLine("El lacteo de guardo ok");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error al guardar el lacteo ex:" + ex.ToString());
            }

            Lacteo lacteoAEditar = LacteoDAO.Read().Last();          

            try
            {
                InformePasteurizado infPasteurizado = InformePasteurizadoDAO.ReadById(lacteoAEditar.InformePasteurizado);

                lacteoAEditar.Pasteurizado = false;
                lacteoAEditar.InformePasteurizado = 0;

                if (infPasteurizado is null)
                {
                    throw new Exception("Error al levantar el informe pasteurizado de la db");
                }

                infPasteurizado.Eliminar();

                if (LacteoDAO.Update(lacteoAEditar))
                {
                    System.Console.WriteLine("El lacteo de actualizo ok");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error al editar el lacteo ex:" + ex.ToString());
            }

            try
            {
                if (LacteoDAO.Delete(lacteoAEditar.IdLacteo))
                {
                    System.Console.WriteLine("El lacteo se elimino ok");
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error al eliminar el lacteo ex:" + ex.ToString());
            }


            System.Console.ReadKey();
        }
    }
}

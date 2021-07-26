using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Application.Models;
using Application.Models.DATOS;
using Application.Models.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.TestUnitario
{
    [TestClass]
    public class FabricaTest
    {
        [TestMethod]
        public void CrearLacteo()
        {
            bool resultado = true;
            MateriaPrima materiaPrimaDelDia = new MateriaPrima(59, 598, 1.25, "mp 88");
            Persona tecnicoAutorizante = new Persona(DateTime.Now.Millisecond, 33258987, "prueba", "prueba", "revisor", "M", true);
            Tamizador tamizador = new Tamizador(4, "Tamizador 4");
            resultado = TamizadorDAO.Save(tamizador);
            resultado = tecnicoAutorizante.Guardar();
            resultado = MateriaPrima.GuardarMateriaPrima(materiaPrimaDelDia);

            RepositorioAditivos aditivos1 = new RepositorioAditivos();
            RepositorioLacteos lacteos = new RepositorioLacteos();
            aditivos1.Create(new AditivoProducto(10, "Mm", "Espesante", 1));
            aditivos1.Create(new AditivoProducto(0.3, "ttt", "Espesante", 2));
            aditivos1.Create(new AditivoProducto(1.25, "Mm 55", "Potenciador del sabor", 3));
            
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
      
            idInformePast = infPast.Grabar();
            idInformeEst = infEst.Grabar();
            idInformeInoculado = informeInoculado.Grabar();
            idInformeIncubadoYBatido = informeIncubacionYMezclado.Grabar();
            idInformeEnvasado = informeEnvasado.Grabar();
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

           if(resultado)
            {
                resultado = LacteoDAO.Save(lacteo);                
            }
            Assert.AreEqual(true, resultado);

        }
             

        [TestMethod]
        public void EditarLacteo()
        {
            bool resultado = true;
            Lacteo lacteoAEditar = LacteoDAO.Read().Last();
            InformePasteurizado infPasteurizado = InformePasteurizadoDAO.ReadById(lacteoAEditar.InformePasteurizado);
            if(infPasteurizado is null) { resultado = false; }
            if (resultado)
            {
                lacteoAEditar.Pasteurizado = false;
                lacteoAEditar.InformePasteurizado = 0;
                if (infPasteurizado.Eliminar())
                {
                    resultado =LacteoDAO.Update(lacteoAEditar);
                }
            }
            Assert.AreEqual(true, resultado);
        }

        [TestMethod]
        public void EliminarLacteo()
        {
            bool resultado = true;
            Lacteo lacteoAEditar = LacteoDAO.Read().Last();
            resultado = LacteoDAO.Delete(lacteoAEditar.IdLacteo);                

            Assert.AreEqual(true, resultado);
        }

        [TestMethod]
        public void GuardarMateriaPrimaDB()
        {
            MateriaPrima materiaPrimaDelDia = new MateriaPrima(255, 50, 1.25, "mp 3");
            MateriaPrima.GuardarMateriaPrima(materiaPrimaDelDia);
            MateriaPrima materiaPrimaGuardada = MateriaPrimaDAO.ReadByDescripcion(materiaPrimaDelDia.Descripcion);
            Assert.AreEqual(materiaPrimaDelDia.Descripcion, materiaPrimaGuardada.Descripcion);

        }
        [TestMethod]
        public void GuadarMateriaPrimaSerializador()
        {
            string file = ConfigurationManager.AppSettings["ArchivoMateriaPrima"];
            string ruta = AppDomain.CurrentDomain.BaseDirectory + @"\" + file + ".xml";
            //si existe el archivo lo borro para poder probar
            if (System.IO.File.Exists(ruta))
            {
                System.IO.File.Delete(ruta);
            }
            //creo la lista de materias primas
            List<MateriaPrima> materiaPrimaDelDia = new List<MateriaPrima>();

            materiaPrimaDelDia.Add(new MateriaPrima(255, 50, 1.25, "mp 3"));
            materiaPrimaDelDia.Add(new MateriaPrima(365, 70, 2.25, "mp 1"));
            materiaPrimaDelDia.Add(new MateriaPrima(275, 80, 3.25, "mp 4"));
            // genero el archivo serializado de materias
            MateriaPrima.GuardarMateriaPrima(materiaPrimaDelDia);
            //recupero en otra lista el archivo serializado
            List<MateriaPrima> materiasPrimas = MateriaPrima.CargarMateriaPrima();
            //si la cantidad de objetos de la lista  original es igual a la recupera esta ok
            Assert.AreEqual(materiasPrimas.Count, materiaPrimaDelDia.Count);
        }

    }
}

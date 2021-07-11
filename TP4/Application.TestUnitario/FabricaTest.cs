using System;
using Application.Models;
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
            MateriaPrima materiaPrimaDelDia = new MateriaPrima(255, 588, 1.25, "mp 1");
            materiaPrimaDelDia.LegajoTecnicoHabilitante = 889988;
            MateriaPrima.GuardarMateriaPrima(materiaPrimaDelDia);
            Lacteo lacteo = new Leche();
            lacteo.MpAutorizada = true;
            lacteo.Enfriado = true;
            lacteo.Estandarizado = true;
            lacteo.Pasteurizado = true;

            RepositorioAditivos aditivos1 = new RepositorioAditivos();
            RepositorioLacteos lacteos = new RepositorioLacteos();
            aditivos1.Create(new AditivoProducto(0.25, "Mm", "Espesante"));
            aditivos1.Create(new AditivoProducto(0.3, "ttt", "Espesante"));
            aditivos1.Create(new AditivoProducto(1.25, "Mm 55", "Potenciador del sabor"));
            lacteo.Aditivos = aditivos1.GetAll();
            bool expected = true;
            lacteo.ProcesarProducto(materiaPrimaDelDia.IdMateriaPrima, 12, "alta temperatura ");
            bool resultado = lacteo.MpAutorizada && lacteo.Enfriado && lacteo.Estandarizado && lacteo.Pasteurizado;
            Assert.AreEqual(expected, resultado);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CrearMateriaPrimaFaild()
        {
            MateriaPrima.GuardarMateriaPrima(null);
        }
    }
}

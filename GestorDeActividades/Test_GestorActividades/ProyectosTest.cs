using System;
using GestorDeActividades.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_GestorActividades
{
    [TestClass]
    public class ProyectosTest
    {
        [TestMethod]
        public void ValidarFormularioTest()
        {
            PROJECT obj = AsignarDatosProject();
            var proyecto = new GestorDeActividades.Controllers.PROJECTsController();
            var validForm = proyecto.ValidateForm(obj);

            Assert.IsTrue(validForm);

        }
        [TestMethod]
        public void ValidarFechasTest()
        {
            var validarProyecto = new ProyectosTest();
            var proyecto = new GestorDeActividades.Controllers.PROJECTsController();

            var resultado = proyecto.ValidarFechas(
                Convert.ToDateTime("31/12/2019"), 
                DateTime.Today
                );

            Assert.IsTrue(resultado);

        }

        public PROJECT AsignarDatosProject() 
        {
            PROJECT obj = new PROJECT();
            obj.pro_ncode           = 1;
            obj.pro_name            = string.Empty;
            obj.pro_initial_Date    = Convert.ToDateTime("01/06/2019");
            obj.pro_final_Date      = Convert.ToDateTime("01/07/2019");
            obj.tpr_ncode           = 1;

            return obj;

        }
    }
    
}

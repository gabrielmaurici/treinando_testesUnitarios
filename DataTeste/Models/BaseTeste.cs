using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataTeste.Models
{
    public class BaseTeste
    {
        [Fact]
        public void TestaCriacaoInstanciaBase()
        {
            // Arrange
            Action b;
            //Action
            b = () => Activator.CreateInstance<Base>();
            //Assert
            Assert.Throws<MissingMethodException>(b);
        }
    }
}

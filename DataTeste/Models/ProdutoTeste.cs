using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataTeste.Models
{
    public class ProdutoTeste
    {
        [Fact]
        public void TestaInstanciaClasseProduto()
        {
            //Arrange
            Produto p;
            //Action
            p = Activator.CreateInstance<Produto>();
            //Assert
            Assert.IsType<Produto>(p);
        }
        [Fact]
        public void TestaSeClasseProdutoHerdaBase()
        {
            //Arrange
            Produto p;
            //Action
            p = Activator.CreateInstance<Produto>();
            //Assert
            Assert.IsAssignableFrom<Base>(p);
        }
        [Fact]
        public void TestaSeExistemPropriedadesEmClasseProduto()
        {
            Type produtoType = typeof(Produto);

            PropertyInfo pI = produtoType.GetProperties().FirstOrDefault(p => p.Name == "Nome");
            Assert.NotNull(pI);

            pI = produtoType.GetProperties().FirstOrDefault(p => p.Name == "Valor");
            Assert.NotNull(pI);
        }
        [Fact]
        public void TestaTiposDasPropriedadesClasseProduto()
        {
            Type produtoType = typeof(Produto);

            PropertyInfo pI = produtoType.GetProperties().FirstOrDefault(p => p.Name == "Nome");
            Type tipoChecagem = typeof(string);
            Type tipoPropriedade = pI != null ? pI.PropertyType : null;
            Assert.Equal(tipoChecagem, tipoPropriedade);

            pI = produtoType.GetProperties().FirstOrDefault(p => p.Name == "Valor");
            tipoChecagem = typeof(decimal);
            tipoPropriedade = pI != null ? pI.PropertyType : null;
            Assert.Equal(tipoChecagem, tipoPropriedade);
        }
        [Fact]
        public void TestaGetDasPropriedadesClasseProduto()
        {
            Produto produto = new Produto();
            Type tipoProduto = typeof(Produto);

            PropertyInfo pI = tipoProduto.GetProperties().FirstOrDefault(p => p.Name == "Nome");
            object valorPropriedade = null;
            if (pI != null && pI.PropertyType == typeof(String))
            {
                pI.SetValue(produto, "");
                valorPropriedade = pI.GetValue(produto);
            }
            Assert.NotNull(valorPropriedade);

            pI = tipoProduto.GetProperties().FirstOrDefault(p => p.Name == "Valor");
            valorPropriedade = null;
            if(pI != null && pI.PropertyType == typeof(Decimal))
            {
                pI.SetValue(produto, 530.50m);
                valorPropriedade = pI.GetValue(produto);
            }
            Assert.NotNull(valorPropriedade);

            pI = tipoProduto.GetProperties().FirstOrDefault(p => p.Name == "Id");
            valorPropriedade = null;
            if (pI != null && pI.PropertyType == typeof(int))
            {
                pI.SetValue(produto, 1);
                valorPropriedade = pI.GetValue(produto);
            }
            Assert.NotNull(valorPropriedade);
        }
    }
}

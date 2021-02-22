using Banco.Atlantico.API.Controllers;
using Banco.Atlantico.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Banco.Atlantico.Teste.ControllerTest
{
    public class CaixasControllerTest
    {
        private AutoMocker _mocker;
        private readonly CaixasController _caixasController;

        public CaixasControllerTest()
        {
            _mocker = new AutoMocker();
            _caixasController = _mocker.CreateInstance<CaixasController>();
        }


        [Fact(DisplayName = "Caixas Async - 200")]
        [Trait("Categoria", "Controller - Consultar Caixas - 200")]
        public async Task Consultar_Caixas_Async_Sucesso_200()
        {
            // Arrange
            var _correlationId = Guid.NewGuid().ToString();
             _mocker.GetMock<ICaixasService>()
               .Setup(c => c.CaixasAsync(_correlationId));

            // Act
            var result = await _caixasController.CaixasAsync();
            var resultStatus = result as ObjectResult;

            // Assert
            Assert.NotNull(resultStatus);
            Assert.Equal(200, resultStatus.StatusCode);
        }
    }
}

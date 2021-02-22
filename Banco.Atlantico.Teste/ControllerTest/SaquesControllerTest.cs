using Banco.Atlantico.API.Controllers;
using Banco.Atlantico.Application;
using Banco.Atlantico.Application.Interfaces;
using Banco.Atlantico.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Banco.Atlantico.Teste.ControllerTest
{
    public class SaquesControllerTest
    {
        private AutoMocker _mocker;
        private readonly SaquesController _saquesController;


        public SaquesControllerTest()
        {
            Environment.SetEnvironmentVariable("VALOR_MINIMO", "0");
            Environment.SetEnvironmentVariable("VALOR_MAXIMO", "1000");
            _mocker = new AutoMocker();
            _saquesController = _mocker.CreateInstance<SaquesController>();

        }
        
        [Fact(DisplayName = "Saque Async - 400")]
        [Trait("Categoria", "Controller - Consultar Caixas - 400")]
        public async Task Saque_Async_BadRequest_400()
        {
            // Arrange
            var _correlationId = Guid.NewGuid().ToString();
            var saque = new SaqueViewModel();
            saque.ClienteId = "2v/Y2GtNHhwtnoTVa4lyAcDyT+IyEAbOLyMDXjRVYbA=";
            saque.IdCaixa = "1";
            saque.Valor = 80;

            _mocker.GetMock<ISaquesService>()
              .Setup(c => c.SaqueAsync(saque, _correlationId));

            // Act
            var result = await _saquesController.SaquesAsync(saque);
            var resultStatus = result as ObjectResult;

            // Assert
            Assert.NotNull(resultStatus);
            Assert.Equal(400, resultStatus.StatusCode);
        }

        [Fact(DisplayName = "Caixas Async - 412")]
        [Trait("Categoria", "Controller - Saque - 412")]
        public async Task Saque_Async_PreconditionFailed_412()
        {
            // Arrange
            var _correlationId = Guid.NewGuid().ToString();
            var saque = new SaqueViewModel();
            saque.ClienteId = "2v/Y2GtNHhwtnoTVa4lyAcDyT+IyEAbOLyMDXjRVYbA=";
            saque.IdCaixa = "2v/Y2GtNHhwtnoTVa4lyAcDyT+IyEAbOLyMDXjRVYbA=";
            saque.Valor = 2000;

            _mocker.GetMock<ISaquesService>()
              .Setup(c => c.SaqueAsync(saque, _correlationId));

            // Act
            var result = await _saquesController.SaquesAsync(saque);
            var resultStatus = result as ObjectResult;

            // Assert
            Assert.NotNull(resultStatus);
            Assert.Equal(412, resultStatus.StatusCode);
        }
    }
}

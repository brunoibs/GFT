using GFT.Api.Controllers;
using GFT.Api.Model;
using GFT.Api.Service;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;


namespace GFT.Test
{
    public class InvestimentoControllerTests
    {
        private readonly Mock<IInvestimentoService> _mockInvestimentoService;
        private readonly InvestimentoController _controller;

        public InvestimentoControllerTests()
        {
            _mockInvestimentoService = new Mock<IInvestimentoService>();
            _controller = new InvestimentoController(_mockInvestimentoService.Object);
        }

        [Fact]
        public void CalcularInvestimento_RetornaResultadoEsperado()
        {
            // Arrange
            var request = new InvestimentoRequest { ValorInicial = 1000, Prazo = 12 };
            var expectedResponse = new InvestimentoResponse
            {
                ValorBruto = 1100, // valor esperado ajustado
                ValorLiquido = 1080 // valor esperado ajustado
            };

            _mockInvestimentoService.Setup(service => service.CalcularInvestimento(request))
                .Returns(expectedResponse);

            // Act
            var result = _controller.CalcularInvestimento(request);
            var okResult = result.Result as OkObjectResult;
            var response = okResult.Value as InvestimentoResponse;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(expectedResponse.ValorBruto, response.ValorBruto);
            Assert.Equal(expectedResponse.ValorLiquido, response.ValorLiquido);
        }

        [Fact]
        public void CalcularInvestimento_ComPrazoInvalido_RetornaBadRequest()
        {
            // Arrange
            var request = new InvestimentoRequest { ValorInicial = 1000, Prazo = 1 };

            // Act
            var result = _controller.CalcularInvestimento(request);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
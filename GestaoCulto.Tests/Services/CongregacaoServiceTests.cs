using GestaoCulto.Repository.Interfaces;
using GestaoCulto.Services.Class;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace GestaoCulto.Tests.Services
{
    public class CongregacaoServiceTests
    {

        private CongregacaoService congregacaoService;

        public CongregacaoServiceTests()
        {
            congregacaoService = new CongregacaoService(new Mock<ICongregacaoRepository>().Object);
        }

        [Fact]
        public async void BuscarPorAtivos_Filter()
        {
            var result = await congregacaoService.BuscarExpressao(x => x.Status.Equals("A"));

            Assert.True(result.ToList().Count > 0);
            //Assert.Throws<Exception>( () =>  congregacaoService.BuscarExpressao(x => x.Status.Equals("A")).Result);
        }

    }
}

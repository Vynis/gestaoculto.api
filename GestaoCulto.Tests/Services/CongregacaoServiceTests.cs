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

        }

        [Fact]
        public async void BuscarPorAtivos_Filter()
        {

            //Assert.Throws<Exception>( () =>  congregacaoService.BuscarExpressao(x => x.Status.Equals("A")).Result);
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GestaoCulto.Shared
{
    public class BaseController : Controller
    {
        protected new IActionResult Response(object result = null, bool success = true)
        {
            return Ok(new
            {
                success = success,
                data = result
            });
        }

        protected IActionResult ResultadoPesquisa(IEnumerable<object> lista)
        {
            return Ok(new
            {
                success = true,
                data = lista,
                quantidade = lista.Count()
            });
        }


    }
}

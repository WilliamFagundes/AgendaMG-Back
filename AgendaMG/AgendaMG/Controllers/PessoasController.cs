using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaMG.Business;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AgendaMG.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PessoasController : Controller
    {
        readonly PessoaBusiness _pessoaBusiness;
        public PessoasController(PessoaBusiness pessoaBusiness)
        {
            _pessoaBusiness = pessoaBusiness;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet()]
        [ActionName("GetListPessoa")]
        public IActionResult GetListPessoa()
        {
            try
            {
                var listaPessoas = _pessoaBusiness.GetListPessoas();

                return Ok(listaPessoas);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }
        [HttpPost]
        [ActionName("AddPessoa")]
        public IActionResult AddPessoa()
        {
            try
            {
                JObject jsonPessoa;
                using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    var tempObj = reader.ReadToEnd();
                    jsonPessoa = JsonConvert.DeserializeObject<JObject>(tempObj);
                }

                var lista = _pessoaBusiness.AddPessoa(jsonPessoa);

                return Ok(lista);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        [ActionName("UpdatePessoa")]
        public IActionResult UpdatePessoa()
        {
            try
            {
                JObject jsonPessoa;
                using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    var tempObj = reader.ReadToEnd();
                    jsonPessoa = JsonConvert.DeserializeObject<JObject>(tempObj);
                }

                var lista = _pessoaBusiness.UpdatePessoa(jsonPessoa);

                return Ok(lista);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("{idPessoa:maxlength(2)}")]
        [ActionName("DeletePessoa")]
        public IActionResult DeletePessoa(int idPessoa)
        {
            try
            {
                var listaPessoas = _pessoaBusiness.DeletePessoa(idPessoa);

                return Ok(listaPessoas);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }
    }
}
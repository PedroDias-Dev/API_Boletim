using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Boletim.Domain;
using API_Boletim.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Boletim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        AlunoRepository repo = new AlunoRepository();

        // GET: api/Aluno
        [HttpGet]
        public List<Aluno> Get()
        {
            return repo.LerTodos();
        }

        // GET: api/Aluno/5
        [HttpGet("{id}")]
        public Aluno Get(int id)
        {
            return repo.BuscarPorId(id);
        }

        // POST: api/Aluno
        public Aluno Post([FromBody] Aluno novoAluno)
        {
            return repo.Cadastrar(novoAluno);
        }

        // PUT: api/Aluno/5
        [HttpPut("{id}")]
        public Aluno Put(int id, [FromBody] Aluno novoAluno)
        {
            return repo.Alterar(id, novoAluno);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.Excluir(id);
        }
    }
}

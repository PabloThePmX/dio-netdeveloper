using Microsoft.AspNetCore.Mvc;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly OrganizadorContext _context;

        public TarefaController(OrganizadorContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            //busca o registro pelo id
            var tarefaBanco = _context.Tarefas.Find(id);

            //caso nao encontrar, retorna not found
            if(tarefaBanco == null)
                return NotFound();

            return Ok(tarefaBanco);
        }

        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos()
        {
            //busca todos os registros da tabela
            var tarefaBanco = _context.Tarefas;

            return Ok(tarefaBanco);
        }

        [HttpGet("ObterPorTitulo")]
        public IActionResult ObterPorTitulo(string titulo)
        {
            //faz um where e filtra pelo valor do titulo
            var tarefaBanco = _context.Tarefas.Where(x => x.Titulo == titulo);

            //caso nao encontrar algum valor, retorna not found
            if (!tarefaBanco.Any())
                return NotFound();

            return Ok(tarefaBanco);
        }

        [HttpGet("ObterPorData")]
        public IActionResult ObterPorData(DateTime data)
        {
            var tarefaBanco = _context.Tarefas.Where(x => x.Data.Date == data.Date);

            //caso nao encontrar algum valor, retorna not found
            if (!tarefaBanco.Any())
                return NotFound();

            return Ok(tarefaBanco);
        }

        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(EnumStatusTarefa status)
        {
            var tarefaBanco = _context.Tarefas.Where(x => x.Status == status);

            //caso nao encontrar algum valor, retorna not found
            if (!tarefaBanco.Any())
                return NotFound();

            return Ok(tarefaBanco);
        }

        [HttpPost]
        public IActionResult Criar(Tarefa tarefa)
        {
            if (tarefa.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            //adiciona o registro da tarefa que recebeu por parametro no banco e salva
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();

            //chamar o metodo que retorna o id, qual parametro vai ser enviado na rota e qual vai ser o objeto incluido na resposta
            return CreatedAtAction(nameof(ObterPorId), new { id = tarefa.Id }, tarefa);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Tarefa tarefa)
        {
            var tarefaBanco = _context.Tarefas.Find(id);

            if (tarefaBanco == null)
                return NotFound();

            if (tarefa.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            //atualiza os valores do registro no banco, por aqueles recebidos pelo parametro
            tarefaBanco.Titulo = tarefa.Titulo;
            tarefaBanco.Descricao = tarefa.Descricao;
            tarefaBanco.Data = tarefa.Data;
            tarefaBanco.Status = tarefa.Status;

            //faz um update e salva no banco
            _context.Tarefas.Update(tarefaBanco);
            _context.SaveChanges();

            return Ok(tarefaBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var tarefaBanco = _context.Tarefas.Find(id);

            if (tarefaBanco == null)
                return NotFound();

            //remove o registro no banco e salva a alteracao
            _context.Tarefas.Remove(tarefaBanco);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

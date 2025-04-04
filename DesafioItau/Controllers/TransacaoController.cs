using DesafioItaú.Dto;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DesafioItaú.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TransacaoController : ControllerBase
    {
        private readonly TransacaoSingleton _transacaoSingleton;

        private readonly IValidator<TrasacaoDto> _validator;

        public TransacaoController(IValidator<TrasacaoDto> validator)
        {
            _transacaoSingleton = TransacaoSingleton.Instance;
            _validator = validator;
        }

        [HttpGet("estatistica")]
        public ActionResult<EstatisticaDto> Get()
        {
            int count = 0;
            double sum = 0;
            double min = 0;
            double max = 0;
            double avg = 0;

            foreach (var item in _transacaoSingleton.Transacoes)
            {
                if (item.DataHora > DateTime.Now.AddMinutes(-1))
                {
                    if (count == 0)
                    {
                        min = item.Valor;
                        max = item.Valor;
                    }

                    sum += item.Valor;

                    min = min > item.Valor ? item.Valor : min;

                    max = max < item.Valor ? item.Valor : max;

                    count++;
                }
            }

            if (count != 0) avg = sum / count;

            return Ok(new EstatisticaDto
            {
                Count = count,
                Sum = sum,
                Min = min,
                Max = max,
                Avg = avg

            });
        }

        [HttpDelete("transacao")]
        public ActionResult Delete()
        {
            _transacaoSingleton.Transacoes.Clear();
            return Ok();
        }

        [HttpPost("transacao")]
        public async Task<ActionResult> Post([FromBody] TrasacaoDto transacao)
        {
            var validationResult = await _validator.ValidateAsync(transacao);

            if (!validationResult.IsValid) return UnprocessableEntity(validationResult.Errors);

            _transacaoSingleton.Transacoes.Add(transacao);

            return Created();
        }
    }
}

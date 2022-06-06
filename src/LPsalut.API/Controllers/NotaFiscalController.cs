using LPsalut.API.Application.NotaFiscal.Command;
using LPsalut.API.Application.NotaFiscal.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LPsalut.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotaFiscalController : Controller
    {
        private readonly IMediator _mediator;

        public NotaFiscalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllNotaFiscals(CancellationToken cancellationToken)
        {
            var notaFiscals = await _mediator.Send(new GetAllNotaFiscalsQuery(), cancellationToken)
                .ConfigureAwait(false);

            return notaFiscals.Any() ? Ok(notaFiscals) : NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateNotaFiscalCommand createNotaFiscalCommand,
            CancellationToken cancellationToken)
        {
            if (!createNotaFiscalCommand.Validation.IsValid)
                return BadRequest(createNotaFiscalCommand.Validation.Errors);

            var sucesso = await _mediator.Send(createNotaFiscalCommand, cancellationToken)
                .ConfigureAwait(false);

            return Ok(sucesso);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateNotaFiscalCommand updateNotaFiscalCommand,
            CancellationToken cancellationToken)
        {
            var sucesso = await _mediator.Send(updateNotaFiscalCommand, cancellationToken)
                .ConfigureAwait(false);

            return Ok(sucesso);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(DeleteNotaFiscalCommand deleteNotaFiscalCommand,
            CancellationToken cancellationToken)
        {
            var sucesso = await _mediator.Send(deleteNotaFiscalCommand, cancellationToken)
                .ConfigureAwait(false);

            return Ok(sucesso);
        }
    }
}

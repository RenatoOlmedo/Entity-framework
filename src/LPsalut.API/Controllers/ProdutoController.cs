using LPsalut.API.Application.Produto.Command;
using LPsalut.API.Application.Produto.Query;
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
    public class ProdutoController : Controller
    {
        private readonly IMediator _mediator;

        public ProdutoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProdutos(CancellationToken cancellationToken)
        {
            var produtos = await _mediator.Send(new GetAllProdutosQuery(), cancellationToken)
                .ConfigureAwait(false);

            return produtos.Any() ? Ok(produtos) : NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateProdutoCommand createProdutoCommand,
            CancellationToken cancellationToken)
        {
            if (!createProdutoCommand.Validation.IsValid)
                return BadRequest(createProdutoCommand.Validation.Errors);

            var sucesso = await _mediator.Send(createProdutoCommand, cancellationToken)
                .ConfigureAwait(false);

            return Ok(sucesso);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateProdutoCommand updateProdutoCommand,
            CancellationToken cancellationToken)
        {
            var sucesso = await _mediator.Send(updateProdutoCommand, cancellationToken)
                .ConfigureAwait(false);

            return Ok(sucesso);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(DeleteProdutoCommand deleteProdutoCommand,
            CancellationToken cancellationToken)
        {
            var sucesso = await _mediator.Send(deleteProdutoCommand, cancellationToken)
                .ConfigureAwait(false);

            return Ok(sucesso);
        }
    }
}

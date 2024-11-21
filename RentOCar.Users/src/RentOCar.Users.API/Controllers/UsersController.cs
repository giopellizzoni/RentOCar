using MediatR;

using Microsoft.AspNetCore.Mvc;

using RentOCar.Users.Application.Commands.CreateUser;
using RentOCar.Users.Application.Commands.DeleteUser;
using RentOCar.Users.Application.Commands.UpdateUser;
using RentOCar.Users.Application.Queries.GetUserById;
using RentOCar.Users.Application.Queries.GetUsers;

namespace RentOCar.Users.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ISender _mediator;

    public UsersController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get(string search)
    {
        var query = new GetUsersQuery(search);
        var result = await _mediator.Send(query);

        if(!result.IsSuccess)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Get(Guid id)
    {
        var query = new GetUserByIdQuery(id);
        var result = await _mediator.Send(query);
        if (!result.IsSuccess)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Post(CreateUserCommand command)
    {
        var result = await _mediator.Send(command);
        if(!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return CreatedAtAction(nameof(Get), new { id = result.Data?.Id, }, result);
    }


    [HttpPut("{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Put(Guid id, UpdateUserCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteUserCommand(id);
        var result = await _mediator.Send(command);
        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return NoContent();
    }

}

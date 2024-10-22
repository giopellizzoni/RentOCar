using MediatR;

using Microsoft.AspNetCore.Mvc;

using RentOCar.Users.Application.Commands.CreateUser;
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
    public async Task<IActionResult> GetAllUsers(string search)
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
    public async Task<IActionResult> GetUserById(Guid id)
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
    public async Task<IActionResult> CreateUser(CreateUserCommand command)
    {
        var result = await _mediator.Send(command);
        if(!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return CreatedAtAction(nameof(GetUserById), new { id = result.Data?.Id, }, result);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, UpdateUserCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }

}

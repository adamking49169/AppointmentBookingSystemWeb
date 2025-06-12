using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class BusController : ControllerBase
{
    private readonly ServiceBusService _busService;

    public BusController(ServiceBusService busService)
    {
        _busService = busService;
    }

    [HttpPost("send")]
    public async Task<IActionResult> Send([FromBody] string message)
    {
        await _busService.SendMessageAsync(message);
        return Ok("Message sent!");
    }

    [HttpGet("receive")]
    public async Task<IActionResult> Receive()
    {
        var message = await _busService.ReceiveMessageAsync();
        return Ok(message);
    }
}

using AddressService.Application.DTOs;
using AddressService.Application.Interfaces;
using AddressService.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace AddressService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonAddressController : ControllerBase
    {
        private readonly ICreatePersonAddress _createPersonAddress;
        private readonly IUpdatePersonAddress _updatePersonAddress;
        private readonly IDeletePersonAddress _deletePersonAddress;
        private readonly IListPersonAddress _listPersonAddress;
        private readonly IGetPersonAddress _getPersonAddress;

        public PersonAddressController(ICreatePersonAddress createPersonAddress
            , IUpdatePersonAddress updatePersonAddress
            , IDeletePersonAddress deletePersonAddress
            , IListPersonAddress listPersonAddress
            , IGetPersonAddress getPersonAddress)
        {
            _createPersonAddress = createPersonAddress;
            _updatePersonAddress = updatePersonAddress;
            _deletePersonAddress = deletePersonAddress;
            _listPersonAddress = listPersonAddress;
            _getPersonAddress = getPersonAddress;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var addresses = await _listPersonAddress.ExecuteAsync();
            return Ok(addresses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddress(string id)
        {
            var decodedId = Uri.UnescapeDataString(id);
            var addresses = await _getPersonAddress.ExecuteAsync(decodedId);
            return Ok(addresses);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonAddressDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _createPersonAddress.ExecuteAsync(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] PersonAddressDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var decodedId = Uri.UnescapeDataString(id);
            await _updatePersonAddress.ExecuteAsync(decodedId, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var decodedId = Uri.UnescapeDataString(id);
            await _deletePersonAddress.ExecuteAsync(decodedId);
            return Ok();
        }
    }
}

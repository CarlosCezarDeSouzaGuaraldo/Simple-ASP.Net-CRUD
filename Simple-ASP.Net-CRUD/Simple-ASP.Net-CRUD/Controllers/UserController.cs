using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Simple_ASP.Net_CRUD.Models;
using Simple_ASP.Net_CRUD.Repositories.Interfaces;

namespace Simple_ASP.Net_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAllUsers()
        {
            List<UserModel> users = await _userRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> FindById(int id)
        {
            UserModel users = await _userRepository.FindById(id);
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> SignUp([FromBody] UserModel userModel)
        {
            UserModel user = await _userRepository.Add(userModel);

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Update([FromBody] UserModel userModel, int id)
        {
            userModel.Id = id;
            UserModel user = await _userRepository.Update(userModel, id);

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> Delete(int id)
        {
            bool userRemoved = await _userRepository.Delete(id);
            return Ok(userRemoved);
        }
    }
}

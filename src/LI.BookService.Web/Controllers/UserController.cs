using LI.BookService.Bll.Helpers;
using LI.BookService.Core.Interfaces;
using LI.BookService.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
        private IUserService _userService;
        
        public UserController(IUserService userService)
        {
           _userService = userService;
        }

        /// <summary>
        /// получение  пользователя
        /// </summary>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<ActionResult> GetUser(int userId)
        {
            var userDto = await _userService.GetUserAsync(userId);

            return Ok(userDto);
        }

        /// <summary>
        /// создание  пользователя
        /// </summary>
        /// <param name="createUserDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserDTO createUserDTO)
        {
            if (createUserDTO != null)
            {
                var user = await _userService.CreateUserAsync(createUserDTO);
                return Ok(user);
            }
            else
            {
                return BadRequest();
            }

        }

        /// <summary>
        /// редактирование пользователя
        /// </summary>
        /// <param name="editedUserDTO"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<DtoUserAddress>> UpdateUser([FromBody] EditedUserDTO editedUserDTO)
        {
            try
            {
                if (editedUserDTO != null)
                {
                    var user = await _userService.EditUserAsync(editedUserDTO);
                    return Ok(user);
                }
                return BadRequest("некорректный id адреса пользователя");

            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    
    [HttpPost("login")]
    public async Task<IActionResult> Authenticate(LoginUserDTO model)
    {
        var response = await _userService.Authenticate(model);

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(response);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(CreateUserDTO userModel)
    {
        var response = await _userService.Register(userModel);

        if (response == null)
        {
            return BadRequest(new { message = "Didn't register!" });
        }

        return Ok(response);
    }

}


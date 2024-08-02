using EBusiness.API.Dtos;
using EBusiness.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EBusiness.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticatesController : ControllerBase
    {
        private readonly IAuthenticateUser _authenticateUser;
        //private readonly ITokenService _tokenService;
        //private readonly IMapper _mapper;
        private readonly ILogger<AuthenticatesController> _logger;

        public AuthenticatesController(IAuthenticateUser authenticateUser)
        {
            _authenticateUser = authenticateUser;
            //_tokenService = tokenService;
            //_mapper = mapper;
            //_logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            var user = await _authenticateUser.RegisterUser(userRegisterDto);
            if (user == null)
            {
                return BadRequest("User already exists");
            }
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var user = await _authenticateUser.LoginUser(userLoginDto);
            if (user == null)
            {
                return Unauthorized("Invalid email or password");
            }
            return Ok(new
            {
                //token = _tokenService.CreateToken(user),
                user
            });
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            var user = await _authenticateUser.UpdateUser(userUpdateDto);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            return Ok(user);
        }

        [HttpPost("find")]
        public async Task<IActionResult> Find(FindUserByEmailDto findUserByEmailDto)
        {
            var user = await _authenticateUser.FindUserByEmail(findUserByEmailDto);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            return Ok(user);
        }
    }
}

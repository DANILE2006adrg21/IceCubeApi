using IceCube.Context;
using IceCube.Models;
using IceCube.Models.Auth;
using IceCube.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace IceCube.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IceCube_Apicontext _context;

        public AuthController(IceCube_Apicontext context)
        {
            _context = context;
        }

        // ============================
        // 🔹 REGISTRO
        // ============================
        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> Register(RegisterRequest req)
        {
            if (req == null)
                return BadRequest(new AuthResponse { Success = false, Message = "Solicitud inválida." });

            if (string.IsNullOrWhiteSpace(req.Email))
                return BadRequest(new AuthResponse { Success = false, Message = "El correo es obligatorio." });

            if (string.IsNullOrWhiteSpace(req.Password))
                return BadRequest(new AuthResponse { Success = false, Message = "La contraseña es obligatoria." });

            // Validar formato de email
            if (!Regex.IsMatch(req.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return BadRequest(new AuthResponse { Success = false, Message = "El correo no es válido." });

            // Validar longitud mínima
            if (req.Password.Length < 6)
                return BadRequest(new AuthResponse { Success = false, Message = "La contraseña debe tener al menos 6 caracteres." });

            var email = req.Email.Trim().ToLower();

            if (await _context.Usuarios.AnyAsync(u => u.Email == email))
            {
                return Conflict(new AuthResponse
                {
                    Success = false,
                    Message = "El correo ya está registrado."
                });
            }

            var user = new Usuario
            {
                Email = email,
                PasswordHash = PasswordHelper.Hash(req.Password),
                FechaRegistro = DateTime.UtcNow
            };

            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new AuthResponse
            {
                Success = true,
                Message = "Registro exitoso",
                UserId = user.Id
            });
        }

        // ============================
        // 🔹 LOGIN
        // ============================
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(LoginRequest req)
        {
            if (req == null)
                return BadRequest(new AuthResponse { Success = false, Message = "Solicitud inválida." });

            if (string.IsNullOrWhiteSpace(req.Email) || string.IsNullOrWhiteSpace(req.Password))
                return BadRequest(new AuthResponse { Success = false, Message = "Debe ingresar correo y contraseña." });

            var email = req.Email.Trim().ToLower();

            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return Unauthorized(new AuthResponse
                {
                    Success = false,
                    Message = "Usuario o contraseña incorrectos"
                });
            }

            if (!PasswordHelper.Verify(req.Password, user.PasswordHash))
            {
                return Unauthorized(new AuthResponse
                {
                    Success = false,
                    Message = "Usuario o contraseña incorrectos"
                });
            }

            return Ok(new AuthResponse
            {
                Success = true,
                Message = "Login correcto",
                UserId = user.Id
            });
        }
    }
}


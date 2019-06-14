using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Shared.DTOs;
using DataAccesLayer;
using DataAccesLayer.Models;

namespace WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;


        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IConfiguration configuration,
            RoleManager<IdentityRole> rolManager,
            ApplicationDbContext context
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _roleManager = rolManager;
            _context = context;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<object> Login([FromBody] LoginDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
                var res = GenerateJwtTokenAsync(model.Email, appUser);
                var aux = res.Result;

                Cliente cli = _context.Clientes.FirstOrDefault(x => x.Usuario == model.Email);

                return new LoginModel() {
                    token = aux.ToString(),
                    email = model.Email,
                    role = (await _userManager.GetRolesAsync(appUser)).FirstOrDefault(),
                    Apellidos = cli == null ? "" : cli.Apellidos,
                    Nombres = cli == null ? "" : cli.Nombres,
                    Documento = cli == null ? "" : cli.Documento,
                };
            }

            return StatusCode(500, "Usuario o contraseña incorrecta.");
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<object> Register([FromBody] RegistroDto model)
        {
            try
            {
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                if (model.Nombres == null || model.Nombres.Length < 3)
                    model.Nombres = "Nombres";

                if (model.Apellidos == null || model.Apellidos.Length < 3)
                    model.Apellidos = "Apellidos";

                if (model.Documento == null || model.Documento.Length < 3)
                    model.Documento = "Documento";

                if (model.Apellidos.Length < 3 || model.Nombres.Length < 3 || model.Documento.Length < 3)
                    return StatusCode(500, "El nombre, apellido y documento del usuario tienen que tener mas de 3 caracteres.");

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    Cliente cli = new Cliente()
                    {
                        Apellidos = model.Apellidos,
                        Nombres = model.Nombres,
                        Documento = model.Documento,
                        Usuario = model.Email
                    };
                    _context.Clientes.Add(cli);
                    _context.SaveChanges();

                    List<string> l = new List<string>();
                    l.Add("USER");
                    await _userManager.AddToRolesAsync(user, l);

                    await _signInManager.SignInAsync(user, false);
                    var aux = GenerateJwtTokenAsync(model.Email, user);

                    return new LoginModel()
                    {
                        token = aux.Result.ToString(),
                        email = model.Email,
                        role = "USER",
                        Apellidos = model.Apellidos,
                        Nombres = model.Nombres,
                        Documento = model.Documento,
                    };
                }
                else
                {
                    return StatusCode(500, "Error no contralado al crear el usuario.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private async Task<object> GenerateJwtTokenAsync(string email, IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (string r in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, r));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
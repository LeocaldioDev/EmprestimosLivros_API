using EmprestimoLivros.Domain.Account;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivros.Infra.Data.Identity
{
    public class AuthenticateServices : IAuthenticate
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IConfiguration _configuration;

        public AuthenticateServices(ApplicationDBContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }


        public async Task<bool> AuthenticateAsync(string email, string senha)
        {
            var usuario = await _dbContext.Usuario.Where(x => x.email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
            if (usuario == null)
                return false;
            using var hmac = new HMACSHA512(usuario.passwordSalt);
            var ComputerHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));
            // CÓDIGO SEGURO (CONSTANT-TIME)
            int mismatches = 0; // 1. Variável para ACUMULAR as diferenças.

            for (int i = 0; i < ComputerHash.Length; i++)
            {
                // O loop forçará a comparação de CADA byte, do primeiro ao último.

                if (ComputerHash[i] != usuario.passwordHash[i])
                {
                    mismatches++; // 2. Se houver uma diferença, incrementamos o contador.
                }
            }

            // 3. A decisão final (true ou false) é feita SÓ AQUI, depois de todo o tempo de processamento.
            return mismatches == 0; // Se o contador for zero, os hashes coincidem.

        }

        public string GenerateToken(int id, string email)
        {
            var claims = new[]
            {
                new Claim("id", id.ToString()),
                new Claim("email", email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var Privatekey = new SymmetricSecurityKey(Encoding.UTF8.
                GetBytes(_configuration["Jwt:secretKey"]));
            var credentials = new SigningCredentials(Privatekey, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.Now.AddMinutes(10);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<Usuario> GetUserByEmail(string email)
        {
            return await _dbContext.Usuario.Where(x => x.email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
        }

        public async Task<bool> UserExists(string email)
        {
            var usuario = await _dbContext.Usuario.Where(x => x.email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
            if (usuario == null)
                return false;

            return true;
        }
    }
}

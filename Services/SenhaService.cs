using System;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using BC = BCrypt.Net.BCrypt;

using musiC.Data;
using musiC.Models;

namespace musiC.Services
{

    public static class SenhaService
    {

        public static string GerarHash(string senha)
        {
            return BC.HashPassword(senha);
        }

        public static bool CompararHash(string senhaEnviada, string hashBanco)
        {
            try
            {
                return BC.Verify(senhaEnviada, hashBanco);
            }
            catch (BCrypt.Net.SaltParseException)
            {
                return false;
            }
        }
    }
}
using ChapterUC17.Controllers;
using ChapterUC17.Interfaces;
using ChapterUC17.Models;
using ChapterUC17.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Moq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace TesteIntegracao
{
    public class LoginControllerTeste
    {
        [Fact]
        public void LoginController_Retornar_Usuario_Invalido()
        {
            var repositoryEspelhado = new Mock<IUsuarioRepository>();

            repositoryEspelhado.Setup(x => x.Login(It.IsAny<String>(), It.IsAny<String>())).Returns((Usuario)null);

            var controller = new LoginController(repositoryEspelhado.Object);

            LoginViewModel dadosUsuario = new LoginViewModel();
            dadosUsuario.email = "batata@email.com";
            dadosUsuario.senha = "batata";

            var resultado = controller.Login(dadosUsuario);

            Assert.IsType<UnauthorizedObjectResult>(resultado);

        }

        [Fact]

        public void LoginController_Retornar_Token()
        {
            Usuario usuarioRetornado = new Usuario();
            usuarioRetornado.Email = "email@email.com";
            usuarioRetornado.Senha = "1234";
            usuarioRetornado.Tipo = "0";
            usuarioRetornado.id = 1;

            var repositoryEspelhado = new Mock<IUsuarioRepository>();

            repositoryEspelhado.Setup(x => x.Login(It.IsAny<String>(), It.IsAny<String>())).Returns(usuarioRetornado);

            LoginViewModel dadosUsuario = new LoginViewModel();
            dadosUsuario.email = "batata@email.com";
            dadosUsuario.senha = "batata";

            var controller = new LoginController(repositoryEspelhado.Object);
            string issuervalido = "chapter.webapi";

            OkObjectResult resultado = (OkObjectResult)controller.Login(dadosUsuario);

            string tokenString = resultado.Value.ToString().Split(' ')[3];

            var jwtHandler = new JwtSecurityTokenHandler();

            var tokenJwt = jwtHandler.ReadJwtToken(tokenString);

            Assert.Equal(issuervalido, tokenJwt.Issuer);




        }
        
    }
}
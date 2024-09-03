using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIGeraSenha.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class GerarSenhaController : ControllerBase
        {
            private readonly List<char> caracteresMaiusculas = new List<char>();
            private readonly List<char> caracteresMinusculas = new List<char>();
            private readonly List<string> nuns = new List<string>();
            private readonly List<char> especiais = new List<char>()
            {
                '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/',
                ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~'
            };

            public GerarSenhaController()
            {
                for (char letra = 'A'; letra <= 'Z'; letra++)
                {
                    caracteresMaiusculas.Add(letra);
                    caracteresMinusculas.Add(char.ToLower(letra));
                }

                for (int i = 0; i < 10; i++)
                {
                    nuns.Add(i.ToString());
                }
            }

            [HttpGet("Aleatoria")]
            public IActionResult SenhaAleatoria(int car)
            {
                if (car <= 0)
                {
                    return BadRequest("O número de caracteres deve ser maior que zero.");
                }

                Random random = new();
                string senha = "";

                for (int i = 0; i < car; i++)
                {
                    int escolhaCaracteresAleatorios = random.Next(0, 4); // 0 mai 1 min 2 num 3 especial
                    if (escolhaCaracteresAleatorios == 0)
                    {
                        senha += caracteresMaiusculas[random.Next(caracteresMaiusculas.Count)];
                    }
                    else if (escolhaCaracteresAleatorios == 1)
                    {
                        senha += caracteresMinusculas[random.Next(caracteresMinusculas.Count)];
                    }
                    else if (escolhaCaracteresAleatorios == 2)
                    {
                        senha += nuns[random.Next(nuns.Count)];
                    }
                    else if (escolhaCaracteresAleatorios == 3)
                    {
                        senha += especiais[random.Next(especiais.Count)];
                    }
                }

                return Ok(senha);
            }

            [HttpGet("SemEspeciais")]
            public IActionResult SenhaSemCaracteresEspeciais(int car)
            {
                if (car <= 0)
                {
                    return BadRequest("O número de caracteres deve ser maior que zero.");
                }

                Random random = new();
                string senhaSemCaracteres = "";
                for (int i = 0; i < car; i++)
                {
                    int escolhaCaracteresAleatorios = random.Next(0, 3); // 0 mai 1 min 2 num
                    if (escolhaCaracteresAleatorios == 0)
                    {
                        senhaSemCaracteres += caracteresMaiusculas[random.Next(caracteresMaiusculas.Count)];
                    }
                    else if (escolhaCaracteresAleatorios == 1)
                    {
                        senhaSemCaracteres += caracteresMinusculas[random.Next(caracteresMinusculas.Count)];
                    }
                    else
                    {
                        senhaSemCaracteres += nuns[random.Next(nuns.Count)];
                    }
                }

                return Ok(senhaSemCaracteres);
            }

            [HttpGet("SomenteMaiusculas")]
            public IActionResult SenhaSomenteMaiusculas(int car)
            {
                if (car <= 0)
                {
                    return BadRequest("O número de caracteres deve ser maior que zero.");
                }

                Random random = new();
                string senha = "";
                for (int i = 0; i < car; i++)
                {
                    senha += caracteresMaiusculas[random.Next(caracteresMaiusculas.Count)];
                }

                return Ok(senha);
            }

            [HttpGet("SomenteNumeros")]
            public IActionResult SenhaSomenteNumeros(int car)
            {
                if (car <= 0)
                {
                    return BadRequest("O número de caracteres deve ser maior que zero.");
                }

                Random random = new();
                string senha = "";
                for (int i = 0; i < car; i++)
                {
                    senha += nuns[random.Next(nuns.Count)];
                }
                return Ok(senha);
            }
        }
}
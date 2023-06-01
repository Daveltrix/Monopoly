using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace Monopoly
{
    public class WebServer
    {
        private readonly List<CPlayers> players;
        private readonly List<CBox> box;
        private readonly List<CPokemon> pokemon;
        private readonly HttpListener listener;
        private String URL = "http://localhost:8080/";

        public WebServer(Game_SetUp Setup)
        {
            this.players = Setup._LPlayers;
            this.box = Setup._LBoxes;
            this.pokemon = Setup._LPokemon;
            listener = new HttpListener();
        }

        public void Start()
        {
            listener.Prefixes.Add("http://localhost:8080/"); // Establece la URL base del servidor
            listener.Start();

            Console.WriteLine($"Servidor web iniciado: {URL}. Esperando conexiones...");

            Task.Run(async () =>
            {
                while (true)
                {
                    var context = await listener.GetContextAsync();
                    await ProcessRequest(context);
                }
            });
        }

        public void OpenWebBrowser(string url)
        {
            try
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to open web browser: {ex.Message}");
            }
        }

        private async Task ProcessRequest(HttpListenerContext context)
        {
            var request = context.Request;
            var response = context.Response;

            // Configura las cabeceras de respuesta
            response.ContentType = "application/json";
            response.Headers.Add("Access-Control-Allow-Origin", "*"); // Permite el acceso desde cualquier origen

            if (request.Url!.LocalPath == "/players")
            {
                var json = JsonConvert.SerializeObject(players);
                var buffer = Encoding.UTF8.GetBytes(json);

                // Envía la respuesta
                response.ContentLength64 = buffer.Length;
                await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
            }
            else if (request.Url!.LocalPath == "/box")
            {
                var json = JsonConvert.SerializeObject(box);
                var buffer = Encoding.UTF8.GetBytes(json);

                // Envía la respuesta
                response.ContentLength64 = buffer.Length;
                await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
            }
            else if (request.Url!.LocalPath == "/pokemon")
            {
                var json = JsonConvert.SerializeObject(pokemon);
                var buffer = Encoding.UTF8.GetBytes(json);

                // Envía la respuesta
                response.ContentLength64 = buffer.Length;
                await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
            }
            else
            {
                // Ruta desconocida, devuelve un error 404
                response.StatusCode = 404;
            }

            response.Close();
        }
    }
}

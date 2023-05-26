﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Monopoly
{
    public class WebServer
    {
        private readonly List<CPlayers> players;
        private readonly HttpListener listener;

        public WebServer(List<CPlayers> players)
        {
            this.players = players;
            listener = new HttpListener();
        }

        public void Start()
        {
            listener.Prefixes.Add("http://localhost:8080/"); // Establece la URL base del servidor
            listener.Start();

            Console.WriteLine("Servidor web iniciado. Esperando conexiones...");

            Task.Run(async () =>
            {
                while (true)
                {
                    var context = await listener.GetContextAsync();
                    await ProcessRequest(context);
                }
            });
        }

        private async Task ProcessRequest(HttpListenerContext context)
        {
            var request = context.Request;
            var response = context.Response;

            // Configura las cabeceras de respuesta
            response.ContentType = "application/json";
            response.Headers.Add("Access-Control-Allow-Origin", "*"); // Permite el acceso desde cualquier origen

            if (request.Url.LocalPath == "/players")
            {
                var json = JsonConvert.SerializeObject(players);
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
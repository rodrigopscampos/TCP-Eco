using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpEcho
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo ao TCP Echo");
            Console.Write("Informe uma porta: ");

            int porta = int.Parse(Console.ReadLine());

            var listener = new TcpListener(porta);
            listener.Start();

            Console.WriteLine("Aguardando conexão ...");

            var client = listener.AcceptTcpClient();

            Console.WriteLine("Conexão escabelecida ...");
            Console.WriteLine();

            var leitura = new StreamReader(client.GetStream());
            var escrita = new StreamWriter(client.GetStream());

            while (true)
            {
                string texto = leitura.ReadLine();

                if (!string.IsNullOrEmpty(texto))
                {
                    Console.WriteLine(texto);
                    escrita.WriteLine("ECHO - " + texto);
                    escrita.Flush();
                }
            }
        }
    }
}

using System;
using Atom.Auth.Sockets;
using Atom.DataCenter.Managers;
using Atom.DataCenter.Models.D2O.Servers;
using Atom.SerDes.Managers;

/// <summary>
/// Made by Nameless, thx to Dr.Brook
/// </summary>
namespace Atom.Auth
{
    class Program
    {
        static void Main(string[] args)
        {
            SerDesManager.GenerateExpressions();
            var auth = new AuthServer();

            D2OManager.Init();
            D2OManager.DisplayAll<Server>();

            Console.ReadKey();
        }
    }
}
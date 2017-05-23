using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Atom.Auth.Dependency;
using Atom.Auth.Sockets;
using Atom.DataCenter.D2O;
using Atom.DataCenter.Managers;
using Atom.DataCenter.Models.D2O.Servers;
using Atom.IO.Interfaces;
using Atom.IO.Reader;
using Atom.IO.Writer;
using Atom.Network.Sockets;
using Atom.Protocol.Messages.Connection;
using Atom.Protocol.Types.Connection;
using Atom.SerDes.Managers;

namespace Atom.Auth
{
    class Program
    {
        static void Main(string[] args)
        {
            SerDesManager.GenerateExpressions();
            var auth = new AuthServer();

            D2OManager.Init();

            //D2OManager.DisplayAll<Server>();

            Console.ReadKey();
        }
    }
}
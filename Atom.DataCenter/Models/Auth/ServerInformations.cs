using System;
using Atom.DataCenter.Models.D2O.Servers;

namespace Atom.DataCenter.Models.Auth
{
    [Serializable]
    public class ServerInformations
    {
        public Server Server { get; set; }
        public byte Type { get; set; }
        public byte Status { get; set; }
        public byte Completion { get; set; }
        public bool IsSelectable { get; set; }
    }
}

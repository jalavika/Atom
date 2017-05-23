using System;

namespace Atom.DataCenter.Models.D2O.Servers
{
    [Serializable]
    public class Server
    {
        public int Id { get; set; }
        public int NameId { get; set; }
        public int CommentId { get; set; }
        public double OpeningDate { get; set; }
        public string Language { get; set; }
        public int PopulationId { get; set; }
        public int GameTypeId { get; set; }
        public int CommunityId { get; set; }
        public string[] RestrictedToLanguages { get; set; }

        public override string ToString()
            => $"Server Id : {Id}, NameId : {NameId}, Language : {Language}";
    }
}

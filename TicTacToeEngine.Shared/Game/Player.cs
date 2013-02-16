using System.Runtime.Serialization;
using TicTacToeEngine.Utility;

namespace TicTacToeEngine.Game
{
    [DataContract]
    public class Player
    {
        public Player(string name, Sign playerSign)
        {
            this.Name = name;
            this.PlayerSign = playerSign;
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Sign PlayerSign { get; private set; }
    }
}
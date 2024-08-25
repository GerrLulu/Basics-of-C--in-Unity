using System;

namespace Geekbrains
{
    public sealed class GameDesignerException : Exception
    {
        public string TagPlayer { get; }
        public string TagLvlObject { get; }
        public GameDesignerException(string message, string tagPlayer, string tagLvlObject) : base(message)
        {
            TagPlayer = tagPlayer;
            TagLvlObject = tagLvlObject;
        }
    }
}
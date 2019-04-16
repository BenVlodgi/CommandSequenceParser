using System.Collections.Generic;

namespace CommandSequenceParser
{
    public class Sequence
    {
        protected char[] name = new char[128];
        public string Name
        {
            get { return name.CharArrayToString(); }
            set { name = value.ToFixedCharArray(128); }
        }

        public uint CommandCount { get { return (uint)(Commands?.Count ?? 0); } }
        
        public List<Command> Commands { get; } = new List<Command>();
    }
}

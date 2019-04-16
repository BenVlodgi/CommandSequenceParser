using System.Collections.Generic;

namespace CommandSequenceParser
{
    public class Header
    {
        public Header() { }
        
        protected char[] signature = new char[31];
        public string Signature
        {
            get { return signature.CharArrayToString(); }
            set { signature = value.ToFixedCharArray(31); }
        }

        public float Version { get; set; }

        public uint SequenceCount { get { return (uint)(Sequences?.Count ?? 0); } }

        public List<Sequence> Sequences { get; } = new List<Sequence>();
    }
}

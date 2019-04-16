namespace CommandSequenceParser
{
    public class Command
    {
        public bool IsEnabled { get; set; }

        public int Special { get; set; }
        
        protected char[] executable = new char[260];
        public string Executable
        {
            get { return executable.CharArrayToString(); }
            set { executable = value.ToFixedCharArray(260); }
        }
        
        protected char[] args = new char[260];
        public string Args
        {
            get { return args.CharArrayToString(); }
            set { args = value.ToFixedCharArray(260); }
        }
        
        // Obsolete, but always set to true. Disables MS-DOS 8-char filenames.
        public bool IsLongFilename { get; } = true;

        public bool EnsureCheck { get; set; }

        protected char[] ensureFile = new char[260];
        public string EnsureFile
        {
            get { return ensureFile.CharArrayToString(); }
            set { ensureFile = value.ToFixedCharArray(260); }
        }

        public bool UseProcessWindow { get; set; }

        public bool Wait { get; set; }
    }
}

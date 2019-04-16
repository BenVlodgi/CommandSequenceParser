using System.IO;

namespace CommandSequenceParser
{
    public class CommandSequenceFile
    {
        protected bool IsCSGO { get; set; }
        Header Header { get; set; }

        public CommandSequenceFile() { }
        
        public CommandSequenceFile(string filePath, bool isCSGO = false)
        {
            IsCSGO = isCSGO;

            using (BinaryReader binReader = new BinaryReader(File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                #region Load Header
                
                Header = new Header()
                {
                    Signature = binReader.ReadChars(31).CharArrayToString(),
                    Version = binReader.ReadSingle(),
                };

                #endregion

                #region Load Sequences & and sub-commands
                uint sequenceCount = binReader.ReadUInt32();
                for (int sequenceIterator = 0; sequenceIterator < sequenceCount; sequenceIterator++)
                {
                    var sequence = new Sequence()
                    {
                        //Name = binReader.ReadChars(128).CharArrayToString(),
                        Name = binReader.ReadASCIIString(128),
                    };
                    Header.Sequences.Add(sequence);

                    #region Load Commands
                    uint commandCount = binReader.ReadUInt32();
                    for (int commandIterator = 0; commandIterator < commandCount; commandIterator++)
                    {
                        var command = new Command();
                        sequence.Commands.Add(command);

                        if (IsCSGO) {
                            int commandIsEnabledInt = binReader.ReadInt32();
                            command.IsEnabled = commandIsEnabledInt == 1; }
                        else {
                            char commandIsEnabledChar = binReader.ReadChar();
                            command.IsEnabled = commandIsEnabledChar == '1'; }

                        command.Special = binReader.ReadInt32();
                        command.Executable = binReader.ReadChars(260).CharArrayToString();
                        command.Args = binReader.ReadChars(260).CharArrayToString();

                        //command.IsLongFilename = true; // Hardcoded. Disables MS-DOS 8-char filenames.
                        var commandLongFile = binReader.ReadInt32(); //do this read to move forward

                        command.EnsureCheck = binReader.ReadInt32() == 1;
                        command.EnsureFile = binReader.ReadChars(260).CharArrayToString();
                        command.UseProcessWindow = binReader.ReadInt32() == 1;

                        command.Wait = binReader.ReadInt32() == 1;
                    }
                    #endregion
                }
                #endregion

            }
        }
    }
}

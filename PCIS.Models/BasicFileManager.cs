// <copyright file="BasicFileManager.cs" company="LNU">
// All rights reserved.
// </copyright>
// <author>Roman Mulyk</author>

namespace PCIS.Models
{
    using System.IO;
    using Interfaces;

    /// <summary>
    /// Basic file manager
    /// </summary>
    public partial class BasicFileManager : IFileManager
    {
        /// <summary>
        /// Sync root for reader
        /// </summary>
        private static object syncRootRead = new object();

        /// <summary>
        /// Sync root for writer
        /// </summary>
        private static object syncRootWrite = new object();
        
        /// <summary>
        /// Reader instance
        /// </summary>
        private readonly StreamReader reader;

        /// <summary>
        /// Writer instance
        /// </summary>
        private readonly StreamWriter writer;
        
        #region Constructors & Finalizers

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicFileManager"/> class
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <param name="type">Operations type</param>
        public BasicFileManager(string path, IOType type)
        {
            if (type == IOType.Reader)
            {
                this.reader = new StreamReader(path);
            }
            else
            {
                this.writer = new StreamWriter(path, true);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicFileManager"/> class
        /// </summary>
        /// <param name="readPath">File for read operations</param>
        /// <param name="writePath">File for write operations</param>
        public BasicFileManager(string readPath, string writePath)
        {
            this.reader = new StreamReader(readPath);
            this.writer = new StreamWriter(writePath);
        }
        
        #endregion

        /// <summary>
        /// Operation type
        /// </summary>
        public enum IOType
        {
            /// <summary>
            /// Read operations
            /// </summary>
            Reader,

            /// <summary>
            /// Write operations
            /// </summary>
            Writer
        }

        #region IO Operations

        /// <summary>
        /// Reads line from file
        /// </summary>
        /// <returns>Line from file (string)</returns>
        public string ReadLine()
        {
            lock (syncRootRead)
            {
                return this.reader.ReadLine();
            }
        }

        /// <summary>
        /// Writes a new line to file
        /// </summary>
        /// <param name="text">Text to write</param>
        public void WriteLine(string text)
        {
            lock (syncRootWrite)
            {
                this.writer.WriteLine(text);
                this.writer.Flush();
            }
        }

        #endregion
    }
}

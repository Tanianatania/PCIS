// <copyright file="IFileManager.cs" company="LNU">
// All rights reserved.
// </copyright>
// <author>Roman Mulyk</author>

namespace PCIS.Models.Interfaces
{
    /// <summary>
    /// Interface for IO operations with file
    /// </summary>
    public interface IFileManager
    {
        /// <summary>
        /// Reads line from the file and returns it
        /// </summary>
        /// <returns>Line that was read</returns>
        string ReadLine();

        /// <summary>
        /// Writes line to file
        /// </summary>
        /// <param name="text">Text to be written</param>
        void WriteLine(string text);
    }
}

// <copyright file="BasicFileManagerIDisposable.cs" company="LNU">
// All rights reserved.
// </copyright>
// <author>Roman Mulyk</author>

namespace PCIS.Models
{
    using System;

    /// <summary>
    /// Basic file manager
    /// </summary>
    public partial class BasicFileManager : IDisposable
    {
        /// <summary>
        /// To detect redundant calls
        /// </summary>
        private bool disposedValue = false;

        /// <summary>
        /// Finalizes an instance of the <see cref="BasicFileManager"/> class
        /// </summary>
        ~BasicFileManager()
        {
            this.Dispose(false);
        }

        #region IDisposable Support

        /// <summary>
        /// Disposes resources
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes resources
        /// </summary>
        /// <param name="disposing">Disposing value</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    this.reader?.Dispose();
                    this.writer?.Dispose();
                }

                this.disposedValue = true;
            }
        }

        #endregion
    }
}

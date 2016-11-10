using System;

namespace CF.Data
{
    /// <summary>
    /// The disposable class implements the IDisposable interface
    /// </summary>
    public class Disposable : IDisposable
    {
        private bool _isDisposed;

        /// <summary>
        /// Finalizes an instance of the <see cref="Disposable"/> class.
        /// </summary>
        ~Disposable()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Safes the dispose.
        /// </summary>
        /// <param name="disposableObject">The disposable object.</param>
        public static void SafeDispose(IDisposable disposableObject)
        {
            if (disposableObject != null)
            {
                disposableObject.Dispose();
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources. See MSDN: "Implementing a Dispose Method"        
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);

            // Use SupressFinalize in case a subclass of this type implements a finalizer.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the core.
        /// </summary>
        protected virtual void DisposeCore()
        {
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(bool disposing)
        {
            if (!this._isDisposed && disposing)
            {
                this.DisposeCore();
            }

            this._isDisposed = true;
        }
    }
}

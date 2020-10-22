using f21sc_courswork_1.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Utils
{
    /// <summary>
    /// Will serialize or deserialize data of type <see cref="T"/> to the filesystem
    /// </summary>
    /// <typeparam name="T">Type of what has to be backed up</typeparam>
    class Backedup<T>
    {
        /// <summary>
        /// Target to back up / read from filesystem
        /// </summary>
        public T Target { get; private set; }

        /// <summary>
        /// Filename of the backup
        /// </summary>
        private string filename;

        /// <summary>
        /// Semaphore to prevent concurrent access of the backup file
        /// </summary>
        private Semaphore fileAccessSemaphore;

        /// <summary>
        /// Formatter of the file
        /// </summary>
        private IFormatter formatter;

        public Backedup(T target, string filename, IFormatter formatter)
        {
            this.Target = target;
            this.filename = filename;
            this.formatter = formatter;

            this.fileAccessSemaphore = new Semaphore(1, 1);
        }


        /// <summary>
        /// Writes <see cref="Target"/> to the filesystem
        /// </summary>
        public void Write()
        {
            this.fileAccessSemaphore.WaitOne();

            try
            {
                FileStream stream = new FileStream(this.filename, FileMode.Create);
                this.formatter.Serialize(stream, this.Target);
                Logger.Info("Backed up " + this.filename);
            }
            catch (IOException e)
            {
                Logger.Error(e.Message);
                throw new BackerException("Could not write " + this.filename, e);
            }
            finally
            {
                this.fileAccessSemaphore.Release();
            }
        }

        /// <summary>
        /// Reads <see cref="Target"/> from the filesystem
        /// </summary>
        public void Read()
        {
            this.fileAccessSemaphore.WaitOne();

            try
            {
                FileStream stream = new FileStream(this.filename, FileMode.OpenOrCreate);
                this.Target = stream.Length != 0 ? (T)this.formatter.Deserialize(stream) : Target;
                Logger.Info("Read " + this.filename);
            }
            catch (IOException e)
            {

                Logger.Error(e.Message);
                throw new BackerException("Could not write " + this.filename, e);
            }
            finally
            {
                this.fileAccessSemaphore.Release();
            }
        }
    }
}

using f21sc_coursework_1.Utils.Exceptions;
using System.IO;
using System.Runtime.Serialization;
using System.Threading;

namespace f21sc_coursework_1.Utils
{
    /// <summary>
    /// Will serialize or deserialize data of type <see cref="T"/> to the filesystem
    /// </summary>
    /// <typeparam name="T">Type of what has to be backed up</typeparam>
    class Backer<T>
    {
        /// <summary>
        /// Target to back up / read from filesystem
        /// </summary>
        public T Target { get; private set; }

        /// <summary>
        /// Filename of the backup
        /// </summary>
        private readonly string filename;

        /// <summary>
        /// Semaphore to prevent concurrent access of the backup file
        /// </summary>
        private readonly Semaphore fileAccessSemaphore;

        /// <summary>
        /// Formatter of the file
        /// </summary>
        private readonly IFormatter formatter;

        public Backer(T target, IFormatter formatter)
        {
            this.Target = target;
            this.filename = this.Target.GetType().Name + ".data";
            this.formatter = formatter;

            this.fileAccessSemaphore = new Semaphore(1, 1);

            this.Read();
        }


        /// <summary>
        /// Writes <see cref="Target"/> to the filesystem
        /// </summary>
        /// <exception cref="BackerException">When a problem occurs</exception>
        public void Write()
        {
            this.fileAccessSemaphore.WaitOne();

            try
            {
                FileStream stream = new FileStream(this.filename, FileMode.Create);
                this.formatter.Serialize(stream, this.Target);
                stream.Close();
            }
            catch (IOException e)
            {
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
        /// <exception cref="BackerException">When a problem occurs</exception>
        public void Read()
        {
            this.fileAccessSemaphore.WaitOne();

            try
            {
                FileStream stream = new FileStream(this.filename, FileMode.OpenOrCreate);
                this.Target = stream.Length != 0 ? (T)this.formatter.Deserialize(stream) : Target;
                stream.Close();
            }
            catch (IOException e)
            {
                throw new BackerException("Could not write " + this.filename, e);
            }
            finally
            {
                this.fileAccessSemaphore.Release();
            }
        }
    }
}

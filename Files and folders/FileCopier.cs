using System;
using System.IO;

namespace Norbit.Crm.Hodeshenas.TaskTen
{
    /// <summary>
    /// Побайтовое копирование.
    /// </summary>
    public class FileCopier
    {
        #region События

        /// <summary>
        /// Начало копирования.
        /// </summary>
        public event EventHandler CopyStart;

        /// <summary>
        /// Прогресс в процентах.
        /// </summary>
        public event EventHandler<int> CopyInProgress;

        /// <summary>
        /// Конец копирования.
        /// </summary>
        public event EventHandler CopyFinish;

        /// <summary>
        /// Вызов события CopyStart.
        /// </summary>
        protected virtual void OnCopyStart()
        {
            CopyStart?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Вызов события CopyInProgress.
        /// </summary>
        /// <param name="progress">Прогресс</param>
        protected virtual void OnCopyInProgress(int progress)
        {
            CopyInProgress?.Invoke(this, progress);
        }

        /// <summary>
        /// Вызов события CopyFinish.
        /// </summary>
        protected virtual void OnCopyFinished()
        {
            CopyFinish?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Методы

        /// <summary>
        /// Проверка на наличие пути к файлу и размера блока.
        /// </summary>
        /// <param name="source">Путь копируемого файла</param>
        /// <param name="destination">Путь конечного файла</param>
        /// <param name="blockSize">Размер блока</param>
        void ParameterCheck(string source, string destination, int blockSize)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentException("Не задан путь копируемого файла");
            }
            if (string.IsNullOrEmpty(destination))
            {
                throw new ArgumentException("Не задан путь конечного файла");
            }
            if (blockSize < 1)
            {
                throw new ArgumentException("Размер блока не может быть отрицательным или равен 0!");
            }
        }

        /// <summary>
        /// Побайтовое копирование данных.
        /// </summary>
        /// <param name="source">Путь копируемого файда</param>
        /// <param name="destination">Путь конечного файла</param>
        /// <param name="blockSize">Размер блока</param>
        public void Copy(string source, string destination, int blockSize)
        {
            ParameterCheck(source, destination, blockSize);

            using (var sourceFile = new FileStream(source, FileMode.Open))
            {
                using (var objectiveFile = new FileStream(destination, FileMode.Create))
                {
                    OnCopyStart();

                    var readBlock = new byte[blockSize];
                    var sourceFileLength = sourceFile.Length;
                    var iteration = 0;
                    var bytesRead = 0;

                    while (sourceFile.Position < sourceFile.Length)
                    {
                        bytesRead = sourceFile.Read(readBlock, 0, blockSize);
                        objectiveFile.Write(readBlock, 0, bytesRead);

                        iteration++;

                        OnCopyInProgress((int)(sourceFile.Position * 100 / sourceFileLength));
                    }
                }
            }

            OnCopyFinished();
        }

        #endregion
    }
}

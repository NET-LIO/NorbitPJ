using System;

namespace Norbit.Crm.Hodeshenas.TaskNine
{
    /// <summary>
    /// Вызывает исключение DivideByZeroException.
    /// </summary>
    internal class ExceptionDivideByZero
    {
        /// <summary>
        /// На что будем делить.
        /// </summary>
        private int x = 0;

        /// <summary>
        /// Вызывает исключение.
        /// </summary>
        /// <param name="y">Входной параметр</param>
        public void ThrowException(int y)
        {
            try
            {
                int getException = y / x;
            }
            catch(DivideByZeroException e)
            {
                throw new DivideByZeroException("На 0 делить нельзя!", e);
            }
        }
    }
}

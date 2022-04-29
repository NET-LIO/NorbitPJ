using System;

namespace Norbit.Crm.Hodeshenas.FinalTaskCS
{
    /// <summary>
    /// Сделка.
    /// </summary>
    public class Trade
    {
        /// <summary>
        /// Сумма сделки.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Дата сделки.
        /// </summary>
        public DateTime Created { get; set; }

        public override string ToString()
        {
            return $"Дата сделки - {Created.ToLocalTime()} Сумма - {Amount}.\n";
        }
    }
}
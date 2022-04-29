using System;

namespace Norbit.Crm.Hodeshenas.TaskEight
{
    /// <summary>
    /// Cостояние машины.
    /// </summary>
    interface ICondition
    {
        #region Свойства

        /// <summary>
        /// Перед началом использования машины.
        /// </summary>
        string StartEngine();

        #endregion
    }
}

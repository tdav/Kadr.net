namespace Kadr.Models.Utils
{
    public enum СonditionsSearchEnum
    {
        /// <summary>
        /// =
        /// </summary>
        csEqually,

        /// <summary>
        /// Like
        /// </summary>
        csLike,

        /// <summary>
        /// Between 1 and 100
        /// </summary>
        csBetween,

        /// <summary>
        /// >=
        /// </summary>
        csGreaterEqual,

        /// <summary>
        /// <=
        /// </summary>
        csLessEqual,

        /// <summary>
        /// in (1,2,3)
        /// </summary>
        csIn,

        /// <summary>
        /// not in (1,2,3)
        /// </summary>
        csNotIn,

        /// <summary>
        /// is null
        /// </summary>
        csIsNull,

        /// <summary>
        /// is not null
        /// </summary>
        csInNotNull,

        /// <summary>
        /// Order By
        /// </summary>
        csOrderBy,

        /// <summary>
        /// FetchTop
        /// </summary>
        csFetchTop
    }
}

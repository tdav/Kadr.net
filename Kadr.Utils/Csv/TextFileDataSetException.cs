using System;

namespace Apteka.Utils.DataBase
{
	/// <summary>
	/// Special exception for TextFileDataSet
	/// </summary>
    public class TextFileDataSetException:ApplicationException
    {  
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="message">Message for this exception</param>
        public TextFileDataSetException(string message):base(message){}
    }
}

using System;
using System.Linq;

namespace DashAgil.Email.Infra.Helper
{
    /// <summary>
    /// The utilities class.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// The parse string to guid.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Guid? ParseToGuid(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                var array = s.Split('-').ToList();

                array.RemoveAt(0);
                array.RemoveAt(array.Count - 1);

                var fullString = string.Join(string.Empty, array);

                return new Guid(fullString);
            }
            return null;
        }
    }
}

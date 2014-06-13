using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraduationPlanningSystem
{
    //static class used to parse the list of classes in a prereq/coreqp/precoreq field
    //author: ??
    static class ParseGPS
    {
        /// <summary>
        /// Parses for reqs.
        /// </summary>
        /// <param name="reqs"></param>
        /// <returns></returns>
        public static List<String> parseReqs(String reqs)
        {
            char[] temp = reqs.ToCharArray();
            List<String> outReqs = new List<String>();
            int start = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i]==',')
                {
                    outReqs.Add(reqs.Substring(start, i - start));
                    start = i + 1;
                    if (temp[start]==' ')     // this should be the normal case where the form is "course, course, ..."
                    {                                // other case is for a common mistake in entry where space isn't entered
                        start++;
                        i += 2;
                    }
                }
            }
            outReqs.Add(reqs.Substring(start, temp.Length - start));   // adds last requirement


            return (outReqs);
        }
    }
}

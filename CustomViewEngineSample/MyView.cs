using System.IO;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace CustomViewEngineSample
{
    public class MyView : IView
    {
        private string _viewPhysicalPath;

        public MyView(string ViewPhysicalPath)
        {
            _viewPhysicalPath = ViewPhysicalPath;
        }

        #region IView Members

        public void Render(ViewContext viewContext, System.IO.TextWriter writer)
        {
            //Load File
            string rawcontents = File.ReadAllText(_viewPhysicalPath);

            //Perform Replacements
            string parsedcontents = Parse(rawcontents, viewContext.ViewData);

            writer.Write(parsedcontents);
        }

        #endregion

        public string Parse(string contents, ViewDataDictionary viewdata)
        {
            return Regex.Replace(contents, "\\{(.+)\\}", m => GetMatch(m, viewdata));
        }

        public virtual string GetMatch(Match m, ViewDataDictionary viewdata)
        {
            if (m.Success)
            {
                string key = m.Result("$1");
                if (viewdata.ContainsKey(key))
                {
                    return viewdata[key].ToString();
                }
            }
            return string.Empty;
        }
    }
}
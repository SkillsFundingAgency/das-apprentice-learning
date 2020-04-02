using Microsoft.AspNetCore.Html;
using Newtonsoft.Json;
using System.IO;

namespace DAS_Capture_The_Flag.ViewModels
{
    public static class JavaScriptConvert
    {
        public static HtmlString SerializeObject(object value)
        {
            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var serializer = new JsonSerializer();

                jsonWriter.QuoteName = false;
                serializer.Serialize(jsonWriter, value);

                return new HtmlString(stringWriter.ToString());
            }
        }
    }
}

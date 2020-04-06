using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Html;

namespace DAS_Capture_The_Flag.Application.Helpers
{
    public static class JavascriptConvert
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

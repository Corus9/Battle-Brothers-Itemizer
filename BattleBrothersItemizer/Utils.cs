using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace BattleBrothersItemizer
{
    public static class Utils
    {
        public static string StripNullableEmptyXmlElements(this string input, bool compactOutput = false)
        {
            const RegexOptions OPTIONS =
            RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline;

            var result = Regex.Replace(
                input,
                @"<\w+\s+\w+:nil=""true""(\s+xmlns:\w+=""http://www.w3.org/2001/XMLSchema-instance"")?\s*/>",
                string.Empty,
                OPTIONS
            );

            if (compactOutput)
            {
                var sb = new StringBuilder();

                using (var sr = new StringReader(result))
                {
                    string ln;

                    while ((ln = sr.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(ln))
                        {
                            sb.AppendLine(ln);
                        }
                    }
                }

                result = sb.ToString();
            }

            result = XDocument.Parse(result).ToString();

            return result;
        }

        public static string SerializeXml(Object obj)
        {
            var xser = new XmlSerializer(obj.GetType());
            var sb = new StringBuilder();

            using (var sw = new StringWriter(sb))
            {
                using (var xtw = new XmlTextWriter(sw))
                {
                    xser.Serialize(xtw, obj);
                }
            }
            
            return sb.ToString().StripNullableEmptyXmlElements();
        }

        public static int? ToNullableInt(this string? s)
        {
            int i;
            if (s == null) return null;
            if (int.TryParse(s, out i)) return i;
            return null;
        }

        public static string? NullableValue(this XAttribute xAttribute)
        {
            if (xAttribute == null) return null;
            else
                return xAttribute.Value;
        }
    }
}

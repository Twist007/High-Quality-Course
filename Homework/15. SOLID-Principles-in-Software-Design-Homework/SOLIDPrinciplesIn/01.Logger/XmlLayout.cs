namespace _01.Logger
{
    using System;
    using System.Text;
    using Enumerations;
    using Interfaces;

    public class XmlLayout : ILayout
    {
        public string PrintingFormat(DateTime dateTime, ReportLevel reportLevel, string message)
        {
            var result = new StringBuilder();
            result.AppendLine("<log>");
            result.Append("\n\t");
            result.AppendLine(string.Format("<date>{0}<\\date>", dateTime));
            result.Append("\n\t");
            result.AppendLine(string.Format("<level>{0}<\\level>", reportLevel));
            result.Append("\n\t");
            result.AppendLine(string.Format("<message>{0}<\\message>", message));
            return result.ToString();
        }
    }
}
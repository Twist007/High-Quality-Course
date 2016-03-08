namespace _01.Logger.Models
{
    using System;
    using System.IO;
    using Enumerations;
    using Interfaces;

    public class FileAppender:IAppender
    {
        private string filePath;

        public FileAppender(ILayout layout)
        {
            this.Layout = layout;
            this.ReportLevel = ReportLevel.Info;
        }

        public string FilePath
        {
            get { return this.filePath; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value),"File name cannot be null or whitespace");
                }
                this.filePath = value;
            }
        }

        public ILayout Layout { get; private set; }

        public ReportLevel ReportLevel { get; set; }

        public void Append(DateTime dateTime, ReportLevel reportLevel, string message)
        {
            string formattedOutput = this.Layout.PrintingFormat(dateTime, reportLevel, message);

            File.AppendAllText(this.FilePath, formattedOutput);
        }
    }
}
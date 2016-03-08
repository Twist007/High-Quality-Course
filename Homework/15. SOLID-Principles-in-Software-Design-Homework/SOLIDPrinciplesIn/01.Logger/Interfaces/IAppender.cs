namespace _01.Logger.Interfaces
{
    using System;
    using Enumerations;

    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }

        void Append(DateTime dateTime, ReportLevel reportLevel, string message);
    }
}

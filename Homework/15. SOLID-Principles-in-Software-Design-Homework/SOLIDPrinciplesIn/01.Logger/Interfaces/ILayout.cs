namespace _01.Logger.Interfaces
{
    using System;
    using Enumerations;

    public interface ILayout
    {
        string PrintingFormat(DateTime dateTime, ReportLevel reportLevel, string message);
    }
}
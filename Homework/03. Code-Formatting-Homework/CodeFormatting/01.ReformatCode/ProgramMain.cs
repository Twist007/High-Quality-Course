// <copyright file="ProgramMain.cs" company="MyCompany.com">
//     MyCompany.com. All rights reserved.
// </copyright>
// <author>Me</author>
namespace _01.ReformatCode
{
    using System;

    /// <summary>
    /// Documentation for class ProgramMain.
    /// </summary>
    public class ProgramMain
    {
        /// <summary>
        /// Documentation for method Main.
        /// </summary>
        public static void Main()
        {
            while (EventsProgram.ExecuteNextCommand())
            {
            }

            Console.WriteLine(EventsProgram.Output);
        }
    }
}
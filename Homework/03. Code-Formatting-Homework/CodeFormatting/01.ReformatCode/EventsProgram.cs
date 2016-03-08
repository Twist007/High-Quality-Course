// <copyright file="EventsProgram.cs" company="MyCompany.com">
//     MyCompany.com. All rights reserved.
// </copyright>
// <author>Me</author>
namespace _01.ReformatCode
{
    using System;
    using System.Text;

    /// <summary>
    /// Documentation for class EventsProgram.
    /// </summary>
    public class EventsProgram
    {
        /// <summary>
        /// Documentation for field Output.
        /// </summary>
        public static readonly StringBuilder Output = new StringBuilder();

        /// <summary>
        /// Documentation for field Events.
        /// </summary>
        private static readonly EventHolder Events = new EventHolder();

        /// <summary>
        /// Documentation for method ExecuteNextCommand.
        /// </summary>
        /// <returns>New command.</returns>
        public static bool ExecuteNextCommand()
        {
            string command = Console.ReadLine();
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            if (command[0] == 'A')
            {
                AddEvent(command);
                return true;
            }

            if (command[0] == 'D')
            {
                DeleteEvents(command);
                return true;
            }

            if (command[0] == 'L')
            {
                ListEvents(command);
                return true;
            }

            if (command[0] == 'E')
            {
                return false;
            }

            return false;
        }

        /// <summary>
        /// Documentation for method AddEvent.
        /// </summary>
        /// <param name="command">Command list of events.</param>
        private static void ListEvents(string command)
        {
            int pipeIndex = command.IndexOf('|');
            DateTime date = GetDate(command, "ListEvents");
            string countString = command.Substring(pipeIndex + 1);

            int count = int.Parse(countString);
            Events.ListEvents(date, count);
        }

        /// <summary>
        /// Documentation for method AddEvent.
        /// </summary>
        /// <param name="command">Delete events by title.</param>
        private static void DeleteEvents(string command)
        {
            string title = command.Substring("DeleteEvents".Length + 1);
            Events.DeleteEvents(title);
        }

        /// <summary>
        /// Documentation for method AddEvent.
        /// </summary>
        /// <param name="command">Add events.</param>
        private static void AddEvent(string command)
        {
            DateTime date;
            string title;
            string location;
            GetParameters(command, "AddEvent", out date, out title, out location);

            Events.AddEvent(date, title, location);
        }

        /// <summary>
        /// Documentation for method GetParameters.
        /// </summary>
        /// <param name="commandForExecution">Command for execution.</param>
        /// <param name="commandType">Command type.</param>
        /// <param name="dateAndTime">Date and time.</param>
        /// <param name="eventTitle">Title of event.</param>
        /// <param name="eventLocation">Location of event.</param>
        private static void GetParameters(
            string commandForExecution,
            string commandType,
            out DateTime dateAndTime,
            out string eventTitle,
            out string eventLocation)
        {
            dateAndTime = GetDate(commandForExecution, commandType);

            int firstPipeIndex = commandForExecution.IndexOf('|');
            int lastPipeIndex = commandForExecution.LastIndexOf('|');

            if (firstPipeIndex == lastPipeIndex)
            {
                eventTitle = commandForExecution.Substring(firstPipeIndex + 1).Trim();
                eventLocation = string.Empty;
            }
            else
            {
                eventTitle = commandForExecution.Substring(firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();
                eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
            }
        }

        /// <summary>
        /// Documentation for method GetDate.
        /// </summary>
        /// <param name="command">Command for date.</param>
        /// <param name="commandType">Command type.</param>
        /// <returns>Data of event.</returns>
        private static DateTime GetDate(string command, string commandType)
        {
            DateTime date = DateTime.Parse(command.Substring(commandType.Length + 1, 20));
            return date;
        }
    }
}
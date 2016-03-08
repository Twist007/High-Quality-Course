// <copyright file="Message.cs" company="MyCompany.com">
//     MyCompany.com. All rights reserved.
// </copyright>
// <author>Me</author>
namespace _01.ReformatCode
{
    /// <summary>
    /// Documentation for class Message.
    /// </summary>
    public static class Message
    {
        /// <summary>
        /// Documentation for method EventAdded.
        /// </summary>
        public static void EventAdded()
        {
            EventsProgram.Output.Append("Event added\n");
        }

        /// <summary>
        /// Documentation for method EventDeleted.
        /// </summary>
        /// <param name="eventNumber">Number of events.</param>
        public static void EventDeleted(int eventNumber)
        {
            if (eventNumber == 0)
            {
                NoEventsFound();
            }
            else
            {
                EventsProgram.Output.AppendFormat("{0} events deleted\n", eventNumber);
            }
        }

        /// <summary>
        /// Documentation for method NoEventsFound.
        /// </summary>
        public static void NoEventsFound()
        {
            EventsProgram.Output.Append("No events found\n");
        }

        /// <summary>
        /// Documentation for method PrintEvent.
        /// </summary>
        /// <param name="eventToPrint">Event to print.</param>
        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                EventsProgram.Output.Append(eventToPrint + "\n");
            }
        }
    }
}
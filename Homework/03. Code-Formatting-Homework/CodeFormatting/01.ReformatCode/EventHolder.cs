// <copyright file="EventHolder.cs" company="MyCompany.com">
//     MyCompany.com. All rights reserved.
// </copyright>
// <author>Me</author>
namespace _01.ReformatCode
{
    using System;
    using Wintellect.PowerCollections;

    /// <summary>
    /// Documentation for class EventHolder.
    /// </summary>
    internal class EventHolder
    {
        /// <summary>
        /// Documentation for field byTitle.
        /// </summary>
        private readonly MultiDictionary<string, Event> byTitle = new MultiDictionary<string, Event>(true);

        /// <summary>
        /// Documentation for field byDate.
        /// </summary>
        private readonly OrderedBag<Event> byDate = new OrderedBag<Event>();

        /// <summary>
        /// Documentation for method AddEvent.
        /// </summary>
        /// <param name="date">Date of added event.</param>
        /// <param name="title">Title of added event.</param>
        /// <param name="location">Location of added event.</param>
        public void AddEvent(DateTime date, string title, string location)
        {
            Event newEvent = new Event(date, title, location);
           this.byTitle.Add(title.ToLower(), newEvent);
           this.byDate.Add(newEvent);
            Message.EventAdded();
        }

        /// <summary>
        /// Documentation for method DeleteEvents.
        /// </summary>
        /// <param name="titleToDelete">Title of event to delete.</param>
        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int removed = 0;

            foreach (Event eventToRemove in this.byTitle[title])
            {
                removed++;
                this.byDate.Remove(eventToRemove);
            }

            this.byTitle.Remove(title);
            Message.EventDeleted(removed);
        }

        /// <summary>
        /// Documentation for method DeleteEvents.
        /// </summary>
        /// <param name="date">Date of the event .</param>
        /// <param name="count">Count of the event.</param>
        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View eventsToShow = this.byDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);
            int showed = 0;

            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }

                Message.PrintEvent(eventToShow);
                showed++;
            }

            if (showed == 0)
            {
                Message.NoEventsFound();
            }
        }
    }
}
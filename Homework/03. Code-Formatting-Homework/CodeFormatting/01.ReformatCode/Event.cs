// <copyright file="Event.cs" company="MyCompany.com">
//     MyCompany.com. All rights reserved.
// </copyright>
// <author>Me</author>
namespace _01.ReformatCode
{
    using System;
    using System.Text;

    /// <summary>
    /// Documentation for class Event.
    /// </summary>
    public class Event : IComparable
    {
        /// <summary>
        /// Documentation for field date.
        /// </summary>
        private readonly DateTime date;

        /// <summary>
        /// Documentation for field title.
        /// </summary>
        private readonly string title;

        /// <summary>
        /// Documentation for field location.
        /// </summary>
        private readonly string location;

        /// <summary>
        /// Initializes a new instance of the <see cref="Event"/> class.
        /// </summary>
        /// <param name="date">The date of the event.</param>
        /// <param name="title">The title of the event .</param>
        /// <param name="location">The location of the event.</param>
        public Event(DateTime date, string title, string location)
        {
            this.date = date;
            this.title = title;
            this.location = location;
        }

        /// <summary>
        /// Documentation for method CompareTo.
        /// </summary>
        /// <param name="objectToCompare">Object to compare.</param>
        /// <returns>Compare by date, title or location.</returns>
        public int CompareTo(object objectToCompare)
        {
            Event otherObject = objectToCompare as Event;

            int byDate = this.date.CompareTo(otherObject.date);
            int byTitle = string.Compare(this.title, otherObject.title, StringComparison.Ordinal);
            int byLocation = string.Compare(this.location, otherObject.location, StringComparison.Ordinal);

            if (byDate == 0)
            {
                if (byTitle == 0)
                {
                    return byLocation;
                }

                return byTitle;
            }

            return byDate;
        }

        /// <summary>
        /// Documentation for override method ToString.
        /// </summary>
        /// <returns>String format of events.</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
            stringBuilder.Append(" | " + this.title);

            if (!string.IsNullOrEmpty(this.location))
            {
                stringBuilder.Append(" | " + this.location);
            }

            return stringBuilder.ToString();
        }
    }
}
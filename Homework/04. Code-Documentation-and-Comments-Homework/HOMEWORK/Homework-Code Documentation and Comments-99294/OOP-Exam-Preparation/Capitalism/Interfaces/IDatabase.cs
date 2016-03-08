using Capitalism.Models;
using Capitalism.Models.Interfaces;
using System.Collections.Generic;

namespace Capitalism.Interfaces
{
    /// <summary>
    /// Holds created companies and the salaries of all employees
    /// </summary>
    public interface IDatabase
    {
        ICollection<Company> Companies { get; }

        IDictionary<IPaidPerson, decimal> TotalSalaries { get; }
    }
}

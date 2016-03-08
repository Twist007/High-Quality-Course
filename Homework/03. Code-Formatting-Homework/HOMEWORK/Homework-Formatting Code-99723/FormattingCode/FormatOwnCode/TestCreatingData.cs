using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddleTierTest
{
    using System;
    using System.Data;
    using System.Data.SQL;
    using System.Diagnostics;
    using MiddleTier;

    public static
    void TestCreatingData(int NumberOfEmployees,
                                       int NumberOfDependents)
    {
        Console.
        WriteLine("Creating " + NumberOfEmployees.ToString() +

                             " employees each with " + NumberOfDependents.ToString() +
                             " dependents");

        Employees Emps = new Employees();
        Emps.LoadEmpty(RWMode.Write, ObjectCreation.Unique);

        for (int i = 0;
         i < NumberOfEmployees; i++)
        {
            Employee Emp = Emps.AddNew();

            string iprefix = i.ToString();

            Emp.FirstName = iprefix + " FirstName";
            Emp.LastName = iprefix + " LastName";
            Emp.City = iprefix + " Redmond";
            Emp.State = "WA";
            Emp.Zip = iprefix + " ZIP";

            Dependents Deps = Emp.Dependents;

            for (int j = 0; j < NumberOfDependents;
             j++)
            {
                Dependent Dep = Deps.AddNew();

                string jprefix = j.ToString();

                Dep.EmployeeID = Emp.EmployeeID;
                Dep.FirstName = iprefix + jprefix + " FirstName";
                Dep.LastName = iprefix + jprefix + " LastName";
                Dep.Age = j;
            }
        }

        Emps.SaveAll();

        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("Don't forget to comment out TestCreatingData()");
        Console.WriteLine("Your Test Data has been created now.          ");
        Console.WriteLine("----------------------------------------------");
    }

    public static void TimeFunction(TestRoutine func,
                                     RWMode Mode,
                                     ObjectCreation ObjCreate,
                                     string EmpID,
                                     int Iterations)
    {
        GarbageCollect();

        double min = 500000.0d;
        int bMem;

        for (int i = 0; i < Iterations; i++)
        {
            start = Counter.Value;

            // Call the TestRoutine
            func(Mode, ObjCreate, EmpID);

            end = Counter.Value;

            totaltime += delta = end - start;
            double result = (double)delta / Counter.Frequency;

            if (result < min)
            {
                min = result;
            }

            if (result > max)
            {
                max = result;
            }
        }

        delta = totaltime / Iterations;
        avg = (double)delta / Counter.Frequency;

        tot = (double)totaltime / Counter.Frequency;

        // How much memory before garbage collection
        bMem = System.GC.TotalMemory;

        start = Counter.Value;
        GarbageCollect();
        end = Counter.Value;

        // Now, How much memory !!
        aMem = System.GC.TotalMemory;

        delta = end - start;
        gc = (double)delta / Counter.Frequency;

        long mem = (bMem - aMem);

        Console.WriteLine(" T {0:F3} M {1:F3} X {2:F3} A {3:F3} GC {4:F3}", // bMem {5} aMem {6}", 
            tot, min, max, avg, gc); //, bMem, aMem);
    }
}
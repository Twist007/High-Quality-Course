namespace ClassStupidListT
{
    using System;

    class StuoidListMain
    {
        static void Main(string[] args)
        {
            var startTime = DateTime.Now;
            int limitNum = 1000;

            StupidList<int> stupidList = new StupidList<int>();

            for (int i = 0; i < limitNum; i++)
            {
                stupidList.Add(i);
            }

            Console.WriteLine(DateTime.Now - startTime);
        }
    }
}

namespace ClassStupidListT
{
    using System;

    public class StupidList<T>
    {
        private T[] arr = new T[0];

        public int Lenght => this.arr.Length;

        public T this[int index] => this.arr[index];

        public T First => this.arr[0];

        public T Last => this.arr[this.arr.Length - 1];

        public void Add(T item)
        {
            var newArr = new T[this.arr.Length + 1];
            Array.Copy(this.arr, newArr, this.arr.Length);
            newArr[newArr.Length - 1] = item;
            this.arr = newArr;
        }

        public T Remove(int index)
        {
            T result = this.arr[index];
            var newArr = new T[this.arr.Length - 1];
            Array.Copy(this.arr, newArr, index);
            Array.Copy(this.arr, index + 1, newArr, index, this.arr.Length - index - 1);
            this.arr = newArr;

            return result;
        }

        public T RemoveFirst()
        {
            return this.Remove(0);
        }

        public T RemoveLast()
        {
            return this.Remove(this.Lenght - 1);
        }
    }
}
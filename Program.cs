namespace home_HashTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyHashTable phoneBook = new MyHashTable();

            phoneBook.Add("John White", 34534);

            Console.WriteLine(phoneBook.Find("John White"));
            phoneBook.Remove("John White");

            try
            {
                phoneBook.Remove("John White");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
using System;
using StackExchange.Redis;

namespace redisSeeder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Seeding Redis DB");

            ConnectionMultiplexer redis = null;
            redis = ConnectionMultiplexer.Connect("localhost:6379"); // You might have to update per your redis install.

            IDatabase db = redis.GetDatabase(0);

            // Seeding strings
            for (int i = 0; i < 1000; i++)
            {
                db.StringSet("key:" + i.ToString(), "val-" + i.ToString());
            }

            for (int i = 0; i < 1000; i++)
            {
                db.StringSet("ikey:" + i.ToString(), i.ToString());
            }

            // Seeding start of list.
            for (int i = 0; i < 1000; i++)
            {
                db.ListLeftPush("list-mylist", "val-" + i.ToString());
            }

            for (int i = 2000; i < 3000; i++)
            {
                db.ListLeftPush("list-mylist", i);
            }

            // Seeding to the end of the list.
            for (int i = 3000; i < 4000; i++)
            {
                db.ListRightPush("list-mylist", i);
            }

            // This is going to seed sets   
            for (int i = 0; i < 1000; i++)
            {
                db.SetAdd("set-1", i.ToString());
            }

            // This is going to see sorted sets
            for (int i = 0; i < 1000; i++)
            {
                db.SortedSetAdd("sortedset-2", "val-" + i.ToString(), i);
            }

            // This is going to do hashes
            for (int i = 0; i < 1000; i++)
            {
                db.HashSet("hash-3", "val-" + i.ToString(), i);
            }

            // Displaying the key types
            foreach (var key in redis.GetServer("localhost:6379").Keys(0))
            {
                Console.WriteLine(db.KeyType(key).ToString());
            }

        }
    }
}

using System;
using System.Collections.Generic;

namespace SimpleCacheWithRedis
{

    class Program
    {
        static ICacheProvider _cacheProvider;
        
        static void Main(string[] args)
        {
            _cacheProvider = new RedisCacheProvider();

            List<Person> people = new List<Person>()
            {
                new Person(1, "Ali", new List<Contact>()
                {
                    new Contact("1", "0912"),
                    new Contact("2", "0935")
                })
            };

            _cacheProvider.Set("People", people);
            var contacts = _cacheProvider.Get<List<Contact>>("People");

            Console.WriteLine(String.Join(',', contacts));

            Console.WriteLine("Done...");
        }
    }
}

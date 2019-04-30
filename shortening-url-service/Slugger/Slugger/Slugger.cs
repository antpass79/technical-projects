using System;
using System.Collections.Generic;

namespace Slugger
{
    public class Slugger
    {
        private const string Characters = "abcdefghijklmnopqrstuvyxzABCDEFGHIJKLMNOPQRSTUVYXZ0123456789";
        private readonly int Base = Characters.Length;

        private int _id = 1000000000;

        private Dictionary<string, string> _dict = new Dictionary<string, string>();

        public Slugger()
        {
        }

        public string Slug(string longUrl)
        {
            if (!IsValid(longUrl))
                throw new ArgumentException("Invalid longUrl");

            if (_dict.ContainsKey(longUrl))
                return _dict[longUrl];

            var nextSlug = NextSlug(_id++);

            _dict.Add(longUrl, nextSlug);

            return nextSlug;
        }

        private bool IsValid(string longUrl)
        {
            return !string.IsNullOrWhiteSpace(longUrl);
        }

        private string NextSlug(int id)
        {
            Console.WriteLine("Start with");
            Console.WriteLine(id);

            var nextSlug = string.Empty;

            while (id > 0)
            {
                // i = 1 => 0, 42 => 1 - 0 * 42 = 1
                // i = 1 => 0, 42 => 1 - 0 * 42 = 1
                // i = 10 => 0, 42 => 10 - 0 * 42 = 10
                // i = 100 => 4, 2 => 100 - 2 * 42 = 16
                // ...
                int index = id % Base;
                nextSlug += Characters[index];
                id = id / Base; // cut order of magnitude to obtain 6 characters
            }

            return nextSlug;
        }
    }
}

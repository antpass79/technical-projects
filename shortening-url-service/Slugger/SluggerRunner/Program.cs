using System;

namespace SluggerRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var slugger = new Slugger.Slugger();

            var longUrl1 = "www.microsoft.com";
            var slug1 = slugger.Slug(longUrl1);
            var longUrl2 = "www.github.com";
            var slug2 = slugger.Slug(longUrl2);
            var longUrl3 = "www.microsoft.com";
            var slug3 = slugger.Slug(longUrl3);

            Console.WriteLine(slug1);
            Console.WriteLine(slug2);
            Console.WriteLine(slug3);

            Console.Read();
        }
    }
}

using System;
using Xunit;

// https://xunit.github.io/docs/getting-started/netfx/visual-studio
namespace SluggerTests
{
    public class SluggerTests
    {
        [Fact]
        public void ThrowExceptionIfNull()
        {
            var slugger = new Slugger.Slugger();

            Assert.Throws<ArgumentException>(() => slugger.Slug(null));
        }

        [Fact]
        public void ThrowExceptionIfEmpty()
        {
            var slugger = new Slugger.Slugger();

            Assert.Throws<ArgumentException>(() => slugger.Slug(string.Empty));
        }

        [Fact]
        public void Generate6CharsSlug()
        {
            var slugger = new Slugger.Slugger();

            var longUrl = "www.microsoft.com";
            var slug = slugger.Slug(longUrl);

            Assert.Equal(6, slug.Length);
        }

        [Fact]
        public void GetSameSlug()
        {
            var slugger = new Slugger.Slugger();

            var longUrl1 = "www.microsoft.com";
            var slug1 = slugger.Slug(longUrl1);
            var longUrl2 = "www.microsoft.com";
            var slug2 = slugger.Slug(longUrl2);

            Assert.Equal(slug1, slug2);
        }

        [Fact]
        public void GetDifferentSlugs()
        {
            var slugger = new Slugger.Slugger();

            var longUrl1 = "www.microsoft.com";
            var slug1 = slugger.Slug(longUrl1);
            var longUrl2 = "www.github.com";
            var slug2 = slugger.Slug(longUrl2);

            Assert.NotEqual(slug1, slug2);
        }
    }
}

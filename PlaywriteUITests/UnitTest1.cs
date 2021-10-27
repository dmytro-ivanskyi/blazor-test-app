using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

namespace PlaywrightUITests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1Async()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync( new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 3000
            });
            var page = await browser.NewPageAsync();


            await page.GotoAsync("http://localhost:5000/");
            var title = await page.QuerySelectorAsync("title");

            Assert.AreEqual("BlazorTestApp", await title.InnerTextAsync());
        }
    }
}
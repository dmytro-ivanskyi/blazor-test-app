using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

namespace PlaywrightUITests
{
    public class CounterTests
    {
        [Test]
        public async Task Counter_Increase_Correctly()
        {
            const string EXPECTED_COUNT_TEXT = "Current count: 3";
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 3000
            });
            var page = await browser.NewPageAsync();
            await page.GotoAsync("http://localhost:5000/counter");

            await page.ClickAsync("text=Click Me", new PageClickOptions
            {
                ClickCount = 3,
            });

            var counter = await page.QuerySelectorAsync("text=Current count:");

            Assert.AreEqual(EXPECTED_COUNT_TEXT, await counter.InnerTextAsync());
        }
    }
}

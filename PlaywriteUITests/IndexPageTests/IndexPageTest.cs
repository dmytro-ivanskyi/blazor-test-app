using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

namespace PlaywrightUITests
{
    [Parallelizable(ParallelScope.Self)]
    public class Tests
    {
        private IBrowser _browser;

        [SetUp]
        public async Task Setup()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 3000
            });
            _browser = browser;
        }

        [Test]
        public async Task IndexPageTitle_IsCorrectAsync()
        {
            

            var page = await _browser.NewPageAsync();

            await page.GotoAsync("http://localhost:5000/");
            var title = await page.QuerySelectorAsync("title");

            Assert.AreEqual("BlazorTestApp", await title.InnerTextAsync());
        }


        [Test]
        public async Task IndexPage_ClickSubmitWithCheckbox_IsValid()
        {

            var page = await _browser.NewPageAsync();

            await page.GotoAsync("http://localhost:5000/");
            var title = await page.QuerySelectorAsync("title");

            Assert.AreEqual("BlazorTestApp", await title.InnerTextAsync());
        }
    }
}
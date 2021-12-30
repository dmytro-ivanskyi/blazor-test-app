using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Threading.Tasks;

namespace PlaywrightUITests
{
    [Parallelizable(ParallelScope.Self)]
    public class IndexPageNewTabTests : ContextTest
    {
        private const string URL = "http://localhost:5000/";

        [Test]
        public async Task IndexPageTitle_IsCorrectAsync()
        {
            const string EXPECTED_TITLE = "Getting started | Playwright .NET";
            var mainPage = await Context.NewPageAsync();
            await mainPage.GotoAsync(URL);

            var newPage = await Context.RunAndWaitForPageAsync(async () =>
            {
                await mainPage.ClickAsync("a[target='_blank']");
            });

            await newPage.WaitForLoadStateAsync();

            Assert.AreEqual(EXPECTED_TITLE, await newPage.TitleAsync());
        }
    }
}

using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Threading.Tasks;

namespace PlaywrightUITests
{
    //[Ignore("skip")]
    [Parallelizable(ParallelScope.Self)]
    public class IndexPageTests : PageTest
    {
        private const string URL = "http://localhost:5000/";

        [Test]
        public async Task IndexPageTitle_IsCorrectAsync()
        {
            const string EXPECTED_TITLE = "BlazorTestApp";

            await Page.GotoAsync(URL);
            var actual_title = await Page.TitleAsync();

            Assert.AreEqual(EXPECTED_TITLE, actual_title);
        }


        [Test]
        public async Task IndexPage_ClickSubmitWithoutCheckbox_IsInvalid()
        {
            const string EXPECTED_MESSAGE = "You need to be ready!";
            await Page.GotoAsync(URL);
            // await Page.CheckAsync("input[type=\"checkbox\"]");
            await Page.ClickAsync("text=Submit");
            var actual_message = await Page.QuerySelectorAsync(".validation-message");

            Assert.AreEqual(EXPECTED_MESSAGE, await actual_message.InnerTextAsync());
        }
    }
}
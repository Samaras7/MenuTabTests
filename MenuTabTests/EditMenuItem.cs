using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework.Internal;

namespace MenuTabTests
{
    public class Tests : PageTest
    {
        private const string BaseUrl = "https://reception.next-dev.speeron.com:443/recruitment-patryk-piworowicz";
        private const string Token = "wCjwkQOezVUk7iN9N6IayFkGjOR2EeR";
        private const string updatedLabel = "Updated TV & Applications";

        [SetUp]
        public async Task Setup()
        {
            Console.WriteLine("Open site with token");

            await Page.GotoAsync($"{BaseUrl}?token={Token}", new PageGotoOptions
            {
                WaitUntil = WaitUntilState.Load
            });

            if (Page.Url.Contains("AuthenticationFailed"))
            {
                Assert.Fail("Error, token expired or invalid");
            }

            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        }

        /// <summary>
        /// Testing possibility of editing menu item.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task EditMenuItem()
        {
            Console.WriteLine("Clicking Guest Portal");
            await Page.Locator("span:has-text('Guest Portal')").WaitForAsync();
            await Page.Locator("span:has-text('Guest Portal')").ClickAsync();

            Console.WriteLine("Clicking Menu");
            await Page.Locator("li[data-test-id='menu-submenu']").WaitForAsync();
            await Page.Locator("li[data-test-id='menu-submenu']").ClickAsync();

            Console.WriteLine("Clicking edit button on the first menu item");
            await Page.Locator("button:has(svg.icon-tabler-edit)").First.WaitForAsync();
            await Page.Locator("button:has(svg.icon-tabler-edit)").First.ClickAsync();

            Console.WriteLine("Changing item label to 'Updated TV & Applications");
            var labelInput = Page.Locator("input[data-test-id = 'name-input']").First;
            await labelInput.FillAsync("Updated TV & Applications");

            Console.WriteLine("Saving Changes");

            //Checking if test isn't fake passing.
            var request = await Page.RunAndWaitForRequestAsync(async () =>
            {
                await Page.Locator("button[data-test-id='form-add-or-update-button']").ClickAsync();
            }, req =>
                req.Method == "PUT" && req.Url.Contains("/menu")
            );

            Console.WriteLine($"Captured request URL: {request.Url}");
            var postData = request.PostData;
            Console.WriteLine($"Request body: {postData}");

            Assert.That(postData, Does.Contain(updatedLabel), "Request body should contain updated label");

            Console.WriteLine("Verify changes");
            await Expect(Page.Locator("text=Updated TV & Applications")).ToBeVisibleAsync();
        }
    }
}

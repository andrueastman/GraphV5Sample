using Microsoft.Graph;
using Azure.Identity;

namespace GraphV4Sample
{
    class Program
    {
        public static async Task Main(string[] _)
        {
            // Other TokenCredentials examples are available at https://github.com/microsoftgraph/msgraph-sdk-dotnet/blob/dev/docs/tokencredentials.md
            string[] scopes = new[] { "User.Read", "User.ReadWrite" };
            InteractiveBrowserCredentialOptions interactiveBrowserCredentialOptions = new InteractiveBrowserCredentialOptions()
            {
                ClientId = "CLIENT_ID"
            };
            InteractiveBrowserCredential interactiveBrowserCredential = new InteractiveBrowserCredential(interactiveBrowserCredentialOptions);
            // GraphServiceClient constructor accepts tokenCredential
            GraphServiceClient graphServiceClient = new GraphServiceClient(interactiveBrowserCredential, scopes);

            var user = await graphServiceClient.Me.GetAsync();

            Console.WriteLine(user.DisplayName);
        }
    }
}
HttpClient client = new();
HttpResponseMessage response = await client.GetAsync("https://www.apple.com/");

Console.WriteLine($"Apple's home page has {response.Content.Headers.ContentLength:N0} bytes.");

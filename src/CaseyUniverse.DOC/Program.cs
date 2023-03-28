using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CaseyUniverse.DOC;
using Ganss.Xss;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<HtmlSanitizer, HtmlSanitizer>(x =>
{
    var sanantize = new HtmlSanitizer();
    // sanantize.AllowedAttributes.Add("class");
    return sanantize;
});

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

await builder.Build().RunAsync();


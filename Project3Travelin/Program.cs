using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using Project3Travelin.Services.BookingServices;
using Project3Travelin.Services.CategoryServices;
using Project3Travelin.Services.CommentServices;
using Project3Travelin.Services.TourRotaRota;
using Project3Travelin.Services.TourRotaService;
using Project3Travelin.Services.TourServices;
using Project3Travelin.Settings;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// DI servisleri
builder.Services.AddScoped<ICommentServices, CommentService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ITourService, TourService>();
builder.Services.AddScoped<ITourRotaServices, TourRotaService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettingsKey"));
builder.Services.AddScoped<IDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

// Lokalizasyon
builder.Services.AddControllersWithViews()
    .AddViewLocalization()
    .AddDataAnnotationsLocalization();

// Kültür seçeneklerini ayarla
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new List<CultureInfo>
    {
        new CultureInfo("tr"),
        new CultureInfo("en"),
        new CultureInfo("de"),
        new CultureInfo("fr")
    };

    options.DefaultRequestCulture = new RequestCulture("tr");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;

    // Cookie önce, sonra QueryString
    options.RequestCultureProviders = new List<IRequestCultureProvider>
    {
        new CookieRequestCultureProvider(),
        new QueryStringRequestCultureProvider()
    };
});

var app = builder.Build();

// Localization middleware'i en başta çağır
var locOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value;
app.UseRequestLocalization(locOptions);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Travelin}/{action=Index}/{id?}");

app.Run();
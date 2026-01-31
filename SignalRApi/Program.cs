using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Concrete;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.concrete;
using SignalR.DataAccessLayer.EntityFreamwork;
using SignalRApi.Hubs;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
       builder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((Host) => true) 
        .AllowCredentials();
    });
});
builder.Services.AddSignalR();

builder.Services.AddDbContext<SignalRContext>();
builder.Services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());

builder.Services.AddScoped<IAboutService, AboutManeger>();
builder.Services.AddScoped<IAboutDal, EfAboutDal>();

builder.Services.AddScoped<IBookingService, BookingManeger>();
builder.Services.AddScoped<IBookingDal, EfBookingDal>();

builder.Services.AddScoped<ICategoryService, CategoryManeger>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();

builder.Services.AddScoped<IContactService, ContactManeger>();
builder.Services.AddScoped<IContactDal, EfContactDal>();

builder.Services.AddScoped<IDiscountService, DiscountManeger>();
builder.Services.AddScoped<IDiscountDal, EfDiscountDal>();

builder.Services.AddScoped<IFeatureService, FeatureManeger>();
builder.Services.AddScoped<IFeatureDal, EfFeatureDal>();

builder.Services.AddScoped<IProductService, ProductManeger>();
builder.Services.AddScoped<IProductDal, EfProductDal>();

builder.Services.AddScoped<ISocialMediaService, SocialMediaManeger>();
builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();

builder.Services.AddScoped<ITestimonialService, TestimonialManeger>();
builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();

builder.Services.AddScoped<IOrderService, OrderManeger>();
builder.Services.AddScoped<IOrderDal, EfOrderDal>();

builder.Services.AddScoped<IOrderDeteilService, OrderDeteilManeger>();
builder.Services.AddScoped<IOrderDeteilDal, EfOrderDeteilDal>();

builder.Services.AddScoped<IMoneyCaseService, MoneyCaseManeger>();
builder.Services.AddScoped<IMoneyCaseDal, EfMoneyCaseDal>();

builder.Services.AddScoped<IMenuTableService, MenuTableManeger>();
builder.Services.AddScoped<IMenuTableDal, EfMenuTableDal>();

builder.Services.AddScoped<ISliderService, SliderManeger>();
builder.Services.AddScoped<ISliderDal, EfSliderDal>();

builder.Services.AddScoped<IBasketService, BasketManeger>();
builder.Services.AddScoped<IBasketDal, EfBasketDal>();

builder.Services.AddControllersWithViews().AddJsonOptions(options=> options.JsonSerializerOptions.ReferenceHandler=ReferenceHandler.IgnoreCycles);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();
app.MapHub<SignalRHub>("/signalrhub");

app.Run();

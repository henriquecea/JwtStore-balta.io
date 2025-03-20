using JwtStore.Api.Extension;

var builder = WebApplication.CreateBuilder(args);
builder.AddConfiguration();
builder.AddDatabase();
builder.AddJwtAuthentication();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.Run();

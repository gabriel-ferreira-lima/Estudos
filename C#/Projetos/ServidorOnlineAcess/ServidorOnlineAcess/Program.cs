using Microsoft.AspNetCore.Mvc;
using ServidorOnlineAcess;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options => {
    options.ListenAnyIP(5124);
});

var app = builder.Build();

app.MapPost("/device_is_alive.fcgi", () => {
    return Task.FromResult("");
});

app.MapPost("/new_user_identified.fcgi", (HttpContext context, [FromForm] int user_id, [FromForm] string user_name) => {
    if (user_id > 0) {

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"[{DateTime.Now}] API New_user_identified - ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"usuario identificado = {user_name}");

        return Results.Json(new {
            result = new {
                @event = 7,
                user_id = user_id,
                user_name = user_name,
                user_image = true,
                portal_id = 1,
                actions = new[] { new { action = "sec_box", parameters = "id=65793, reason=1" } }

            }
        });
    }
    return Results.Json(new {
        result = new {
            @event = 3,
            user_id = 0,
            user_name = "",
            user_image = false,
            portal_id = 1,
            actions = new object[] { }

        }
    });
}).DisableAntiforgery();

app.MapPost("/api/notifications/dao", ([FromBody] object response) => {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"[{DateTime.Now}] API DAO - ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(response);
    return Task.FromResult("");
});

app.MapPost("/api/notifications/usb_drive", ([FromBody] object response) => {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"[{DateTime.Now}] API usb_drive - ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(response);
    return Task.FromResult("");
});

app.MapPost("/api/notifications/template", ([FromBody] object response) => {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"[{DateTime.Now}] API template - ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(response);
    return Task.FromResult("");
});

app.MapPost("/api/notifications/user_image", ([FromBody] object response) => {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"[{DateTime.Now}] API user_image - ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(response);
    return Task.FromResult("");
});

app.MapPost("/api/notifications/card", ([FromBody] object response) => {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"[{DateTime.Now}] API card - ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(response);
    return Task.FromResult("");
});

app.MapPost("/api/notifications/pin", ([FromBody] object response) => {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"[{DateTime.Now}] API pin - ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(response);
    return Task.FromResult("");
});

app.MapPost("/api/notifications/password", ([FromBody] object response) => {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"[{DateTime.Now}] API password - ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(response);
    return Task.FromResult("");
});

app.MapPost("/api/notifications/catra_event", ([FromBody] object response) => {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"[{DateTime.Now}] API catra_event - ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(response);
    return Task.FromResult("");
});

app.MapPost("/api/notifications/operation_mode", ([FromBody] object response) => {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"[{DateTime.Now}] API operation_mode - ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(response);
    return Task.FromResult("");
});

app.MapPost("/api/notifications/device_is_alive", ([FromBody] object response) => {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"[{DateTime.Now}] API device_is_alive - ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(response);
    return Task.FromResult("");
});

app.MapPost("/api/notifications/door", ([FromBody] object response) => {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"[{DateTime.Now}] API door - ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(response);
    return Task.FromResult("");
});

app.MapPost("/api/notifications/secbox", ([FromBody] object response) => {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"[{DateTime.Now}] API secbox - ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(response);
    return Task.FromResult("");
});

app.MapPost("/api/notifications/access_photo", ([FromBody] object response) => {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"[{DateTime.Now}] API access_photo - ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(response);
    return Task.FromResult("");
});


Configuration.Initialize(builder.Configuration);

await Screen.Load();
Console.Clear();

app.Run();
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

app.MapPost("/new_user_identified.fcgi", (HttpContext context, [FromForm] long user_id, [FromForm] string user_name) => {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"[{DateTime.Now}] API New_user_identified - ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"usuario identificado = teste");

    return Results.Json(new {
        result = new {
            @event = 7,
            user_id,
            user_name = "teste",
            user_image = true,
            portal_id = 1,
            actions = new[] { new { action = "catra", parameters = "allow=both" } }
        }
    });
}).DisableAntiforgery(); 

app.MapPost("/new_card.fcgi", (HttpContext context, [FromForm] long card_value) => {

    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"[{DateTime.Now}] API New_Card - ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine($"usuario identificado = teste");

    return Results.Json(new {
        result = new {
            @event = 7,
            user_id = 1,
            user_name = "teste",
            user_image = false,
            portal_id = 1,
           actions = new[] { new { action = "sec_box", parameters = "id=65793, reason=1" } }

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

    var pushtime = DateTime.Now.AddMinutes(1);

    if (pushtime > Configuration.PushExample) {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"[{DateTime.Now}] API device_is_alive (MONITOR)- ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(response);
        return Results.Json("");

    }
    return Results.Json("");
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

/*
app.MapGet("/push", () => {

    var pushtime = DateTime.Now.AddMinutes(1);
    //var horarioAtual = DateTime.Now;

    if (pushtime > Configuration.PushExample) {
        Configuration.PushExample = DateTime.Now.AddMinutes(2);

        return Results.Json(new {
            verb = "POST",
            endpoint = "system_information",
            contentType = "application/json",
            body = new { }
        });
    }

    return Results.Json(new { });
});


int cont = 0;

app.MapGet("/push", () => {

    if (cont == 5) {
        cont = 0;
        return Results.Ok(new {
            verb = "POST",
            endpoint = "system_information",
            contentType = "application/json",
            body = new { }
        });
    }

    cont++;
    return Results.Ok(new {});
});


app.MapPost("/result", ([FromBody] object response) => {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"[{DateTime.Now}] API Result - ");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(response);
    return Task.FromResult("");
});
*/

Configuration.Initialize(builder.Configuration);

await Screen.Load();
Console.Clear();

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Servidor Iniciado\r\n");
Console.ForegroundColor = ConsoleColor.White;

app.Run();
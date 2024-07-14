var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async context =>
{
    var path = context.Request.Path.ToString().ToLower();
    context.Response.ContentType = "text/html; charset=utf-8";

    if (path == "/home")
    {
        await context.Response.WriteAsync("<h1 style='color:green'>Home page</h1>");
    }
    else if (path == "/home/name")
    {
        await context.Response.WriteAsync("Скорих Артем");
    }
    else if (path == "/home/date")
    {
        await context.Response.WriteAsync($"Назва додатку: HW18.06.24<br>Поточна дата: {DateTime.Now.ToShortDateString()}");
    }
    else if (path == "/home/tasks")
    {
        await context.Response.WriteAsync(@"
            <html>
                <body>
                    <h1>Список справ на сьогодні</h1>
                    <ul>
                        <li>Зробити домашню роботу</li>
                        <li>Вигуляти собаку</li>
                        <li>Прибрати кімнату</li>
                    </ul>
                </body>
            </html>");
    }
    else
    {
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync($"<h1 style='color:red'>Not found</h1>");
    }    
});

app.Run();
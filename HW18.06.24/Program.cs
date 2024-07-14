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
        await context.Response.WriteAsync("������ �����");
    }
    else if (path == "/home/date")
    {
        await context.Response.WriteAsync($"����� �������: HW18.06.24<br>������� ����: {DateTime.Now.ToShortDateString()}");
    }
    else if (path == "/home/tasks")
    {
        await context.Response.WriteAsync(@"
            <html>
                <body>
                    <h1>������ ����� �� �������</h1>
                    <ul>
                        <li>������� ������� ������</li>
                        <li>�������� ������</li>
                        <li>�������� ������</li>
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
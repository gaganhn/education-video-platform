using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebApplication235.DomainFacade;

namespace WebApplication235
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:7000");
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseWebSockets();
            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/video/{standard:int}/{subject:alpha}/{lectureid:int}", async context =>
                {
                    if (context.WebSockets.IsWebSocketRequest)
                    {
                        VideoProcessing stream = new VideoProcessing();
                        WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
                        await foreach (var videoByte in stream.CoreProcessingLogic(context))
                        {
                            await Task.Delay(1000);
                            await webSocket.SendAsync(videoByte, WebSocketMessageType.Binary, true, CancellationToken.None);
                        }
                        await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Video Stream is completed", CancellationToken.None);
                    }
                    else
                    {
                        await context.Response.WriteAsync("Hello World!");
                    }

                });

                endpoints.MapGet("/metadata", async context =>
                {
                    Root obj = new Root();
                    List<Metadata> listofVideos = new List<Metadata>();
                    using (XLWorkbook wb = new XLWorkbook("metadata-info.xlsx"))
                    {
                        var ws = wb.Worksheets.First();
                        var range = ws.RangeUsed();

                        for (int i = 1; i < range.RowCount() + 1; i++)
                        {
                            Metadata data = new Metadata();
                            for (int j = 1; j < range.ColumnCount() + 1; j++)
                            {
                                switch (j)
                                {
                                    case 1:
                                        data.Standard = ws.Cell(i, j).Value.ToString();
                                        break;
                                    case 2:
                                        data.Subject = ws.Cell(i, j).Value.ToString();
                                        break;
                                    case 3:
                                        data.Lecture = (ws.Cell(i, j).Value).ToString();
                                        listofVideos.Add(data);
                                        break;

                                }
                            }
                        }
                    }



                foreach (var value in listofVideos)
                {
                    if (obj.standards.ContainsKey(value.Standard))
                    {
                        var valueFromKey = obj.standards[value.Standard];
                        if (valueFromKey.subjects.ContainsKey(value.Subject))
                        {
                            var subjectfromkey = valueFromKey.subjects[value.Subject];
                            if (subjectfromkey.lectures.ContainsKey(value.Lecture))
                            {
                                //do nothing
                            }
                            else
                            {
                                var lecture = new lecture();
                                lecture.lectureid = value.Lecture;
                                subjectfromkey.lectures.Add(value.Lecture, lecture);
                            }
                        }
                        else
                        {
                            var subject = new subject();
                            subject.name = value.Subject;
                            valueFromKey.subjects.Add(value.Subject, subject);
                                var subjectfromkey = valueFromKey.subjects[value.Subject];
                                if (subjectfromkey.lectures.ContainsKey(value.Lecture))
                                {
                                    //do nothing
                                }
                                else
                                {
                                    var lecture = new lecture();
                                    lecture.lectureid = value.Lecture;
                                    subjectfromkey.lectures.Add(value.Lecture, lecture);
                                }

                            }
                    }
                    else
                    {
                        standard std = new standard();
                        std.name = value.Standard;
                        obj.standards.Add(value.Standard, std);
                        var valueFromKey = obj.standards[value.Standard];
                            if (valueFromKey.subjects.ContainsKey(value.Subject))
                            {
                                var subjectfromkey = valueFromKey.subjects[value.Subject];
                                if (subjectfromkey.lectures.ContainsKey(value.Lecture))
                                {
                                    //do nothing
                                }
                                else
                                {
                                    var lecture = new lecture();
                                    lecture.lectureid = value.Lecture;
                                    subjectfromkey.lectures.Add(value.Lecture, lecture);
                                }
                            }
                            else
                            {
                                var subject = new subject();
                                subject.name = value.Subject;
                                valueFromKey.subjects.Add(value.Subject, subject);
                                var subjectfromkey = valueFromKey.subjects[value.Subject];
                                if (subjectfromkey.lectures.ContainsKey(value.Lecture))
                                {
                                    //do nothing
                                }
                                else
                                {
                                    var lecture = new lecture();
                                    lecture.lectureid = value.Lecture;
                                    subjectfromkey.lectures.Add(value.Lecture, lecture);
                                }

                            }
                        }
                   }

                    var values = JsonConvert.SerializeObject(obj);
                    await context.Response.WriteAsync(values);
                });

            });
        }
    }
}

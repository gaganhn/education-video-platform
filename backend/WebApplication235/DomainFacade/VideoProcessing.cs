using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication235.DomainFacade
{
    public class VideoProcessing
    {
        private readonly HttpClient client = new HttpClient();
        public async IAsyncEnumerable<Memory<byte>> CoreProcessingLogic(HttpContext ctx)
        {
            var bytePool = ArrayPool<byte>.Shared;
            byte[] buffer = bytePool.Rent(1000000);
            var absoluteUrl = "http://localhost:7001/" + ctx.Request.RouteValues["standard"] + "/" + ctx.Request.RouteValues["subject"] + "/" + ctx.Request.RouteValues["lectureid"] + ".webm";
            using (var response = await client.GetAsync(absoluteUrl, HttpCompletionOption.ResponseHeadersRead))
            await using (var remoteStream = await response.Content.ReadAsStreamAsync())
            {
                int byteRead;
                while ((byteRead = await remoteStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    yield return buffer.AsMemory().Slice(0, byteRead);
                }
            }

            bytePool.Return(buffer);
        }
    }
}

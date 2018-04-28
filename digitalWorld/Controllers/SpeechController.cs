using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Threading.Tasks;

namespace digitalWorld.Controllers
{
    public class SpeechController : ApiController
    {
        // POST: baiduAPI/AsrDataAsync
        public async Task<IHttpActionResult> AsrDataAsync()
        {
            var APP_ID = "11144149";
            var API_KEY = "1YEXzgcWVetlpNzTZDBIehSY";
            var SECRET_KEY = "yA1MsenRjEkLsxXW0fGZzsgfX80gT8qh";

            byte[] buffer = await Request.Content.ReadAsByteArrayAsync();

            var client = new Baidu.Aip.Speech.Asr(API_KEY, SECRET_KEY);
                                     // var data = System.IO.File.ReadAllBytes(Request.PhysicalApplicationPath + "\\Upload\\16k.pcm");
            client.Timeout = 120000; // 若语音较长，建议设置更大的超时时间. ms
            var result = client.Recognize(buffer, "pcm", 16000);
            Console.Write(result);
            return Ok(result);
            //}

        }

    }
}

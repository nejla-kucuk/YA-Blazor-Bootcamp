using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xabe.FFmpeg;

namespace NK.VideoTranscribeApp.BlazorUI.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public VideosController(IWebHostEnvironment environment)
        {
            _environment = environment;
            
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync(VideoUploadRequest request, CancellationToken cancellationToken)
        {
            var uploadsPath = Path.Combine(_environment.WebRootPath, "uploads");

            var videoFilePath = "C:\\Users\\Asus\\Desktop\\Sam-Bankman-Fried.mp4";
            
            string audioFilePath = Path.ChangeExtension(videoFilePath, "mp3");

            CancellationTokenSource cts = new CancellationTokenSource();

            FFmpeg.SetExecutablesPath("C:\\Users\\Asus\\Downloads\\ffmpeg-master-latest-win64-gpl\\ffmpeg-master-latest-win64-gpl\\bin");

           
            var conversion = await FFmpeg.Conversions.FromSnippet.ExtractAudio(videoFilePath, audioFilePath);

            await conversion.Start(cts.Token);

            Console.WriteLine("Conversion completed.");

            Console.WriteLine(audioFilePath);
            return Ok();
        }
    }


    public class VideoUploadRequest
    {
        public IFormFile Video { get; set; }
        public string[] Languages { get; set; }
    }

}

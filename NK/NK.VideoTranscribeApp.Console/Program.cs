using System.Resources;
using Xabe.FFmpeg;

var videoFilePath = "C:\\Users\\Asus\\Desktop\\\\Sam-Bankman-Friend.mp4";

string audioFilePath = Path.ChangeExtension(Path.GetTempFileName(), "mp3"); //mp4'ü mp3'e çevirir.

CancellationTokenSource cts = new CancellationTokenSource();

var conversion = await FFmpeg.Conversions.FromSnippet.ExtractAudio(videoFilePath, audioFilePath);

await conversion.Start(cts.Token);

Console.WriteLine("Completed..");
Console.WriteLine(audioFilePath);


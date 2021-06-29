using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.Threading;

namespace ComputerVC.Computer
{
    class ComputerServices
    {
        private static readonly ComputerVisionClient CLIENTE = ComputerClient.Computer;

        public async static Task DescribeImagen(string url) {
            using (var imagen = File.OpenRead(url))
            {
                var result = await CLIENTE.DescribeImageInStreamAsync(imagen, language: "es");
                var captions = result.Captions;
                var tags = result.Tags;
                Console.WriteLine("-.-.-.-.-.-.Captions-.-.-.-.-.-.");
                captions.ToList().ForEach(t => Console.WriteLine(t.Text));
                Console.WriteLine("-.-.-.-.-.-.-Tags-.-.-.-.-.");
                tags.ToList().ForEach(t => Console.WriteLine(t));
            }
        }

        public async static Task Rostros(string url) {
            using (var imagen=File.OpenRead(url)) {
                IList<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>() {
                   VisualFeatureTypes.Faces
                };
                var resultado = await CLIENTE.AnalyzeImageInStreamAsync(imagen, features, language:"es");
                var faces = resultado.Faces;
                
                faces.ToList().ForEach(t => {
                    StringBuilder build = new StringBuilder();
                    build.Append("age:  ").Append(t.Age).Append("\n")
                    .Append("Genero: ").Append(t.Gender).Append("\n")
                    .Append("-*-*-*Rectangule-*-*-*\n")
                    .Append("left: ").Append(t.FaceRectangle.Left).Append("\n")
                    .Append("top: ").Append(t.FaceRectangle.Top).Append("\n")
                    .Append("width: ").Append(t.FaceRectangle.Width).Append("\n")
                    .Append("height: ").Append(t.FaceRectangle.Height).Append("\n");
                    Console.WriteLine(build.ToString());
                });


            }

        }


        public async static Task Colores(string url) {
            using (var imagen=File.OpenRead(url)) {
                IList<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>() {
                   VisualFeatureTypes.Color
                };
                var resultado = await CLIENTE.AnalyzeImageInStreamAsync(imagen, features, language: "es");
                var colors = resultado.Color;
                Console.WriteLine($"color dominante-background {colors.DominantColorBackground}");
                Console.WriteLine($"color dominante-foreground {colors.DominantColorForeground}");
              
                Console.WriteLine("-*-*-*colores dominantes-*-*-* ");
                colors.DominantColors.ToList().ForEach(t => Console.WriteLine($"color: {t}"));

            }
        }

        public async static Task Adulto(string url)
        {
            using (var imagen = File.OpenRead(url))
            {
                IList<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>() {
                   VisualFeatureTypes.Adult
                };
                var resultado = await CLIENTE.AnalyzeImageInStreamAsync(imagen, features, language: "es");
                var adult = resultado.Adult;
                Console.WriteLine($"es contenido para adulto: {adult.IsAdultContent}");
                Console.WriteLine($"score adult {adult.AdultScore}");


            }
        }

        public async static Task TextoImagen(string url) {
            using (var imgSource = new FileStream(url, FileMode.Open, FileAccess.Read, FileShare.Read))
            {

                var text = await CLIENTE.ReadInStreamAsync(imgSource, language: "en");
                string operationLocation = text.OperationLocation;
                Thread.Sleep(2000);


                //Se utiliza el número 36 para obtener los últimos 36 caracteres
                const int numberOfCharsInOperationId = 36;
                //Console.WriteLine("Operation Location");
                //Console.WriteLine(operationLocation.Substring(operationLocation.Length - numberOfCharsInOperationId));
                string operationId = operationLocation.Substring(operationLocation.Length - numberOfCharsInOperationId);

                // Extract the text
                ReadOperationResult results;
                Console.WriteLine($"Extrayendo texto de archivo ...");
                Console.WriteLine();
                do
                {
                    results = await CLIENTE.GetReadResultAsync(Guid.Parse(operationId));
                }
                while ((results.Status == OperationStatusCodes.Running ||
                    results.Status == OperationStatusCodes.NotStarted));

                // Display the found text.
                Console.WriteLine();
                var textUrlFileResults = results.AnalyzeResult.ReadResults;
                foreach (ReadResult page in textUrlFileResults)
                {
                    foreach (Line line in page.Lines)
                    {
                        Console.WriteLine(line.Text);
                    }
                }
                Console.WriteLine();
            }

        }
    }
}

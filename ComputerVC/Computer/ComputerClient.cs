using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;

namespace ComputerVC.Computer
{
    class ComputerClient
    {
        private static readonly string API_KEY = "45482bcaabee49c98a0264b92b178c72";
        private static readonly string ENDPOINT = "https://computerenvf.cognitiveservices.azure.com/";
        public static ComputerVisionClient Computer { get; private set; }

        static ComputerClient() { InitComputer(); }

        private static void InitComputer() {
            if (Computer== null) {
                var credenciales = new ApiKeyServiceClientCredentials(API_KEY);
                Computer = new ComputerVisionClient(credenciales) { Endpoint= ENDPOINT};
            }
        }
    }
}

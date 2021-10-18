using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessImage(@"./luke.jpg");
            ProcessImage(@"./beer.jpg");
        }

        public static void ProcessImage(string path){
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(path);
            path = path.Substring(2);
            IPipe pipeNull = new PipeNull();

            IFilter filterNegative = new FilterNegative();
            IPipe pipeNegative = new PipeSerial(filterNegative, pipeNull);

            IFilter twitterFilter = new FilterPublishPicture("Test", "grey_" + path);
            IPipe pipeTwitter = new PipeSerial(twitterFilter, pipeNull);

            IConditionalFilter conditionalFilter = new FilterFaceRecognition("grey_" + path);
            IPipe conditionalPipe = new PipeConditionalFork(pipeNegative, pipeTwitter, conditionalFilter);

            IFilter saveFilter = new FilterSavePicture("grey_" + path);
            IPipe savePipe = new PipeSerial(saveFilter, conditionalPipe);

            IFilter filterGreyscale = new FilterGreyscale();
            IPipe pipeSerial = new PipeSerial(filterGreyscale, savePipe);
            provider.SavePicture(pipeSerial.Send(picture), "final_" + path);
        }
    }
}

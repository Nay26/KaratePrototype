using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace KaratePrototype
{
    class ImageCombiner
    {
        // Most of these are here in an atempt to use less memory.
        public string outputFilePath;
        int outputFileName;
        public string filePath;
        public string inputImageExtension;
        public List<string> layerDirectories = new List<string>();
        List<Image> layers = new List<Image>();
        FileInfo[] files;
        DirectoryInfo d;
        Image chosenImage;
        Bitmap outputImage;

        // Folder paths used in this application.
        public ImageCombiner()
        {
            outputFilePath = @".\Creation\CreatedImages\";
            filePath = @".\Creation\Parts\";
            inputImageExtension = ".png";
            layerDirectories.Add(@"1.Background\");
            layerDirectories.Add(@"2.SkinTone\");
            layerDirectories.Add(@"3.Head\");
            layerDirectories.Add(@"4.Mouth\");
            layerDirectories.Add(@"5.Nose\");
            layerDirectories.Add(@"6.Eyes\");
            layerDirectories.Add(@"7.Hair\");
        }

        // Gets a random image from each of the folders decided in the layer directories list, Adds them to a layers list.
        public void SelectRandomImageFromDirectories(Random rnd,int personid )
        {
            outputFileName = personid;
            layers.Clear();
            foreach (string directory in layerDirectories)
            {
                d = new DirectoryInfo(filePath + directory);
                files = d.GetFiles("*" + inputImageExtension);
                string fileName = files[rnd.Next(0, files.Length)].Name;
                chosenImage = Image.FromFile(filePath + directory + fileName);
                layers.Add(chosenImage);
            }
            MergeImageLayers(layers);
        }

        // Takes a list of images and merges them into one image.
        private void MergeImageLayers(List<Image> layers)
        {
            int outputImageWidth = layers[0].Width;
            int outputImageHeight = layers[0].Height;
            outputImage = new Bitmap(outputImageWidth, outputImageHeight, PixelFormat.Format32bppArgb);
            using (Graphics graphics = Graphics.FromImage(outputImage))
            {
                foreach (Image image in layers)
                {
                    graphics.DrawImage(image, new Rectangle(new Point(), image.Size),
                    new Rectangle(new Point(), image.Size), GraphicsUnit.Pixel);
                }
            }
            SaveImage(outputImage);
        }

        // Saves the image as a .png file.
        private void SaveImage(Bitmap output)
        {
            string completeOutputPath = outputFilePath + outputFileName + ".png";
            output.Save(completeOutputPath, ImageFormat.Png);
            output.Dispose();
        }
    }
}

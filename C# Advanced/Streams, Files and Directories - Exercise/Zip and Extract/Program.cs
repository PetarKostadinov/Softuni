using System;
using System.IO.Compression;

namespace ZipExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(@"C:\Users\niki_\Desktop\zipTake", @"C:\Users\niki_\Desktop\zipFileCreate\myZip.zip");

            ZipFile.ExtractToDirectory(@"C:\Users\niki_\Desktop\zipFileCreate\myZip.zip", @"C:\Users\niki_\Desktop\zipResult\Rezult.zip");
        }
    }
}

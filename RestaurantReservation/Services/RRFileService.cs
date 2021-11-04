﻿using Microsoft.AspNetCore.Http;
using RestaurantReservation.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReservation.Services
{
    public class RRFileService : IRRFileService
    {
        private readonly string[] suffixes = { "Bytes", "KB", "MB", "MB", "GB", "TB", "PB" };

        public async Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file)
        {
            MemoryStream memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            var byteFile = memoryStream.ToArray();

            memoryStream.Close();
            memoryStream.Dispose();

            return byteFile;
        }

        public string ConvertByteArrayToFile(byte[] fileData, string extension)
        {
            string imageBase64Data = Convert.ToBase64String(fileData);

            return string.Format($"data:image/{extension};base64,{imageBase64Data}");
        }

        public string GetFileIcon(string file)
        {
            string ext = Path.GetExtension(file).Replace(".", "");

            return $"/img/png/{ext}.png";
        }

        public string FormatFileSize(long bytes)
        {
            int counter = 0;
            decimal number = bytes;

            while (Math.Round(number / 1024) >= 1)
            {
                number /= 1024;
                counter++;
            }

            return string.Format("{0:n1}{1}", number, suffixes[counter]);
        }

    }
}

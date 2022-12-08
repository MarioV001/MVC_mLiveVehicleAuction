using Microsoft.AspNetCore.Hosting;
using System.Net.NetworkInformation;
using System.Reflection;
using mVehAuction.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;
using System.Drawing;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient.Server;
using System.IO;
using LazZiya.ImageResize;
using System;
using System.Linq.Expressions;

namespace mVehAuction.Models
{
    public static class FileUpload
    {
        public static string ReturnNewUniqueKey()
        {

            string NewGuid = Guid.NewGuid().ToString();
            return NewGuid;
        }
        public static string GetFileType(string FullFileName)
        {
            string[] name = FullFileName.Split(".");
            if (name.Length > 0) return "." + name[name.Length - 1];
            return "";
        }
        public static string GetFileName(string FullFileName, bool Extension = false, bool isTemp = false)
        {
            string[] name = FullFileName.Split("/");
            if (name.Length == 0) return "";
            if (isTemp)
            {
                if (Extension) return GetFileName(FullFileName,false,true) +"."+ GetFileType(FullFileName);
                else return name.Last().Split(".")[0].Substring(0, 1);
            }
            else
            {
                if (Extension) return name.Last();
                else return name.Last().Split(".")[0];
            }

        }
        public static string GetImageExtension(string UniqueKey,bool HD=false)
        {
            string WWroot = Path.GetFullPath("wwwroot");
            string FullURL = WWroot;
            if (HD==true) FullURL += @"\VehIMGUpload\" + UniqueKey + @"\HD\";
            else FullURL += @"\VehIMGUpload\" + UniqueKey + @"\";

            if (Directory.Exists(FullURL))
            {
                var Dir = new DirectoryInfo(FullURL);
                string firstFileName = Dir.GetFiles().Where(x => x.Name != "0").First().Name;
                if (firstFileName == null) return "jpeg";
                string[] FileExt = firstFileName.Split(".");
                return FileExt[1];
            }
            else
            {
                return "jpg";
            }
        }
        public static List<string> GetImagePrevCounter(string UniqueKey)
        {
            string WWroot = Path.GetFullPath("wwwroot");
            string FullURL = WWroot + @"\VehIMGUpload\" + UniqueKey + @"\";
            if (Directory.Exists(FullURL))
            {
                var ImgList = new List<string>();
                var Files = new DirectoryInfo(FullURL);
                foreach (FileInfo imgX in Files.GetFiles())
                {
                    ImgList.Add("/VehIMGUpload/" + UniqueKey + @"/" + imgX.Name);
                }
                return ImgList;
            }
            return new List<string> { "/VehIMGUpload/" + UniqueKey + @"/" };
        }

        public static void RemoveImgDir(string UniqueKey)
        {
            string WWroot = Path.GetFullPath("wwwroot");
            string MoveFullURL = WWroot + @"\VehIMGUpload\" + UniqueKey + @"\";
            if (Directory.Exists(MoveFullURL)) Directory.Delete(MoveFullURL,true);
        }

        public static string SaveImagesPermenantly(string UniqueKey)
        {
            string WWroot = Path.GetFullPath("wwwroot");
            string FullURL = WWroot + @"\TempUPL_FLD\" + UniqueKey + @"\";
            if (Directory.Exists(FullURL))
            {
                string MoveFullURL = WWroot + @"\VehIMGUpload\" + UniqueKey + @"\";
                if (!Directory.Exists(MoveFullURL)) Directory.CreateDirectory(MoveFullURL);
                if (!Directory.Exists(MoveFullURL + @"\HD")) Directory.CreateDirectory(MoveFullURL + @"\HD");//create the HD dir
                var Files = new DirectoryInfo(FullURL);
                foreach (FileInfo imgX in Files.GetFiles())
                {
                    ConvertImage(imgX.FullName, MoveFullURL, imgX.Name, 450);
                    //imgX.Delete();//Delete once converted
                }
                Directory.Delete(FullURL, true);//clean up Temp file
            } else return "Location Not Found!";
            return "Success";
        }

        public static bool ConvertImage(string sourcePath, string targetPath, string Extension, int Height)
        {
            if (!string.IsNullOrEmpty(sourcePath))
            {
                using (Image img = Image.FromFile(sourcePath))
                {
                    img.ScaleByHeight(Height)
                       .SaveAs(targetPath + Extension, 70);

                    //No Create an ADditional HD version
                    // Custom Watermark Settings
                    var tmOps = new TextWatermarkOptions
                    {
                        Location = TargetSpot.Center,
                        Margin = 5, // distance from border
                        FontSize = 80,
                        FontStyle = FontStyle.Bold,
                        TextColor = Color.FromArgb(70, Color.White), // Use alpha channel to change opacity
                        BGColor = Color.FromArgb(0, Color.Black), // set alpha to 0 to remove background
                        OutlineColor = Color.FromArgb(200, Color.Black), // Use alpha channel to change opacity
                        OutlineWidth = 0.5f // draw an outline around the text
                    };
                    img.ScaleByHeight(1080)
                        .AddTextWatermark("www.mVehAuctions.com", tmOps)
                        .SaveAs(targetPath+@"HD\\" + Extension, 70);
                }
                return true;
            }
            else return false;
        }
    }
}

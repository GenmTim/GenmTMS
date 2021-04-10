using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Data.Entity;

namespace TMS.Core.Api
{
	public class FileShardService
	{
		private static async Task UploadFileShardAsync(int shardIndex, FileInfo file)
		{

			FileStream fileStream = file.OpenRead();

			int shardSize = 5 * 1024 * 1024;//分片大小5MB

			int start = (shardIndex - 1) * shardSize;//文件分片起始位置

			int end = (int)Math.Min(file.Length, start + shardSize);//文件分片接收位置

			byte[] fileShard = new byte[end - start];//分片文件二进制流

			fileStream.Position = start;
			_ = fileStream.Read(fileShard, 0, fileShard.Length);

			int size = (int)file.Length;

			int shardTotal = (int)Math.Ceiling((double)size / shardSize);

			string fileName = file.Name;

			string suffix = fileName.Substring(fileName.LastIndexOf(".") + 1).ToLower();

			string filedetails = file.Name + file.Length + file.LastWriteTime;

			string key = GenerateMD5(filedetails);

			FileShard shard = new FileShard();
			shard.name = fileName;
			shard.suffix = suffix;
			shard.size = size;
			shard.shardIndex = shardIndex;
			shard.shardTotal = shardTotal;
			shard.shardSize = shardSize;
			shard.fileKey = key;


			ApiResponse apiResponse = await HttpService.Instance.FileUpload(shard, fileShard);
			if (apiResponse.StatusCode==200)
			{
				//上传分片成功
				if (shardIndex<shardTotal)
				{
					await UploadFileShardAsync(shardIndex + 1,file);
				}
				else
				{
					//上传完毕
				}
			}
			else
			{
				//上传失败
			}
		}

		public static async Task<string> FileUploadAsync(string filePath)
		{
			FileInfo file = new FileInfo(filePath);
			if (!file.Exists)
			{
				return "文件为空";
			}
			string filedetails = file.Name + file.Length + file.LastWriteTime;

			string key = GenerateMD5(filedetails);

			ApiResponse apiResponse = await HttpService.Instance.FileCheck(key);

			if (apiResponse.StatusCode==200)
			{
				//数据库中有记录
				FileShard shard = (FileShard)apiResponse.Data;
				if (shard.shardIndex==shard.shardTotal)
				{
					return "极速上传成功";
				}
				else
				{
					await UploadFileShardAsync(shard.shardIndex, file);
				}
			}
			else
			{
				//数据库中没有记录，新文件
				await UploadFileShardAsync(1, file);
			}
			return "上传成功";
		}

		/// <summary>
		/// MD5加密
		/// </summary>
		/// <param name="txt"></param>
		/// <returns></returns>
		public static string GenerateMD5(string txt)
		{
			using (MD5 mi = MD5.Create())
			{
				byte[] buffer = Encoding.Default.GetBytes(txt);
				//开始加密
				byte[] newBuffer = mi.ComputeHash(buffer);
				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < newBuffer.Length; i++)
				{
					sb.Append(newBuffer[i].ToString("x2"));
				}
				return sb.ToString();
			}
		}
	}
}

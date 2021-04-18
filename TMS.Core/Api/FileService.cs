using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TMS.Core.Data.Entity;

namespace TMS.Core.Api
{
    public class FileService
    {
        private ManualResetEvent resetEvent = null;

        public delegate void SendingProgress(double progress);

        public SendingProgress OnSendingProgress;

        public FileService()
        {
            this.resetEvent = new ManualResetEvent(true);
        }

        public FileService(ManualResetEvent resetEvent)
        {
            this.resetEvent = resetEvent;
        }

        private async Task<string> UploadFileShardAsync(int shardIndex, FileInfo file, CancellationTokenSource tokenSource = null)
        {
            if (tokenSource != null && tokenSource.Token.IsCancellationRequested)
            {
                return "停止";
            }
            resetEvent.WaitOne();
            FileShard shard = new FileShard();

            int shardSize = 5 * 1024 * 1024;//分片大小5MB

            int start = (shardIndex - 1) * shardSize;//文件分片起始位置

            int end = (int)Math.Min(file.Length, start + shardSize);//文件分片接收位置

            byte[] fileShard = new byte[end - start];//分片文件二进制流

            using (FileStream fileStream = file.OpenRead())
            {
                fileStream.Position = start;
                _ = fileStream.Read(fileShard, 0, fileShard.Length);

                int size = (int)file.Length;

                int shardTotal = (int)Math.Ceiling((double)size / shardSize);
                OnSendingProgress(shard.shardIndex / shard.shardTotal);
                string fileName = file.Name;

                string suffix = fileName.Substring(fileName.LastIndexOf(".") + 1).ToLower();

                string filedetails = file.Name + file.Length + file.LastWriteTime;

                string key = GenerateMD5(filedetails);


                shard.name = fileName;
                shard.suffix = suffix;
                shard.size = size;
                shard.shardIndex = shardIndex;
                shard.shardTotal = shardTotal;
                shard.shardSize = shardSize;
                shard.fileKey = key;

            }
            if (tokenSource != null && tokenSource.Token.IsCancellationRequested)
            {
                return "停止";
            }
            resetEvent.WaitOne();
            ApiResponse apiResponse = await HttpService.Instance.FileUpload(shard, fileShard);
            if (tokenSource != null && tokenSource.Token.IsCancellationRequested)
            {
                return "停止";
            }
            resetEvent.WaitOne();
            if (apiResponse.StatusCode == 200)
            {
                //上传分片成功
                if (shard.shardIndex < shard.shardTotal)
                {
                    OnSendingProgress(shard.shardIndex / shard.shardTotal);
                    return await UploadFileShardAsync(shardIndex + 1, file, tokenSource);
                }
                else
                {
                    //上传完毕
                    string data = apiResponse.Message;
                    return data;
                }
            }
            else
            {
                //上传失败
                return "上传失败";
            }
        }

        public async Task<string> FileUploadAsync(string filePath, CancellationTokenSource tokenSource = null)
        {
            if (tokenSource != null && tokenSource.Token.IsCancellationRequested)
            {
                return "停止";
            }
            resetEvent.WaitOne();
            FileInfo file = new FileInfo(filePath);
            if (!file.Exists)
            {
                return "文件为空";
            }
            string filedetails = file.Name + file.Length + file.LastWriteTime;

            string key = GenerateMD5(filedetails);

            ApiResponse apiResponse = await HttpService.Instance.FileCheck(key);
            if (tokenSource != null && tokenSource.Token.IsCancellationRequested)
            {
                return "停止";
            }
            resetEvent.WaitOne();
            if (apiResponse.StatusCode == 200)
            {
                //数据库中有记录
                FileShard shard = (FileShard)apiResponse.Data;
                if (shard.shardIndex == shard.shardTotal)
                {
                    return "极速上传成功";
                }
                else
                {
                    OnSendingProgress(shard.shardIndex / shard.shardTotal);
                    string v = await UploadFileShardAsync(shard.shardIndex, file, tokenSource);
                    string[] vs = v.Split("\"");
                    return vs[3];
                }
            }
            else
            {
                //数据库中没有记录，新文件
                string v = await UploadFileShardAsync(1, file, tokenSource);
                string[] vs = v.Split("\"");
                return vs[3];
            }
            //return "上传成功";
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

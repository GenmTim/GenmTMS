using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Api
{
	/// <summary>
	/// RestSharp Client
	/// </summary>
	public class RestSharpCertificateMethod
	{
        /// <summary>
        /// 请求数据
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="method">请求类型</param>
        /// <param name="pms">参数</param>
        /// <param name="isToken">是否Token</param>
        /// <param name="isJson">是否Json</param>
        /// <returns></returns>
        public async Task<Response> RequestBehavior<Response>(string url, Method method, string pms,
            bool isToken = true, bool isJson = true) where Response : class
        {
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(method);
            if (isToken)
            {
                client.AddDefaultHeader("token", "");
            }
            switch (method)
            {
                case Method.GET:
                    request.AddHeader("Content-Type", "application/json");
                    break;
                case Method.POST:
                    if (isJson)
                    {
                        request.AddHeader("Content-Type", "application/json");
                        request.AddJsonBody(pms);
                    }
                    else
                    {
                        request.AddHeader("Content-Type", "application/json");
                        request.AddParameter("application/x-www-form-urlencoded",
                            pms, ParameterType.RequestBody);
                    }
                    break;
                case Method.PUT:
                    if (isJson)
                    {
                        request.AddHeader("Content-Type", "application/json");
                        request.AddJsonBody(pms);
                    }
                    else
                    {
                        request.AddHeader("Content-Type", "application/json");
                        request.AddParameter("application/x-www-form-urlencoded",
                            pms, ParameterType.RequestBody);
                    }
                    break;
                case Method.DELETE:
                    if (isJson)
                    {
                        request.AddHeader("Content-Type", "application/json");
                        request.AddJsonBody(pms);
                    }
                    else
                    {
                        request.AddHeader("Content-Type", "application/json");
                        request.AddParameter("application/x-www-form-urlencoded",
                            pms, ParameterType.RequestBody);
                    }
                    break;
                default:
                    request.AddHeader("Content-Type", "application/json");
                    break;
            }
            var response = await client.ExecuteAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<Response>(response.Content);
            else
                return new BaseResponse()
                {
                    StatusCode = (int)response.StatusCode,
                    Message = response.StatusDescription ?? response.ErrorMessage
                } as Response;
        }
    }
}

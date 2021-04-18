using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMS.Core.Data.Dto;
using TMS.Core.Data.Entity;

namespace TMS.Core.Api
{
    public class HttpService
    {
        private static HttpService instance;
        public static HttpService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HttpService();
                }
                return instance;
            }
        }

        public static HttpService GetInstance()
        {
            if (instance == null)
            {
                instance = new HttpService();
            }
            return instance;
        }

        public static HttpService GetConn()
        {
            if (instance == null)
            {
                instance = new HttpService();
            }
            return instance;
        }

        private RestClient restClient;
        private string token;

        private HttpService()
        {
            restClient = new RestClient("http://47.101.157.194:8081");
        }

        private RestSharpCertificateMethod restSharp = new RestSharpCertificateMethod();

        #region 测试
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="bt"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<string> Upload(byte[] bt, string token)
        {
            var url = $"http://127.0.0.1/terminal-tenant/tenant/common/upload";

            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("token", token);
            request.AddFile("file", bt, "multipart/form-data");
            //restSharp.RequestBehavior(url, Method.POST,request.)
            IRestResponse response = await client.ExecuteAsync(request);
            var responseContent = response.Content;
            return responseContent;
        }
        #endregion

        #region 企业

        /// <summary>
        /// 获取企业信息
        /// </summary>
        /// <param name="company_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> GetCompanyInfo(int company_id)
        {
            try
            {

                RestRequest restRequest = new RestRequest("/company");
                restRequest.AddParameter("company_id", company_id);
                //var res = restClient.GetAsync(restRequest);
                restRequest.Method = Method.GET;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    CompanyDto companyDto = JsonConvert.DeserializeObject<CompanyDto>(data);
                    return new ApiResponse(200, companyDto);
                }
                else
                {
                    return new ApiResponse(201, "无效企业");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 请求我的企业列表
        /// </summary>
        /// <returns></returns>
        public async Task<ApiResponse> GetMyCompanyList()
        {
            try
            {
                RestRequest restRequest = new RestRequest("/company_role/myCompanys");
                restRequest.Method = Method.GET;

                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    List<CompanyDto> companyDto = JsonConvert.DeserializeObject<List<CompanyDto>>(data);
                    return new ApiResponse(200, companyDto);
                }
                else
                {
                    return new ApiResponse(201, "查询失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 请求我的文件树形列表
        /// </summary>
        /// <returns></returns>
        public async Task<ApiResponse> GetMyFileTreeStruct()
        {
            try
            {
                RestRequest restRequest = new RestRequest("/mybatis_plus/folder/treeFolderList");
                restRequest.Method = Method.GET;

                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    List<TreeFolder> folderTreeDto = JsonConvert.DeserializeObject<List<TreeFolder>>(data);
                    return new ApiResponse(200, folderTreeDto);
                }
                else
                {
                    return new ApiResponse(201, "查询失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 注册企业
        /// </summary>
        /// <param name="industry"></param>
        /// <param name="name"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public async Task<ApiResponse> RegisterCompany(string industry, string name, string scale)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/company");

                JObject jObject = new JObject();

                jObject.Add("industry", industry);
                jObject.Add("name", name);
                jObject.Add("scale", scale);
                restRequest.AddJsonBody(jObject.ToString());

                restRequest.Method = Method.POST;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    CompanyDto companyDto = JsonConvert.DeserializeObject<CompanyDto>(data);
                    return new ApiResponse(200, companyDto);
                }
                else
                {
                    return new ApiResponse(201, "企业注册失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 更新企业信息
        /// </summary>
        /// <param name="company_id"></param>
        /// <param name="address"></param>
        /// <param name="contacts_email">负责人邮箱</param>
        /// <param name="contacts_name">负责人名称</param>
        /// <param name="contacts_tel">负责人手机</param>
        /// <param name="country"></param>
        /// <param name="piane"></param>
        /// <param name="postcode"></param>
        /// <returns></returns>
        public async Task<ApiResponse> ChangeCompanyInfo(int company_id, string address, string contacts_email, string contacts_name, string contacts_tel, string country, string piane, string postcode)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/company");

                JObject jObject = new JObject();
                jObject.Add("company_id", company_id);
                jObject.Add("address", address);
                jObject.Add("contacts_email", contacts_email);
                jObject.Add("contacts_name", contacts_name);
                jObject.Add("contacts_tel", contacts_tel);
                jObject.Add("country", country);
                jObject.Add("piane", piane);
                jObject.Add("postcode", postcode);
                restRequest.AddJsonBody(jObject.ToString());

                restRequest.Method = Method.PUT;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "企业信息更新成功");
                }
                else
                {
                    return new ApiResponse(201, "企业信息更新失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        public Task GetUserInfo(long? userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 查询树形企业的部门
        /// </summary>
        /// <param name="company_id"></param>
        /// <returns>类型：List<TreeDept></returns>
        public async Task<ApiResponse> GetCompanyTreeDept(long company_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/company/treeDept");
                restRequest.AddParameter("company_id", company_id);
                restRequest.Method = Method.GET;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    List<TreeDept> treeDepts = JsonConvert.DeserializeObject<List<TreeDept>>(data);
                    return new ApiResponse(200, treeDepts);
                }
                else
                {
                    return new ApiResponse(201, "无效企业");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 获取企业所有员工
        /// </summary>
        /// <param name="company_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> GetCompanyUserList(int company_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/company/user_info");
                restRequest.AddParameter("company_id", company_id);
                restRequest.Method = Method.GET;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    return new ApiResponse(200, JObject.Parse(data));
                }
                else
                {
                    return new ApiResponse(201, "无效企业");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }
        #endregion

        #region 用户与企业

        /// <summary>
        /// 邀请用户加入企业
        /// </summary>
        /// <param name="company_id"></param>
        /// <param name="receiver_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> InviteUserJoinCompany(long company_id, long receiver_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/company/inviteUser");
                restRequest.AddParameter("company_id", company_id);
                restRequest.AddParameter("receiver_id", receiver_id);

                restRequest.Method = Method.POST;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    //string data = jObjects["data"].ToString();
                    //AttendanceGroupDto attendanceGroupDto = JsonConvert.DeserializeObject<AttendanceGroupDto>(data);
                    return new ApiResponse(200, "邀请成功");
                }
                else
                {
                    return new ApiResponse(201, "邀请失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 应答公司邀请
        /// </summary>
        /// <param name="company_id"></param>
        /// <param name="message_id"></param>
        /// <param name="is_agree"></param>
        /// <returns></returns>
        public async Task<ApiResponse> ReplyCompanyInvite(long company_id, long message_id, Boolean is_agree)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/company/isAgree");
                restRequest.AddParameter("company_id", company_id);
                restRequest.AddParameter("message_id", message_id);
                restRequest.AddParameter("agree", is_agree);

                restRequest.Method = Method.POST;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    //string data = jObjects["data"].ToString();
                    //AttendanceGroupDto attendanceGroupDto = JsonConvert.DeserializeObject<AttendanceGroupDto>(data);
                    return new ApiResponse(200, "成功");
                }
                else
                {
                    return new ApiResponse(201, "失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 是否已以加入公司
        /// </summary>
        /// <param name="company_id"></param>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> IsCompanyJoined(long company_id, long user_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/company/isCompanyRole");
                restRequest.AddParameter("company_id", company_id);
                restRequest.AddParameter("user_id", user_id);

                restRequest.Method = Method.GET;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    //string data = jObjects["data"].ToString();
                    //AttendanceGroupDto attendanceGroupDto = JsonConvert.DeserializeObject<AttendanceGroupDto>(data);
                    return new ApiResponse(200, "已加入公司");
                }
                else
                {
                    return new ApiResponse(201, "未加入公司");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 用户进入企业
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="name"></param>
        /// <param name="company_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> UserIntoCompany(int user_id, string name, int company_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/company_role");

                JObject jObject = new JObject();

                jObject.Add("user_id", user_id);
                jObject.Add("name", name);
                jObject.Add("company_id", company_id);
                restRequest.AddJsonBody(jObject.ToString());

                restRequest.Method = Method.POST;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    CompanyRoleDto companyRoleDto = JsonConvert.DeserializeObject<CompanyRoleDto>(data);
                    return new ApiResponse(200, companyRoleDto);
                }
                else
                {
                    return new ApiResponse(201, "用户进入企业失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 用户离开企业
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="role_id"></param>
        /// <param name="company_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> UserLeaveCompany(int user_id, int role_id, int company_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/company_role");

                JObject jObject = new JObject();

                jObject.Add("user_id", user_id);
                jObject.Add("role_id", role_id);
                jObject.Add("company_id", company_id);
                restRequest.AddJsonBody(jObject.ToString());

                restRequest.Method = Method.DELETE;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "用户成功离开企业");
                }
                else
                {
                    return new ApiResponse(201, "用户离开企业失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }
        #endregion

        #region 用户与部门

        /// <summary>
        /// 用户进入部门
        /// </summary>
        /// <param name="dept_id"></param>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> UserIntoDept(int dept_id, int user_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/bl_dept");

                JObject jObject = new JObject();

                jObject.Add("dept_id", dept_id);
                jObject.Add("user_id", user_id);
                restRequest.AddJsonBody(jObject.ToString());

                restRequest.Method = Method.POST;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "用户成功进入部门");
                }
                else
                {
                    return new ApiResponse(201, "用户进入部门失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 用户离开部门
        /// </summary>
        /// <param name="dept_id"></param>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> UserLeaveDeptV1(int dept_id, int user_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/bl_dept");
                restRequest.AddParameter("dept_id", dept_id);
                restRequest.AddParameter("user_id", user_id);

                restRequest.Method = Method.DELETE;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "用户成功离开部门");
                }
                else
                {
                    return new ApiResponse(201, "用户离开部门失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 获取部门员工信息列表
        /// </summary>
        /// <param name="dept_id"></param>
        /// <returns>需要调整指定，有公司角色名</returns>
        public async Task<ApiResponse> GetDeptUserInfoList(long dept_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/bl_dept/userDeptInfo");
                restRequest.AddParameter("dept_id", dept_id);

                restRequest.Method = Method.GET;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    List<User> users = JsonConvert.DeserializeObject<List<User>>(data);//用户基本信息
                    List<CompanyRoleDto> companyRoles = JsonConvert.DeserializeObject<List<CompanyRoleDto>>(data);//用户在公司中的角色名 debug
                    return new ApiResponse(200, users);
                }
                else
                {
                    return new ApiResponse(201, "获取部门员工失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 员工加入部门v2
        /// </summary>
        /// <param name="dept_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> UserJoinDept(int dept_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/bl_dept/v2");
                restRequest.AddParameter("dept_id", dept_id);

                restRequest.Method = Method.POST;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    //string data = jObjects["data"].ToString();
                    //List<User> users = JsonConvert.DeserializeObject<List<User>>(data);//用户基本信息
                    //List<CompanyRoleDto> companyRoles = JsonConvert.DeserializeObject<List<CompanyRoleDto>>(data);//用户在公司中的角色名 debug
                    return new ApiResponse(200, "加入部门成功");
                }
                else
                {
                    return new ApiResponse(201, "加入部门失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 员工离开部门v2
        /// </summary>
        /// <param name="dept_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> UserLeaveDept(int dept_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/bl_dept/v2");
                restRequest.AddParameter("dept_id", dept_id);

                restRequest.Method = Method.DELETE;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    //string data = jObjects["data"].ToString();
                    //List<User> users = JsonConvert.DeserializeObject<List<User>>(data);//用户基本信息
                    //List<CompanyRoleDto> companyRoles = JsonConvert.DeserializeObject<List<CompanyRoleDto>>(data);//用户在公司中的角色名 debug
                    return new ApiResponse(200, "离开部门成功");
                }
                else
                {
                    return new ApiResponse(201, "离开部门失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }
        #endregion

        #region 用户

        /// <summary>
        /// 登录用户，手机
        /// </summary>
        /// <param name="tel"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public async Task<ApiResponse> LoginUserTel(string tel, string pwd)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/user");
                if (tel != null && !tel.Equals(""))
                {
                    restRequest.AddParameter("tel", tel);
                }
                restRequest.AddParameter("pwd", pwd);

                restRequest.Method = Method.GET;
                var response = await restClient.ExecuteAsync(restRequest);

                foreach (var param in response.Headers)
                {
                    if (param.Name == "token")
                    {

                    }
                }

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    token = (string)jObjects["data"]["token"].ToString();
                    restClient.AddDefaultHeader("token", token);


                    string data = jObjects["data"]["user"].ToString();
                    User user = JsonConvert.DeserializeObject<User>(data);

                    return new ApiResponse(200, user);
                }
                else
                {
                    return new ApiResponse(201, "手机号或密码错误");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 登录用户，邮箱
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public async Task<ApiResponse> LoginUserEmail(string email, string pwd)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/user");
                if (email != null && !email.Equals(""))
                {
                    restRequest.AddParameter("email", email);
                }
                restRequest.AddParameter("pwd", pwd);

                restRequest.Method = Method.GET;
                var response = await restClient.ExecuteAsync(restRequest);

                //foreach (var param in response.Headers)
                //{
                //    if (param.Name == "token")
                //    {
                //        token = (string)param.Value;
                //        restClient.AddDefaultHeader("token", token);
                //    }
                //}

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    User user = JsonConvert.DeserializeObject<User>(data);
                    return new ApiResponse(200, user);
                }
                else
                {
                    return new ApiResponse(201, "邮箱或密码错误");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="email">邮箱</param>
        /// <param name="tel">手机号</param>
        /// <param name="password">密码</param>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public async Task<ApiResponse> RegisterUser(string email, string tel, string password, string name)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/user");

                JObject jObject = new JObject();

                jObject.Add("email", email);
                jObject.Add("name", name);
                jObject.Add("tel", tel);
                jObject.Add("password", password);
                restRequest.AddJsonBody(jObject.ToString());

                restRequest.Method = Method.POST;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    User user = JsonConvert.DeserializeObject<User>(data);
                    return new ApiResponse(201, user);
                }
                else
                {
                    return new ApiResponse(201, "注册失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="newPassword">新密码</param>
        /// <returns></returns>
        public async Task<ApiResponse> ChangeUserPassword(long userId, string newPassword)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/user");
                restRequest.AddParameter("user_id", userId);
                restRequest.AddParameter("pwd", newPassword);
                //JObject jObject = new JObject();
                //jObject.Add("user_id", userId);
                //jObject.Add("pwd", newPassword);
                //restRequest.AddJsonBody(jObject.ToString());

                restRequest.Method = Method.PUT;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "密码修改成功");
                }
                else
                {
                    return new ApiResponse(201, "密码修改失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> GetUserInfo(long user_id)
        {
            //debug
            try
            {
                RestRequest restRequest = new RestRequest("/user/allInfo");//debug
                restRequest.AddParameter("user_id", user_id);

                restRequest.Method = Method.GET;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    //debug 调整输出类
                    User user = JsonConvert.DeserializeObject<User>(data);
                    //UserDto userDto = JsonConvert.DeserializeObject<UserDto>(data);
                    //UserInfoDto userInfoDto = JsonConvert.DeserializeObject<UserInfoDto>(data);
                    //debug 两个类合并
                    return new ApiResponse(200, user);
                }
                else
                {
                    return new ApiResponse(201, "获取用户信息失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 通过手机号查询用户信息
        /// </summary>
        /// <param name="tel"></param>
        /// <returns></returns>
        public async Task<ApiResponse> GetUserInfoByTel(string tel)
        {
            //debug
            try
            {
                RestRequest restRequest = new RestRequest("/user/userInfo");//debug
                restRequest.AddParameter("tel", tel);

                restRequest.Method = Method.GET;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    //debug 调整输出类
                    User user = JsonConvert.DeserializeObject<User>(data);
                    //UserDto userDto = JsonConvert.DeserializeObject<UserDto>(data);
                    //UserInfoDto userInfoDto = JsonConvert.DeserializeObject<UserInfoDto>(data);
                    //debug 两个类合并
                    return new ApiResponse(200, user);
                }
                else
                {
                    return new ApiResponse(201, "获取用户信息失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }
        #endregion

        #region 联系人

        /// <summary>
        /// 获取联系人
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> GetContact(long user_id)
        {
            //debug
            try
            {
                RestRequest restRequest = new RestRequest("​/contacts");//debug
                restRequest.AddParameter("user_id", user_id);

                restRequest.Method = Method.GET;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    //是联系人
                    string data = jObjects["data"].ToString();
                    //debug 调整输出类
                    User user = JsonConvert.DeserializeObject<User>(data);
                    return new ApiResponse(200, user);
                }
                else
                {
                    return new ApiResponse(201, "获取联系人失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 应答联系人请求
        /// </summary>
        /// <param name="message_id"></param>
        /// <param name="is_agree"></param>
        /// <returns></returns>
        public async Task<ApiResponse> ReplyNewContact(long message_id, bool is_agree)
        {
            //debug
            try
            {
                RestRequest restRequest = new RestRequest("/contacts");//debug
                restRequest.AddParameter("message_id", message_id);
                restRequest.AddParameter("agree", is_agree);

                restRequest.Method = Method.POST;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    //成功同意
                    //string data = jObjects["data"].ToString();
                    //debug 调整输出类
                    //User user = JsonConvert.DeserializeObject<User>(data);
                    return new ApiResponse(200, "联系人处理成功");
                }
                else
                {
                    return new ApiResponse(201, "联系人处理失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 删除联系人
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="friend_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> DeleteContacter(long user_id, long friend_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/contacts");
                restRequest.AddParameter("user_id", user_id);
                restRequest.AddParameter("friend_id", friend_id);

                restRequest.Method = Method.DELETE;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "删除联系人成功");
                }
                else
                {
                    return new ApiResponse(201, "删除联系人失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 获取最近n个联系人
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public async Task<ApiResponse> GetContactsForNum(int num)
        {
            try
            {
                RestRequest restRequest = new RestRequest("​/contacts/chatContacts");
                restRequest.AddParameter("n", num);

                restRequest.Method = Method.GET;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    //成功返回数据
                    //string data = jObjects["data"].ToString();
                    JArray jArrays = (JArray)jObjects["data"];
                    List<User> userList = new List<User>();
                    foreach (var item in jArrays)
                    {
                        string v = item.ToString();
                        User user = JsonConvert.DeserializeObject<User>(v);
                        userList.Add(user);
                    }
                    return new ApiResponse(200, userList);
                }
                else
                {
                    return new ApiResponse(201, "没有获取到联系人");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 获取某个联系人的最近n条聊天记录
        /// </summary>
        /// <param name="friend_id"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public async Task<ApiResponse> GetChatRecordForNum(long friend_id, int num)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/contacts/chatRecord");
                restRequest.AddParameter("n", num);
                restRequest.AddParameter("friend_id", friend_id);

                restRequest.Method = Method.GET;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    //成功返回数据
                    //string data = jObjects["data"].ToString();
                    JArray jArrays = (JArray)jObjects["data"];
                    List<UserMessageDto> userMessageList = new List<UserMessageDto>();
                    foreach (var item in jArrays)
                    {
                        string v = item.ToString();
                        UserMessageDto userMessage = JsonConvert.DeserializeObject<UserMessageDto>(v);
                        userMessageList.Add(userMessage);
                    }
                    return new ApiResponse(200, userMessageList);
                }
                else
                {
                    return new ApiResponse(201, "没有获取到联系人聊天记录");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 判断是否为联系人
        /// </summary>
        /// <param name="friend_id"></param>
        /// <returns>返回200是联系人，201不是联系人</returns>
        public async Task<ApiResponse> IsContact(long friend_id)
        {
            //debug
            try
            {
                RestRequest restRequest = new RestRequest("​/contacts/isFriend");//debug
                restRequest.AddParameter("friend_id", friend_id);

                restRequest.Method = Method.GET;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    //是联系人
                    //string data = jObjects["data"].ToString();
                    //debug 调整输出类
                    //User user = JsonConvert.DeserializeObject<User>(data);
                    return new ApiResponse(200, "是联系人");
                }
                else
                {
                    return new ApiResponse(201, "不是联系人");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }



        /// <summary>
        /// 发起添加联系人
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="friend_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> AddNewContacter(long user_id, long friend_id)
        {
            //debug
            try
            {
                RestRequest restRequest = new RestRequest("​/contacts/requestInfo");//debug
                restRequest.AddParameter("user_id", user_id);
                restRequest.AddParameter("friend_id", friend_id);

                restRequest.Method = Method.POST;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    //成功发起添加
                    string data = jObjects["data"].ToString();
                    return new ApiResponse(200, "发起添加联系人成功");
                }
                else
                {
                    return new ApiResponse(201, "发起添加联系人失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 应答联系人请求
        /// </summary>
        /// <param name="friend_id"></param>
        /// <param name="is_agree"></param>
        /// <returns></returns>
        public async Task<ApiResponse> ReplyNewContactV2(long friend_id, bool is_agree)
        {
            //debug
            try
            {
                RestRequest restRequest = new RestRequest("​/contacts/v2");//debug
                restRequest.AddParameter("friend_id", friend_id);
                restRequest.AddParameter("is_agree", is_agree);

                restRequest.Method = Method.POST;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    //成功发起添加
                    string data = jObjects["data"].ToString();
                    return new ApiResponse(200, "联系人处理成功");
                }
                else
                {
                    return new ApiResponse(201, "联系人处理失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 发起联系人请求
        /// </summary>
        /// <param name="friend_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> AddNewContacterV2(long friend_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/contacts/v2");
                restRequest.AddParameter("friend_id", friend_id);
                restRequest.AddParameter("agree", true);

                restRequest.Method = Method.POST;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    //成功发起添加
                    return new ApiResponse(200, "发起添加联系人成功");
                }
                else
                {
                    return new ApiResponse(201, "发起添加联系人失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 获取联系人列表 debug
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns>内容类型为：List<User></returns>
        public async Task<ApiResponse> GetContacterList(long user_id)
        {
            //debug
            try
            {
                RestRequest restRequest = new RestRequest("/contacts");//debug
                restRequest.AddParameter("user_id", user_id);

                restRequest.Method = Method.GET;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    //成功
                    //string data = jObjects["data"].ToString();
                    JArray jArrays = (JArray)jObjects["data"];
                    List<User> userList = new List<User>();
                    foreach (var item in jArrays)
                    {
                        string v = item.ToString();
                        User user = JsonConvert.DeserializeObject<User>(v);
                        userList.Add(user);
                    }

                    return new ApiResponse(200, userList);
                }
                else
                {
                    return new ApiResponse(201, "获取联系人失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }
        #endregion

        #region 考勤组
        /// <summary>
        /// 获取考勤组信息
        /// </summary>
        /// <returns></returns>
        public async Task<ApiResponse> GetAttendanceInfo(long attendance_group_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/attendance_group");
                restRequest.AddParameter("attendance_group_id", attendance_group_id);

                restRequest.Method = Method.GET;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    AttendanceGroupDto attendanceGroupDto = JsonConvert.DeserializeObject<AttendanceGroupDto>(data);
                    return new ApiResponse(200, attendanceGroupDto);
                }
                else
                {
                    return new ApiResponse(201, "获取考勤组失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }


        /// <summary>
        /// 创建考勤组
        /// </summary>
        /// <param name="company_id"></param>
        /// <param name="name"></param>
        /// <param name="attendance_methods"></param>
        /// <param name="attendance_shifts"></param>
        /// <param name="attendance_users"></param>
        /// <returns></returns>
        public async Task<ApiResponse> PostAttendanceInfo(long company_id, string name, string attendance_methods, string attendance_shifts, string attendance_users)
        {

            try
            {
                RestRequest restRequest = new RestRequest("/attendance_group");

                JObject jObject = new JObject();

                jObject.Add("company_id", company_id);
                jObject.Add("name", name);
                jObject.Add("attendance_methods", attendance_methods);
                jObject.Add("attendance_shifts", attendance_shifts);
                jObject.Add("attendance_users", attendance_users);
                restRequest.AddJsonBody(jObject.ToString());

                restRequest.Method = Method.POST;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    AttendanceGroupDto attendanceGroupDto = JsonConvert.DeserializeObject<AttendanceGroupDto>(data);
                    return new ApiResponse(200, attendanceGroupDto);
                }
                else
                {
                    return new ApiResponse(201, "创建考勤组失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 更新考勤组信息
        /// </summary>
        /// <param name="attendance_group_id"></param>
        /// <param name="name"></param>
        /// <param name="attendance_methods"></param>
        /// <param name="attendance_shifts"></param>
        /// <param name="attendance_users"></param>
        /// <returns></returns>
        public async Task<ApiResponse> PutAttendanceInfo(long attendance_group_id, string name = null, string attendance_methods = null, string attendance_shifts = null, string attendance_users = null)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/attendance_group");

                JObject jObject = new JObject();

                jObject.Add("attendance_group_id", attendance_group_id);
                if (name != null)
                {
                    jObject.Add("name", name);
                }
                if (attendance_methods != null)
                {
                    jObject.Add("attendance_methods", attendance_methods);
                }
                if (attendance_shifts != null)
                {
                    jObject.Add("attendance_shifts", attendance_shifts);
                }
                if (attendance_users != null)
                {
                    jObject.Add("attendance_users", attendance_users);
                }
                restRequest.AddJsonBody(jObject.ToString());

                restRequest.Method = Method.PUT;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "更新考勤组信息成功");
                }
                else
                {
                    return new ApiResponse(201, "更新考勤组信息失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 删除考勤组
        /// </summary>
        /// <param name="attendance_group_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> DelAttendanceInfo(long attendance_group_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/attendance_group");
                restRequest.AddParameter("attendance_group_id", attendance_group_id);

                restRequest.Method = Method.DELETE;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "删除考勤组成功");
                }
                else
                {
                    return new ApiResponse(201, "删除考勤组失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }


        /// <summary>
        /// 考勤组打卡
        /// </summary>
        /// <param name="attendance_group_id"></param>
        /// <param name="user_id"></param>
        /// <param name="clock_no"></param>
        /// <param name="clock_type"></param>
        /// <returns></returns>
        public async Task<ApiResponse> PostAttendanceClockIn(long attendance_group_id, long user_id, int clock_no, int clock_type)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/attendance_group/clock");

                JObject jObject = new JObject();

                jObject.Add("attendance_group_id", attendance_group_id);
                jObject.Add("user_id", user_id);
                jObject.Add("clock_no", clock_no);
                jObject.Add("clock_type", clock_type);
                restRequest.AddJsonBody(jObject.ToString());

                restRequest.Method = Method.POST;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "打卡成功");
                }
                else
                {
                    return new ApiResponse(201, "打卡失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 修改考勤组负责人
        /// </summary>
        /// <param name="attendance_group_id"></param>
        /// <param name="newprincipal_id"></param>
        /// <param name="oldprincipal_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> PutAttendancePrin(long attendance_group_id, long newprincipal_id, long oldprincipal_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/attendance_group/principal");
                restRequest.AddParameter("attendance_group_id", attendance_group_id);
                restRequest.AddParameter("newprincipal_id", newprincipal_id);
                restRequest.AddParameter("oldprincipal_id", oldprincipal_id);

                restRequest.Method = Method.PUT;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "修改考勤组负责人成功");
                }
                else
                {
                    return new ApiResponse(201, "修改考勤组负责人失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 删除考勤组负责人
        /// </summary>
        /// <param name="attendance_group_id"></param>
        /// <param name="principal_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> DelAttendancePrin(long attendance_group_id, long principal_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/attendance_group/principal");
                restRequest.AddParameter("attendance_group_id", attendance_group_id);
                restRequest.AddParameter("principal_id", principal_id);

                restRequest.Method = Method.DELETE;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "删除考勤组负责人成功");
                }
                else
                {
                    return new ApiResponse(201, "删除考勤组负责人失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }
        #endregion

        #region 考评组
        /// <summary>
        /// 创建考评组
        /// </summary>
        /// <param name="evaluationGroupDto"></param>
        /// <returns></returns>
        public async Task<ApiResponse> PostEvaluationGroup(EvaluationGroupDto evaluationGroupDto)
        {
            try
            {
                RestRequest restRequest = new RestRequest("​/evaluationgroup");

                JObject jObject = JObject.FromObject(evaluationGroupDto);

                restRequest.AddJsonBody(jObject.ToString());

                restRequest.Method = Method.POST;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    EvaluationGroupDto evaluation = JsonConvert.DeserializeObject<EvaluationGroupDto>(data);
                    return new ApiResponse(200, evaluation);
                }
                else
                {
                    return new ApiResponse(201, "创建考评组失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 修改考评组
        /// </summary>
        /// <param name="evaluationGroupDto"></param>
        /// <returns></returns>
        public async Task<ApiResponse> PutEvaluationGroup(EvaluationGroupDto evaluationGroupDto)
        {
            try
            {
                RestRequest restRequest = new RestRequest("​/evaluationgroup");

                JObject jObject = JObject.FromObject(evaluationGroupDto);

                restRequest.AddJsonBody(jObject.ToString());

                restRequest.Method = Method.PUT;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "修改考评组成功");
                }
                else
                {
                    return new ApiResponse(201, "修改考评组失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 删除考评组
        /// </summary>
        /// <param name="evaluationgroup_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> DelEvaluationGroup(long evaluationgroup_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/evaluationgroup");

                restRequest.AddParameter("evaluationgroup_id", evaluationgroup_id);

                restRequest.Method = Method.DELETE;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "删除考评组成功");
                }
                else
                {
                    return new ApiResponse(201, "删除考评组失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 更新考评负责人
        /// </summary>
        /// <param name="evaluationGroup_id"></param>
        /// <param name="examiner_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> PutEvaluationExaminer(long evaluationGroup_id, int examiner_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("​/evaluationgroup/examiner_id");

                restRequest.AddParameter("evaluationGroup_id", evaluationGroup_id);
                restRequest.AddParameter("examiner_id", examiner_id);

                restRequest.Method = Method.PUT;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "更新考评负责人成功");
                }
                else
                {
                    return new ApiResponse(201, "更新考评负责人失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 删除考评负责人
        /// </summary>
        /// <param name="evaluationGroup_id"></param>
        /// <param name="examiner_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> DelEvaluationExaminer(int evaluationGroup_id, int examiner_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("​/evaluationgroup/examiner_id");

                restRequest.AddParameter("evaluationGroup_id", evaluationGroup_id);
                restRequest.AddParameter("examiner_id", examiner_id);

                restRequest.Method = Method.DELETE;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "删除考评负责人成功");
                }
                else
                {
                    return new ApiResponse(201, "删除考评负责人失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 更新考评审核人
        /// </summary>
        /// <param name="evaluationGroup_id"></param>
        /// <param name="auditor_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> PutEvaluationAuditor(int evaluationGroup_id, int auditor_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("​/evaluationgroup_auditor");

                restRequest.AddParameter("evaluationGroup_id", evaluationGroup_id);
                restRequest.AddParameter("auditor_id", auditor_id);

                restRequest.Method = Method.PUT;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "更新考评审核人成功");
                }
                else
                {
                    return new ApiResponse(201, "更新考评审核人失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 删除考评审核人
        /// </summary>
        /// <param name="evaluationGroup_id"></param>
        /// <param name="auditor_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> DelEvaluationAuditor(int evaluationGroup_id, int auditor_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("​/evaluationgroup_auditor");

                restRequest.AddParameter("evaluationGroup_id", evaluationGroup_id);
                restRequest.AddParameter("auditor_id", auditor_id);

                restRequest.Method = Method.DELETE;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "删除考评审核人成功");
                }
                else
                {
                    return new ApiResponse(201, "删除考评审核人失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }
        #endregion

        #region 重大事件
        /// <summary>
        /// 获取荣耀表信息
        /// </summary>
        /// <param name="honour_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> GetHonourInfo(int honour_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/honour");

                restRequest.AddParameter("honour_id", honour_id);

                restRequest.Method = Method.GET;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    HonourDto honourDto = JsonConvert.DeserializeObject<HonourDto>(data);
                    return new ApiResponse(200, honourDto);
                }
                else
                {
                    return new ApiResponse(201, "查询荣耀失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 创建荣耀记录
        /// </summary>
        /// <param name="honourDto"></param>
        /// <returns></returns>
        public async Task<ApiResponse> PostHonour(HonourDto honourDto)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/honour");

                JObject jObject = JObject.FromObject(honourDto);

                restRequest.AddJsonBody(jObject.ToString());

                restRequest.Method = Method.POST;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    HonourDto honourDto1 = JsonConvert.DeserializeObject<HonourDto>(data);
                    return new ApiResponse(200, honourDto1);
                }
                else
                {
                    return new ApiResponse(201, "创建荣耀失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 更新荣耀记录
        /// </summary>
        /// <param name="honourDto"></param>
        /// <returns></returns>
        public async Task<ApiResponse> PutHonour(HonourDto honourDto)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/honour");

                JObject jObject = JObject.FromObject(honourDto);

                restRequest.AddJsonBody(jObject.ToString());

                restRequest.Method = Method.PUT;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "更新荣耀成功");
                }
                else
                {
                    return new ApiResponse(201, "更新荣耀失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 删除荣耀记录
        /// </summary>
        /// <param name="honourDto"></param>
        /// <returns></returns>
        public async Task<ApiResponse> DelHonour(int honour_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/honour");

                restRequest.AddParameter("honour_id", honour_id);

                restRequest.Method = Method.DELETE;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "删除荣耀成功");
                }
                else
                {
                    return new ApiResponse(201, "删除荣耀失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }


        /// <summary>
        /// 获取违纪表信息
        /// </summary>
        /// <param name="honour_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> GetDiscipineInfo(int discipline_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/discipine");

                restRequest.AddParameter("discipline_id", discipline_id);

                restRequest.Method = Method.GET;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    DisciplineDto disciplineDto = JsonConvert.DeserializeObject<DisciplineDto>(data);
                    return new ApiResponse(200, disciplineDto);
                }
                else
                {
                    return new ApiResponse(201, "查询违纪失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 创建违纪
        /// </summary>
        /// <param name="honourDto"></param>
        /// <returns></returns>
        public async Task<ApiResponse> PostDiscipine(DisciplineDto disciplineDto)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/discipine");

                JObject jObject = JObject.FromObject(disciplineDto);

                restRequest.AddJsonBody(jObject.ToString());

                restRequest.Method = Method.POST;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    DisciplineDto disciplineDto1 = JsonConvert.DeserializeObject<DisciplineDto>(data);
                    return new ApiResponse(200, disciplineDto1);
                }
                else
                {
                    return new ApiResponse(201, "创建违纪失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 更新违纪记录
        /// </summary>
        /// <param name="honourDto"></param>
        /// <returns></returns>
        public async Task<ApiResponse> PutDiscipine(DisciplineDto disciplineDto)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/discipine");

                JObject jObject = JObject.FromObject(disciplineDto);

                restRequest.AddJsonBody(jObject.ToString());

                restRequest.Method = Method.PUT;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "更新违纪成功");
                }
                else
                {
                    return new ApiResponse(201, "更新违纪失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 删除违纪记录
        /// </summary>
        /// <param name="honourDto"></param>
        /// <returns></returns>
        public async Task<ApiResponse> DelDiscipine(int discipline_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/discipine");

                restRequest.AddParameter("discipline_id", discipline_id);

                restRequest.Method = Method.DELETE;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "删除违纪成功");
                }
                else
                {
                    return new ApiResponse(201, "删除违纪失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }
        #endregion

        #region 部门
        /// <summary>
        /// 新建部门
        /// </summary>
        /// <param name="company_id"></param>
        /// <param name="name"></param>
        /// <param name="parent_dept"></param>
        /// <returns></returns>
        public async Task<ApiResponse> PostDept(int company_id, string name, int parent_dept = -1)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/dept");

                JObject jObject = new JObject();

                jObject.Add("company_id", company_id);
                jObject.Add("name", name);
                if (parent_dept != -1)
                {
                    jObject.Add("parent_dept", parent_dept);
                }
                restRequest.AddJsonBody(jObject.ToString());

                restRequest.Method = Method.POST;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    DeptDto deptDto = JsonConvert.DeserializeObject<DeptDto>(data);
                    return new ApiResponse(200, deptDto);
                }
                else
                {
                    return new ApiResponse(201, "新建部门失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 修改部门名称
        /// </summary>
        /// <param name="dept_id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<ApiResponse> PutDept(int dept_id, string name)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/dept");
                restRequest.AddParameter("dept_id", dept_id);
                restRequest.AddParameter("name", name);
                //JObject jObject = new JObject();
                //jObject.Add("user_id", userId);
                //jObject.Add("pwd", newPassword);
                //restRequest.AddJsonBody(jObject.ToString());

                restRequest.Method = Method.PUT;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "成功修改部门名称");
                }
                else
                {
                    return new ApiResponse(201, "修改部门名称失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="company_id"></param>
        /// <param name="dept_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> DelDept(int company_id, int dept_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/dept");
                restRequest.AddParameter("dept_id", dept_id);
                restRequest.AddParameter("company_id", company_id);
                //JObject jObject = new JObject();
                //jObject.Add("user_id", userId);
                //jObject.Add("pwd", newPassword);
                //restRequest.AddJsonBody(jObject.ToString());

                restRequest.Method = Method.DELETE;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "删除部门成功");
                }
                else
                {
                    return new ApiResponse(201, "删除部门失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }
        #endregion

        #region 文件夹
        /// <summary>
        /// 获取文件夹
        /// </summary>
        /// <param name="folder_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> GetFolder(int folder_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/folder");//修改为链接

                restRequest.AddParameter("folder_id", folder_id);//修改为索引id

                restRequest.Method = Method.GET;//请求方式
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    FolderDto folderDto = JsonConvert.DeserializeObject<FolderDto>(data);
                    return new ApiResponse(200, folderDto);
                }
                else
                {
                    return new ApiResponse(201, "查询文件夹失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 新建文件夹
        /// </summary>
        /// <param name="folderDto"></param>
        /// <returns></returns>
        public async Task<ApiResponse> PostFolder(FolderDto folderDto)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/mybatis_plus/folder");

                JObject jObject = JObject.FromObject(folderDto);
                restRequest.AddParameter("name", folderDto.Name);
                restRequest.AddParameter("parentFolder", folderDto.ParentFolder);

                restRequest.Method = Method.POST;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "新建成功");
                }
                else
                {
                    return new ApiResponse(201, "新建文件夹失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 更新文件夹
        /// </summary>
        /// <param name="folderDto"></param>
        /// <returns></returns>
        public async Task<ApiResponse> PutFolder(FolderDto folderDto)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/folder");

                JObject jObject = JObject.FromObject(folderDto);

                restRequest.AddJsonBody(jObject.ToString());

                restRequest.Method = Method.POST;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "修改文件夹成功");
                }
                else
                {
                    return new ApiResponse(201, "修改文件夹失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="folder_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> DelFolder(int folder_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/folder");
                restRequest.AddParameter("folder_id", folder_id);

                restRequest.Method = Method.DELETE;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "删除文件夹成功");
                }
                else
                {
                    return new ApiResponse(201, "删除文件夹失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }
        #endregion

        #region 文件夹权限
        /// <summary>
        /// 获取文件夹权限
        /// </summary>
        /// <param name="permission_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> GetFolderPermission(int permission_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/folder_permission");//修改为链接

                restRequest.AddParameter("permission_id", permission_id);//修改为索引id

                restRequest.Method = Method.GET;//请求方式
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    FolderPermissionDto folderPermissionDto = JsonConvert.DeserializeObject<FolderPermissionDto>(data);
                    return new ApiResponse(200, folderPermissionDto);
                }
                else
                {
                    return new ApiResponse(201, "查询文件夹权限失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 新建文件夹权限
        /// </summary>
        /// <param name="folderPermissionDto"></param>
        /// <returns></returns>
        public async Task<ApiResponse> PostFolderPermission(FolderPermissionDto folderPermissionDto)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/folder_permission");

                JObject jObject = JObject.FromObject(folderPermissionDto);

                restRequest.AddJsonBody(jObject.ToString());

                restRequest.Method = Method.POST;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    FolderPermissionDto folderPermissionDto1 = JsonConvert.DeserializeObject<FolderPermissionDto>(data);
                    return new ApiResponse(200, folderPermissionDto1);
                }
                else
                {
                    return new ApiResponse(201, "新建文件夹权限失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 更新文件夹权限
        /// </summary>
        /// <param name="folderPermissionDto"></param>
        /// <returns></returns>
        public async Task<ApiResponse> PutFolderPermission(FolderPermissionDto folderPermissionDto)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/folder_permission");

                JObject jObject = JObject.FromObject(folderPermissionDto);

                restRequest.AddJsonBody(jObject.ToString());

                restRequest.Method = Method.POST;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "修改文件夹权限成功");
                }
                else
                {
                    return new ApiResponse(201, "修改文件夹权限失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 删除文件夹权限
        /// </summary>
        /// <param name="permission_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> DelFolderPermission(int permission_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/folder_permission");
                restRequest.AddParameter("permission_id", permission_id);

                restRequest.Method = Method.DELETE;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "删除文件夹权限成功");
                }
                else
                {
                    return new ApiResponse(201, "删除文件夹权限失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }
        #endregion

        #region 用户权限文件夹
        /// <summary>
        /// 获取用户文件夹权限
        /// </summary>
        /// <param name="id)"></param>
        /// <returns></returns>
        public async Task<ApiResponse> GetUserFolderPermission(int id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/user_folder_permission");//修改为链接

                restRequest.AddParameter("id", id);//修改为索引id

                restRequest.Method = Method.GET;//请求方式
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    UserFolderPermissionDto userFolderPermissionDto = JsonConvert.DeserializeObject<UserFolderPermissionDto>(data);
                    return new ApiResponse(200, userFolderPermissionDto);
                }
                else
                {
                    return new ApiResponse(201, "查询用户文件夹权限失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 新建用户文件夹权限
        /// </summary>
        /// <param name="userFolderPermissionDto"></param>
        /// <returns></returns>
        public async Task<ApiResponse> PostUserFolderPermission(UserFolderPermissionDto userFolderPermissionDto)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/user_folder_permission");

                JObject jObject = JObject.FromObject(userFolderPermissionDto);

                restRequest.AddJsonBody(jObject.ToString());

                restRequest.Method = Method.POST;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    UserFolderPermissionDto userFolderPermissionDto1 = JsonConvert.DeserializeObject<UserFolderPermissionDto>(data);
                    return new ApiResponse(200, userFolderPermissionDto1);
                }
                else
                {
                    return new ApiResponse(201, "新建用户文件夹权限失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 更新用户文件夹权限
        /// </summary>
        /// <param name="userFolderPermissionDto"></param>
        /// <returns></returns>
        public async Task<ApiResponse> PutUserFolderPermission(UserFolderPermissionDto userFolderPermissionDto)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/user_folder_permission");

                JObject jObject = JObject.FromObject(userFolderPermissionDto);

                restRequest.AddJsonBody(jObject.ToString());

                restRequest.Method = Method.POST;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "修改用户文件夹权限成功");
                }
                else
                {
                    return new ApiResponse(201, "修改用户文件夹权限失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 删除用户文件夹权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> DelUserFolderPermission(int id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/user_folder_permission");
                restRequest.AddParameter("id", id);

                restRequest.Method = Method.DELETE;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "删除用户文件夹权限成功");
                }
                else
                {
                    return new ApiResponse(201, "删除用户文件夹权限失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }
        #endregion

        #region 文件

        /// <summary>
        /// 上传文件分片
        /// </summary>
        /// <param name="shard"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<ApiResponse> FileUpload(FileShard shard, byte[] file)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/mybatis_plus/file/upload");
                restRequest.AddParameter("key", shard.fileKey);
                restRequest.AddParameter("shardIndex", shard.shardIndex);
                restRequest.AddParameter("shardSize", shard.shardSize);
                restRequest.AddParameter("shardTotal", shard.shardTotal);
                restRequest.AddParameter("size", shard.size);
                restRequest.AddParameter("suffix", shard.suffix);
                //restRequest.
                restRequest.AddFileBytes("file", file, shard.name);
                //restRequest.AddParameter("file",file, "multipart/form-data", ParameterType.RequestBody);
                restRequest.Method = Method.POST;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    return new ApiResponse(200, data);
                }
                else
                {
                    return new ApiResponse(201, "文件上传失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 检查文件是否数据库有记录
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<ApiResponse> FileCheck(string key)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/mybatis_plus/file/check");
                restRequest.AddParameter("key", key);
                restRequest.Method = Method.GET;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    FileShard fileShard = JsonConvert.DeserializeObject<FileShard>(data);
                    return new ApiResponse(200, fileShard);
                }
                else
                {
                    return new ApiResponse(201, "没有key，可以直接添加");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 获取文件
        /// </summary>
        /// <param name="file_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> GetFile(int file_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/file");//修改为链接

                restRequest.AddParameter("file_id", file_id);//修改为索引id

                restRequest.Method = Method.GET;//请求方式
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    FileDto fileDto = JsonConvert.DeserializeObject<FileDto>(data);
                    return new ApiResponse(200, fileDto);
                }
                else
                {
                    return new ApiResponse(201, "查询文件失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 新建文件
        /// </summary>
        /// <param name="fileDto"></param>
        /// <returns></returns>
        public async Task<ApiResponse> PostFile(FileDto fileDto)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/file");

                JObject jObject = JObject.FromObject(fileDto);

                restRequest.AddJsonBody(jObject.ToString());

                restRequest.Method = Method.POST;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    FileDto fileDto1 = JsonConvert.DeserializeObject<FileDto>(data);
                    return new ApiResponse(200, fileDto1);
                }
                else
                {
                    return new ApiResponse(201, "新建文件失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 更新文件
        /// </summary>
        /// <param name="fileDto"></param>
        /// <returns></returns>
        public async Task<ApiResponse> PutFile(FileDto fileDto)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/file");

                JObject jObject = JObject.FromObject(fileDto);

                restRequest.AddJsonBody(jObject.ToString());

                restRequest.Method = Method.POST;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "修改文件成功");
                }
                else
                {
                    return new ApiResponse(201, "修改文件失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="file_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> DelFile(int file_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/file");
                restRequest.AddParameter("file_id", file_id);

                restRequest.Method = Method.DELETE;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "删除文件成功");
                }
                else
                {
                    return new ApiResponse(201, "删除文件失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }
        #endregion

        //---------------------------------------------样例

        public async Task<ApiResponse> GetDataBase(int id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/discipine");//修改为链接

                restRequest.AddParameter("discipline_id", id);//修改为索引id

                restRequest.Method = Method.GET;//请求方式
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    DisciplineDto disciplineDto = JsonConvert.DeserializeObject<DisciplineDto>(data);
                    return new ApiResponse(200, disciplineDto);
                }
                else
                {
                    return new ApiResponse(201, "查询违纪失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        public async Task<ApiResponse> PostDataBase(FolderDto folderDto)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/dept");

                JObject jObject = JObject.FromObject(folderDto);

                restRequest.AddJsonBody(jObject.ToString());

                restRequest.Method = Method.POST;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    DeptDto deptDto = JsonConvert.DeserializeObject<DeptDto>(data);
                    return new ApiResponse(200, deptDto);
                }
                else
                {
                    return new ApiResponse(201, "新建部门失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        public async Task<ApiResponse> PutDataBase(FolderDto folderDto)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/dept");

                JObject jObject = JObject.FromObject(folderDto);

                restRequest.AddJsonBody(jObject.ToString());

                restRequest.Method = Method.POST;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "新建部门成功");
                }
                else
                {
                    return new ApiResponse(201, "新建部门失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }

        public async Task<ApiResponse> DelDataBase(int company_id, int dept_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("/dept");
                restRequest.AddParameter("dept_id", dept_id);
                restRequest.AddParameter("company_id", company_id);

                restRequest.Method = Method.DELETE;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    return new ApiResponse(200, "删除部门成功");
                }
                else
                {
                    return new ApiResponse(201, "删除部门失败");
                }
            }
            catch (Exception)
            {
                return new ApiResponse(-1, "程序异常");
            }
        }
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Threading.Tasks;
using TMS.Core.Data.Dto;

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

        private HttpService()
        {
            restClient = new RestClient("http://47.101.157.194:8081");
        }

        private RestSharpCertificateMethod restSharp = new RestSharpCertificateMethod();

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


        /// <summary>
        /// 获取企业所有员工
        /// </summary>
        /// <param name="company_id"></param>
        /// <returns></returns>
        public async Task<ApiResponse> GetCompanyUserList(int company_id)
        {
            try
            {
                RestRequest restRequest = new RestRequest("​/company/userList");
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
        public async Task<ApiResponse> UserLeaveDept(int dept_id, int user_id)
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

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    UserDto userDto = JsonConvert.DeserializeObject<UserDto>(data);
                    return new ApiResponse(200, userDto);
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

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    UserDto userDto = JsonConvert.DeserializeObject<UserDto>(data);
                    return new ApiResponse(200, userDto);
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
                    UserDto userDto = JsonConvert.DeserializeObject<UserDto>(data);
                    return new ApiResponse(201, userDto);
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
        public async Task<ApiResponse> ChangeUserPassword(int userId, string newPassword)
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
        /// 获取考勤组信息
        /// </summary>
        /// <returns></returns>
        public async Task<ApiResponse> GetAttendanceInfo(int attendance_group_id)
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
        public async Task<ApiResponse> PostAttendanceInfo(int company_id, string name, string attendance_methods, string attendance_shifts, string attendance_users)
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
        public async Task<ApiResponse> PutAttendanceInfo(int attendance_group_id, string name = null, string attendance_methods = null, string attendance_shifts = null, string attendance_users = null)
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
        public async Task<ApiResponse> DelAttendanceInfo(int attendance_group_id)
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
        public async Task<ApiResponse> PostAttendanceClockIn(int attendance_group_id, int user_id, int clock_no, int clock_type)
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
        public async Task<ApiResponse> PutAttendancePrin(int attendance_group_id, int newprincipal_id, int oldprincipal_id)
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
        public async Task<ApiResponse> DelAttendancePrin(int attendance_group_id, int principal_id)
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
        public async Task<ApiResponse> DelEvaluationGroup(int evaluationgroup_id)
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
        public async Task<ApiResponse> PutEvaluationExaminer(int evaluationGroup_id, int examiner_id)
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

        //------------------------------新增

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
                RestRequest restRequest = new RestRequest("/folder");

                JObject jObject = JObject.FromObject(folderDto);

                restRequest.AddJsonBody(jObject.ToString());

                restRequest.Method = Method.POST;
                var response = await restClient.ExecuteAsync(restRequest);

                JObject jObjects = JObject.Parse(response.Content);
                string code = jObjects["code"].ToString();

                if (code.Equals("0000"))
                {
                    string data = jObjects["data"].ToString();
                    FolderDto folderDto1 = JsonConvert.DeserializeObject<FolderDto>(data);
                    return new ApiResponse(200, folderDto1);
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

using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Api
{
	public class HttpClient
	{
		private RestClient restClient;

		public HttpClient()
		{
			restClient = new RestClient("http://47.101.157.194:8081");
		}


		/// <summary>
		/// 注册用户
		/// </summary>
		/// <param name="email">邮箱</param>
		/// <param name="tel">手机号</param>
		/// <param name="password">密码</param>
		/// <param name="name">名称</param>
		/// <returns>返回用户id</returns>
		public int PostUser(string email, string tel, string password, string name)
		{
			RestRequest restRequest = new RestRequest("/User");

			JObject jObject = new JObject();

			jObject.Add("email", email);
			jObject.Add("name", name);
			jObject.Add("tel", tel);
			jObject.Add("password", password);
			restRequest.AddJsonBody(jObject.ToString());

			var response = restClient.Post(restRequest);

			Console.WriteLine(response.Content);
			return int.Parse(response.Content);
		}

		/// <summary>
		/// 修改用户密码
		/// </summary>
		/// <param name="userId">用户id</param>
		/// <param name="newPassword">新密码</param>
		/// <returns></returns>
		public bool PutUserPassword(int userId, string newPassword)
		{
			RestRequest restRequest = new RestRequest("/User");
			restRequest.AddParameter("user_id", userId);
			restRequest.AddParameter("pwd", newPassword);
			//JObject jObject = new JObject();
			//jObject.Add("user_id", userId);
			//jObject.Add("pwd", newPassword);
			//restRequest.AddJsonBody(jObject.ToString());

			var response = restClient.Put(restRequest);

			Console.WriteLine(response.Content);

			return false;//debug
		}

		/// <summary>
		/// 登录用户，手机邮箱2选1
		/// </summary>
		/// <param name="pwd"></param>
		/// <param name="tel"></param>
		/// <param name="email"></param>
		/// <returns>用户id</returns>
		public int GetUserLogin(string pwd, string tel = "", string email = "")
		{
			RestRequest restRequest = new RestRequest("/User/login");
			if (tel != null && !tel.Equals(""))
			{
				restRequest.AddParameter("tel", tel);
			}
			else if (email != null && !email.Equals(""))
			{
				restRequest.AddParameter("email", email);
			}
			restRequest.AddParameter("pwd", pwd);

			var response = restClient.Get(restRequest);

			Console.WriteLine(response.Content);

			return int.Parse(response.Content);
		}

		/// <summary>
		/// 获取企业信息
		/// </summary>
		/// <param name="company_id"></param>
		/// <returns>Json对象</returns>
		public JObject GetCompany(int company_id)
		{
			RestRequest restRequest = new RestRequest("/Company");
			restRequest.AddParameter("company_id", company_id);
			var response = restClient.Get(restRequest);
			Console.WriteLine(response.Content);
			return JObject.Parse(response.Content);
		}


		/// <summary>
		/// 注册企业
		/// </summary>
		/// <param name="industry"></param>
		/// <param name="name"></param>
		/// <param name="scale"></param>
		/// <returns>企业id</returns>
		public int PostCompany(string industry, string name, string scale)
		{
			RestRequest restRequest = new RestRequest("/Company");

			JObject jObject = new JObject();

			jObject.Add("industry", industry);
			jObject.Add("name", name);
			jObject.Add("scale", scale);
			restRequest.AddJsonBody(jObject.ToString());

			var response = restClient.Post(restRequest);
			Console.WriteLine(response.Content);
			return int.Parse(response.Content);
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
		/// <returns>是否成功</returns>
		public bool PutCompany(int company_id, string address, string contacts_email, string contacts_name, string contacts_tel, string country, string piane, string postcode)
		{
			RestRequest restRequest = new RestRequest("/Company");

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

			var response = restClient.Put(restRequest);
			Console.WriteLine(response.Content);
			return false;//debug
		}

		/// <summary>
		/// 新建部门
		/// </summary>
		/// <param name="company_id"></param>
		/// <param name="name"></param>
		/// <param name="parent_dept"></param>
		/// <returns>部门id</returns>
		public int PostDept(int company_id, string name, int parent_dept = -1)
		{
			RestRequest restRequest = new RestRequest("/Dept");

			JObject jObject = new JObject();

			jObject.Add("company_id", company_id);
			jObject.Add("name", name);
			if (parent_dept != -1)
			{
				jObject.Add("parent_dept", parent_dept);
			}
			restRequest.AddJsonBody(jObject.ToString());

			var response = restClient.Post(restRequest);
			Console.WriteLine(response.Content);
			return int.Parse(response.Content);

		}

		/// <summary>
		/// 修改部门名称
		/// </summary>
		/// <param name="dept_id"></param>
		/// <param name="name"></param>
		/// <returns>是否成功</returns>
		public bool PutDept(int dept_id, string name)
		{
			RestRequest restRequest = new RestRequest("/Dept");
			restRequest.AddParameter("dept_id", dept_id);
			restRequest.AddParameter("name", name);
			//JObject jObject = new JObject();
			//jObject.Add("user_id", userId);
			//jObject.Add("pwd", newPassword);
			//restRequest.AddJsonBody(jObject.ToString());

			var response = restClient.Put(restRequest);

			Console.WriteLine(response.Content);

			return false;//debug
		}

		/// <summary>
		/// 删除部门
		/// </summary>
		/// <param name="company_id"></param>
		/// <param name="dept_id"></param>
		/// <returns>是否成功</returns>
		public bool DelDept(int company_id, int dept_id)
		{
			RestRequest restRequest = new RestRequest("/Dept");
			restRequest.AddParameter("dept_id", dept_id);
			restRequest.AddParameter("company_id", company_id);
			//JObject jObject = new JObject();
			//jObject.Add("user_id", userId);
			//jObject.Add("pwd", newPassword);
			//restRequest.AddJsonBody(jObject.ToString());

			var response = restClient.Delete(restRequest);

			Console.WriteLine(response.Content);

			return false;//debug
		}

		/// <summary>
		/// 用户进入部门
		/// </summary>
		/// <param name="dept_id"></param>
		/// <param name="user_id"></param>
		public void PostUserIntoDept(int dept_id, int user_id)
		{
			RestRequest restRequest = new RestRequest("/bl_dept");

			JObject jObject = new JObject();

			jObject.Add("dept_id", dept_id);
			jObject.Add("user_id", user_id);
			restRequest.AddJsonBody(jObject.ToString());

			var response = restClient.Post(restRequest);
			Console.WriteLine(response.Content);
		}

		/// <summary>
		/// 用户离开部门
		/// </summary>
		/// <param name="dept_id"></param>
		/// <param name="user_id"></param>
		/// <returns></returns>
		public bool DelUserLeaveDept(int dept_id, int user_id)
		{
			RestRequest restRequest = new RestRequest("/bl_dept");
			restRequest.AddParameter("dept_id", dept_id);
			restRequest.AddParameter("user_id", user_id);

			var response = restClient.Delete(restRequest);
			Console.WriteLine(response.Content);

			return false;//debug
		}

		/// <summary>
		/// 用户进入企业
		/// </summary>
		/// <param name="user_id"></param>
		/// <param name="name"></param>
		/// <param name="company_id"></param>
		/// <returns>角色id</returns>
		public int PostUserIntoCompany(int user_id, string name, int company_id)
		{
			RestRequest restRequest = new RestRequest("/company_role");

			JObject jObject = new JObject();

			jObject.Add("user_id", user_id);
			jObject.Add("name", name);
			jObject.Add("company_id", company_id);
			restRequest.AddJsonBody(jObject.ToString());

			var response = restClient.Post(restRequest);
			Console.WriteLine(response.Content);

			return int.Parse(response.Content);
		}

		/// <summary>
		/// 用户离开企业
		/// </summary>
		/// <param name="user_id"></param>
		/// <param name="role_id"></param>
		/// <param name="company_id"></param>
		/// <returns>是否成功</returns>
		public bool DelUserIntoCompany(int user_id, int role_id, int company_id)
		{
			RestRequest restRequest = new RestRequest("/company_role");

			JObject jObject = new JObject();

			jObject.Add("user_id", user_id);
			jObject.Add("role_id", role_id);
			jObject.Add("company_id", company_id);
			restRequest.AddJsonBody(jObject.ToString());

			var response = restClient.Delete(restRequest);
			Console.WriteLine(response.Content);

			return false;//debug
		}

		/// <summary>
		/// 获取考勤组信息
		/// </summary>
		/// <returns></returns>
		public string GetAttendanceInfo(int attendance_group_id)
		{
			RestRequest restRequest = new RestRequest("/attendance_group");
			restRequest.AddParameter("attendance_group_id", attendance_group_id);

			var response = restClient.Get(restRequest);
			Console.WriteLine(response.Content);

			return response.Content;
		}

		/// <summary>
		/// 创建考勤组
		/// </summary>
		/// <param name="company_id"></param>
		/// <param name="name"></param>
		/// <param name="attendance_methods"></param>
		/// <param name="attendance_shifts"></param>
		/// <param name="attendance_users"></param>
		/// <returns>考勤组id</returns>
		public int PostAttendanceInfo(int company_id, string name, string attendance_methods, string attendance_shifts, string attendance_users)
		{
			RestRequest restRequest = new RestRequest("/attendance_group");

			JObject jObject = new JObject();

			jObject.Add("company_id", company_id);
			jObject.Add("name", name);
			jObject.Add("attendance_methods", attendance_methods);
			jObject.Add("attendance_shifts", attendance_shifts);
			jObject.Add("attendance_users", attendance_users);
			restRequest.AddJsonBody(jObject.ToString());

			var response = restClient.Post(restRequest);
			Console.WriteLine(response.Content);

			return int.Parse(response.Content);
		}

		/// <summary>
		/// 更新考勤组信息
		/// </summary>
		/// <param name="attendance_group_id"></param>
		/// <param name="name"></param>
		/// <param name="attendance_methods"></param>
		/// <param name="attendance_shifts"></param>
		/// <param name="attendance_users"></param>
		/// <returns>是否成功</returns>
		public bool PutAttendanceInfo(int attendance_group_id, string name = null, string attendance_methods = null, string attendance_shifts = null, string attendance_users = null)
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

			var response = restClient.Put(restRequest);
			Console.WriteLine(response.Content);

			return false;//debug
		}

		/// <summary>
		/// 删除考勤组
		/// </summary>
		/// <param name="attendance_group_id"></param>
		/// <returns>是否成功</returns>
		public bool DelAttendanceInfo(int attendance_group_id)
		{
			RestRequest restRequest = new RestRequest("/attendance_group");
			restRequest.AddParameter("attendance_group_id", attendance_group_id);

			var response = restClient.Delete(restRequest);
			Console.WriteLine(response.Content);

			return false;//debug
		}

		/// <summary>
		/// 考勤组打卡
		/// </summary>
		/// <param name="attendance_group_id"></param>
		/// <param name="user_id"></param>
		/// <param name="clock_no"></param>
		/// <param name="clock_type"></param>
		/// <returns>是否成功</returns>
		public bool PostAttendanceClockIn(int attendance_group_id, int user_id, int clock_no, int clock_type)
		{
			RestRequest restRequest = new RestRequest("/attendance_group/clockIn");

			JObject jObject = new JObject();

			jObject.Add("attendance_group_id", attendance_group_id);
			jObject.Add("user_id", user_id);
			jObject.Add("clock_no", clock_no);
			jObject.Add("clock_type", clock_type);
			restRequest.AddJsonBody(jObject.ToString());

			var response = restClient.Post(restRequest);
			Console.WriteLine(response.Content);

			return false;//debug
		}

		/// <summary>
		/// debug 不懂
		/// </summary>
		/// <param name="attendance_group_id"></param>
		/// <param name="principal_id"></param>
		/// <returns>是否成功</returns>
		public bool DelAttendancePrin(int attendance_group_id, int principal_id)
		{
			RestRequest restRequest = new RestRequest("/attendance_group/delprin");
			restRequest.AddParameter("attendance_group_id", attendance_group_id);
			restRequest.AddParameter("principal_id", principal_id);

			var response = restClient.Delete(restRequest);
			Console.WriteLine(response.Content);

			return false;//debug
		}

		/// <summary>
		/// debug 修改考勤组负责人
		/// </summary>
		/// <param name="attendance_group_id"></param>
		/// <param name="newprincipal_id"></param>
		/// <param name="oldprincipal_id"></param>
		/// <returns>是否成功</returns>
		public bool PutAttendancePrin(int attendance_group_id, int newprincipal_id, int oldprincipal_id)
		{
			RestRequest restRequest = new RestRequest("/attendance_group/upPrin");
			restRequest.AddParameter("attendance_group_id", attendance_group_id);
			restRequest.AddParameter("newprincipal_id", newprincipal_id);
			restRequest.AddParameter("oldprincipal_id", oldprincipal_id);

			var response = restClient.Put(restRequest);
			Console.WriteLine(response.Content);

			return false;//debug
		}
	}
}

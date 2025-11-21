using System;
using System.Text.RegularExpressions;
using System.Configuration; // for ConfigurationManager
using System.Data;
using MySql.Data.MySqlClient;

namespace StudentManagementSystem
{
    public static class Tools
    {
        // 校验学号是否唯一
        public static bool IsStudentIdUnique(string studentId, SqlHelper sqlHelper)
        {
            string query = "SELECT COUNT(*) FROM student WHERE StudentId = @StudentId";
            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@StudentId", studentId)
            };
            int count = Convert.ToInt32(sqlHelper.ExecuteQuery(query, parameters).Rows[0][0]);
            return count == 0;
        }

        // 校验必填字段
        public static bool ValidateRequiredFields(Student student, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(student.StudentId))
            {
                errorMessage = "学号不能为空。";
                return false;
            }
            if (string.IsNullOrWhiteSpace(student.Name))
            {
                errorMessage = "姓名不能为空。";
                return false;
            }
            if (string.IsNullOrWhiteSpace(student.Gender))
            {
                errorMessage = "性别不能为空。";
                return false;
            }
            errorMessage = null;
            return true;
        }

        // 校验联系方式格式
        public static bool ValidateContactInfo(string phone, string email, out string errorMessage)
        {
            if (!string.IsNullOrWhiteSpace(phone) && !Regex.IsMatch(phone, @"^\d{11}$"))
            {
                errorMessage = "手机号格式不正确，应为11位数字。";
                return false;
            }
            if (!string.IsNullOrWhiteSpace(email) && !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errorMessage = "邮箱格式不正确。";
                return false;
            }
            errorMessage = null;
            return true;
        }

        // 新增：获取连接字符串（供其它窗体使用，避免重复代码）
        public static string GetConnectionString()
        {
            var settings = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            if (settings == null || string.IsNullOrWhiteSpace(settings.ConnectionString))
                throw new InvalidOperationException("App.config 中未找到名为 'DefaultConnection' 的连接字符串或其值为空。");
            return settings.ConnectionString;
        }

        // 新增：构建学生查询 SQL（支持按学号精确、姓名精确/模糊、专业、班级组合查询）
        public static (string sql, MySqlParameter[] parameters) BuildStudentSearchQuery(
            string studentId,
            string name,
            bool nameFuzzy,
            string major,
            string className)
        {
            string baseSql = @"SELECT Id, StudentId, Name, Gender, BirthDate, Class, Major, PhoneNum, Email, EnrollmentDate FROM student";
            var whereClauses = new System.Collections.Generic.List<string>();
            var paramList = new System.Collections.Generic.List<MySqlParameter>();

            if (!string.IsNullOrWhiteSpace(studentId))
            {
                whereClauses.Add("StudentId = @StudentId");
                paramList.Add(new MySqlParameter("@StudentId", studentId));
            }
            if (!string.IsNullOrWhiteSpace(name))
            {
                if (nameFuzzy)
                {
                    whereClauses.Add("Name LIKE @Name");
                    paramList.Add(new MySqlParameter("@Name", "%" + name + "%"));
                }
                else
                {
                    whereClauses.Add("Name = @Name");
                    paramList.Add(new MySqlParameter("@Name", name));
                }
            }
            if (!string.IsNullOrWhiteSpace(major))
            {
                whereClauses.Add("Major = @Major");
                paramList.Add(new MySqlParameter("@Major", major));
            }
            // 只有已选择专业才允许按班级筛选（前端控件也会控制）
            if (!string.IsNullOrWhiteSpace(major) && !string.IsNullOrWhiteSpace(className))
            {
                whereClauses.Add("Class = @Class");
                paramList.Add(new MySqlParameter("@Class", className));
            }

            string finalSql = baseSql;
            if (whereClauses.Count > 0)
            {
                finalSql += " WHERE " + string.Join(" AND ", whereClauses);
            }
            finalSql += " ORDER BY Id DESC";
            return (finalSql, paramList.ToArray());
        }

        // 新增：是否允许选择班级
        public static bool CanSelectClass(string major) => !string.IsNullOrWhiteSpace(major);

        // 新增：加载去重的专业列表
        public static DataTable LoadDistinctMajors(SqlHelper helper)
        {
            string sql = "SELECT DISTINCT Major FROM student WHERE Major IS NOT NULL AND Major <> '' ORDER BY Major";
            return helper.ExecuteQuery(sql);
        }

        // 新增：根据专业加载去重的班级列表
        public static DataTable LoadDistinctClassesForMajor(SqlHelper helper, string major)
        {
            if (string.IsNullOrWhiteSpace(major))
            {
                return new DataTable();
            }
            string sql = "SELECT DISTINCT Class FROM student WHERE Major = @Major AND Class IS NOT NULL AND Class <> '' ORDER BY Class";
            var p = new MySqlParameter[] { new MySqlParameter("@Major", major) };
            return helper.ExecuteQuery(sql, p);
        }
    }
}

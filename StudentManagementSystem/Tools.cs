using System;
using System.Text.RegularExpressions;

namespace StudentManagementSystem
{
    public static class Tools
    {
        // 校验学号是否唯一
        public static bool IsStudentIdUnique(string studentId, SqlHelper sqlHelper)
        {
            string query = "SELECT COUNT(*) FROM student WHERE StudentId = @StudentId";
            var parameters = new MySql.Data.MySqlClient.MySqlParameter[]
            {
                new MySql.Data.MySqlClient.MySqlParameter("@StudentId", studentId)
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
    }
}

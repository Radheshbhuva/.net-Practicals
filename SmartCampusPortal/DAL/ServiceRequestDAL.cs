using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using SmartCampusPortal.Models;

namespace SmartCampusPortal.DAL
{
    public class ServiceRequestDAL
    {
        private readonly string cs = ConfigurationManager.ConnectionStrings["CampusConnection"].ConnectionString;

        public List<ServiceRequest> GetAll()
        {
            List<ServiceRequest> list = new List<ServiceRequest>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT RequestId, StudentName, Department, ServiceType, Description, Priority, Status, RequestDate FROM dbo.ServiceRequests ORDER BY RequestId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new ServiceRequest
                            {
                                RequestId = Convert.ToInt32(r["RequestId"]),
                                StudentName = Convert.ToString(r["StudentName"]),
                                Department = Convert.ToString(r["Department"]),
                                ServiceType = Convert.ToString(r["ServiceType"]),
                                Description = Convert.ToString(r["Description"]),
                                Priority = Convert.ToString(r["Priority"]),
                                Status = Convert.ToString(r["Status"]),
                                RequestDate = Convert.ToDateTime(r["RequestDate"])
                            });
                        }
                    }
                }
            }
            return list;
        }

        public void Insert(ServiceRequest request)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = @"INSERT INTO dbo.ServiceRequests
                                 (StudentName, Department, ServiceType, Description, Priority, Status, RequestDate)
                                 VALUES (@StudentName, @Department, @ServiceType, @Description, @Priority, @Status, @RequestDate)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@StudentName", request.StudentName);
                    cmd.Parameters.AddWithValue("@Department", request.Department);
                    cmd.Parameters.AddWithValue("@ServiceType", request.ServiceType);
                    cmd.Parameters.AddWithValue("@Description", request.Description);
                    cmd.Parameters.AddWithValue("@Priority", string.IsNullOrEmpty(request.Priority) ? "Medium" : request.Priority);
                    cmd.Parameters.AddWithValue("@Status", string.IsNullOrEmpty(request.Status) ? "Pending" : request.Status);
                    cmd.Parameters.AddWithValue("@RequestDate", DateTime.Now);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateStatus(int id, string status)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "UPDATE dbo.ServiceRequests SET Status = @Status WHERE RequestId = @RequestId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@RequestId", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

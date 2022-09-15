﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HRISWebApplication.DataAccess
{
    public class CompanySectionDataAccess : DataAccess
    {
        public CompanySectionDataAccess()
        {
                
        }

        public DataTable GetAllCompanySectionInformation()
        {
            _conn.Open();
            string sqlQuery = @"SELECT [CompanyId], [OfficeLocationId], [DepartmentCode], 
                [SectionCode], [SectionName], [HeadOfSection], [SubstituteHeadOfSection]
                FROM [dbo].[Hrms_Company_Section_Master]";
            SqlCommand cmd = new SqlCommand(sqlQuery, _conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            _conn.Close();
            return dataTable;
        }

        public void DeleteRow<T>(T officeLocationCode)
        {
            throw new NotImplementedException();
        }

        public void Save(IDictionary<string, string> companySection)
        {
            _conn.Open();

            string sqlQuery = $@"INSERT INTO [dbo].[Hrms_Company_Section_Master] 
                ([CompanyId] ,[OfficeLocationId], [DepartmentCode] ,[SectionCode]
                , [SectionName], [HeadOfSection] ,[SubstituteHeadOfSection]) VALUES 
                ('{companySection["companyId"]}', '{companySection["locationId"]}',
                '{companySection["departmentCode"]}', '{companySection["sectionCode"]}',
                '{companySection["sectionName"]}', '{companySection["headOfSection"]}',
                '{companySection["substituteHeadOfSection"]}')";

            SqlCommand command = new SqlCommand(sqlQuery, _conn);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string primaryKeyExceptionMessage = "Duplicate Primary Key Entered";
                HttpContext.Current.Response.Write($"<script>alert('{primaryKeyExceptionMessage}')</script>");
            }

            _conn.Close();
        }

        public void Update(IDictionary<string, string> companyDetails)
        {
            throw new NotImplementedException();
        }

        
    }
}
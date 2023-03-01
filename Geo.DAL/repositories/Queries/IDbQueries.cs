using Geo.DAL.context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geo.DAL.repositories.Queries
{
    public class DbQueries
    {
        private const string _conString = "Server=DUBAN;Database=GeoDB;Trusted_Connection=True;Encrypt=False;"; 
        public DbQueries(GeoDBContext dbContext)
        {

        }

        public DataTable FirstQuery()
        {
            using (SqlConnection con = new SqlConnection(_conString))
            {
                SqlCommand cmd = new($"SELECT E.Id, E.Name, E.Date, R.Name as RouteName FROM Expeditions E INNER JOIN Routes R ON E.RouteID = R.Id INNER JOIN RegionRoute RR ON R.Id = RR.RoutesId INNER JOIN Regions RG ON RR.RegionsId = RG.Id WHERE RG.Country = 'belarus' SELECT RG.Name as RegionName, SUM(R.Length) as TotalLength FROM Regions RG INNER JOIN RegionRoute RR ON RG.Id = RR.RegionsId INNER JOIN Routes R ON RR.RoutesId = R.Id GROUP BY RG.Name", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable("table");
                sda.Fill(dataTable);
                return dataTable;
            }
        }

        public DataTable SecondQuery()
        {
            using (SqlConnection con = new SqlConnection(_conString))
            {
                SqlCommand cmd = new("SELECT RG.Name as RegionName, SUM(R.Length) as TotalLength FROM Regions RG INNER JOIN RegionRoute RR ON RG.Id = RR.RegionsId INNER JOIN Routes R ON RR.RoutesId = R.Id GROUP BY RG.Name", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable("table");
                sda.Fill(dataTable);
                return dataTable;
            }
        }
            
        public DataTable ThirdQuery()
        {
            using (SqlConnection con = new SqlConnection(_conString))
            {
                SqlCommand cmd = new("SELECT RG.Name as Name, 'Region' as Type, COUNT(DISTINCT EG.ExpeditionsId) as ExpeditionCount FROM Regions RG LEFT JOIN RegionRoute RR ON RG.Id = RR.RegionsId LEFT JOIN MapRoute MR ON RR.RoutesId = MR.RoutesId LEFT JOIN Maps M ON MR.MapsId = M.Id LEFT JOIN Expeditions E ON M.RegionId = RG.Id LEFT JOIN ExpeditionGeologist EG ON E.Id = EG.ExpeditionsId GROUP BY RG.Name UNION SELECT CONCAT(G.Name, ' ', G.Surname) as Name, 'Geologist' as Type, COUNT(DISTINCT EG.ExpeditionsId) as ExpeditionCount FROM Geologists G LEFT JOIN ExpeditionGeologist EG ON G.Id = EG.GeologistsId GROUP BY G.Name, G.Surname ORDER BY Name, Type", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable("table");
                sda.Fill(dataTable);
                return dataTable;
            }
                    }

        public DataTable FourthQuery()
        {
            using (SqlConnection con = new SqlConnection(_conString))
            {
                SqlCommand cmd = new("SELECT DATEPART(QUARTER, Date) AS Quarter, COUNT(*) AS ExpeditionCount FROM Expeditions WHERE YEAR(Date) = YEAR(GETDATE()) GROUP BY DATEPART(QUARTER, Date)", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable("table");
                sda.Fill(dataTable);
                return dataTable;
            }
        }
        
        public DataTable Procedure(string expeditionName)
        {
            using (SqlConnection con = new SqlConnection(_conString))
            {
                SqlCommand cmd = new($"SELECT Geologists.Name, Geologists.Surname, Geologists.Patronymic FROM Geologists JOIN ExpeditionGeologist ON Geologists.Id = ExpeditionGeologist.GeologistsId JOIN Expeditions ON ExpeditionGeologist.ExpeditionsId = Expeditions.Id WHERE Expeditions.Name = '{expeditionName}'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable("table");
                sda.Fill(dataTable);
                return dataTable;
            }
        }
        
        public DataTable Function(string mapName)
        {
            using (SqlConnection con = new SqlConnection(_conString))
            {
                SqlCommand cmd = new($"SELECT [dbo].[GetExpeditionCountByMapName]('{mapName}')", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable("table");
                sda.Fill(dataTable);
                return dataTable;
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaratePrototype
{
    class Cleanup
    {
        public void CleanFilesAndDB()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\naomi\source\repos\KaratePrototype\KaratePrototype\KaratePrototype.mdf;Integrated Security=True";
            conn.Open();

            string query = "DELETE FROM People";
            SqlCommand myCommand = new SqlCommand(query, conn);
            myCommand.ExecuteNonQuery();
            query = "DELETE FROM Universities";
            myCommand = new SqlCommand(query, conn);
            myCommand.ExecuteNonQuery();
            conn.Close();
            System.IO.DirectoryInfo di = new DirectoryInfo(@".\Creation\CreatedImages");

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }

        }
    }
}

﻿using CodeBase2.Databases;
using MySql.Data.MySqlClient;

namespace HL7
{

    public class GetMySQL : baseMySQL2
    {

        public override MySql.Data.MySqlClient.MySqlConnection GetConnection
        {
            get
            {
                return new MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;");
            }
        }
    }
}
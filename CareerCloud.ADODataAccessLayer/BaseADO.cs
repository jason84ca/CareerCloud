﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public abstract class BaseADO
    {
        protected string connString;
        public BaseADO()
        {
            connString = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            //connString = @"Data Source=DESKTOP-NE6FPSV\HUMBERBRIDGING;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";

        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
//using RLIO.RightManagement.Data;

namespace ParserIO.DAO
{
    public class BasicResponseType
    {
        private DateTime debut = DateTime.MinValue;

        public DateTime Debut()
        {
            return debut;
        }

        public double DureeExecution
        {
            get;
            set;
        }

        public Results ExecuteResult { get; set; }

        public string Errors { get; set; }

        public BasicResponseType()
        {
            ExecuteResult = Results.Ok;
            Errors = string.Empty;
            debut = DateTime.Now;
        }

        public void Start()
        {
            debut = DateTime.Now;
        }

        public void Start(BasicRequestType request)
        {
            debut = DateTime.Now;
            request.Validate();
        }

        public void Finish(BasicRequestType request)
        {
            DureeExecution = DateTime.Now.Subtract(debut).TotalMilliseconds;
            //LogManager.AddLog(request.UserId, request.Function, debut, DateTime.Now, DureeExecution, Serializer.SerializeObject(request), Errors, request.Caller, "", request.GetLicence());
        }
    }
}

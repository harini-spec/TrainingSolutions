﻿using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IRequestBL
    {
        public Task<int> AddRequest(Request request);
        public Task<Request> GetRequestByRequestNumberForUser(int requestNumber, int userId);
        public Task<Request> GetRequestByRequestNumberForAdmin(int requestNumber);
        public Task<List<Request>> GetAllRequestsOfEmployee(int EmployeeId);
        public Task<List<Request>> GetAllRequests();
        public Task<List<Request>> GetAllOpenRequests();
        public Task<Request> CloseRequest(int requestNumber, int id);
    }
}
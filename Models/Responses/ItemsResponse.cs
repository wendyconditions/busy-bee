﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingList.Models.Responses
{
    /// <typeparam name="T"></typeparam>
    public class ItemsResponse<T> : SuccessResponse
    {
        public List<T> Items { get; set; }
    }
}
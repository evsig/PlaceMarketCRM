﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Repository
{
    public class RequestResult<T>
    {
        public T RequestData { get; set; }
        public bool IsOk { get; set; }
        public string ExMessage { get; set; }
    }
}
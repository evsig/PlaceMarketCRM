﻿namespace CRM.Repository.Common
{
    public class RequestResult<T>
    {
        public T RequestData { get; set; }
        public bool IsOk { get; set; }
        public string ExMessage { get; set; }
    }
}

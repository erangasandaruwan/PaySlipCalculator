using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PaySlip.Api.Dto.Shared
{
    public class JsonResultVm<T> : JsonResultVm
    {
        public T Data { set; get; }
    }

    public class JsonResultVm
    {
        public bool Success { set; get; }
        public string Message { set; get; }

        /// StatusCode : 200 if Success <br/>
        /// StatusCode : 400 if BadRequest <br/>
        /// StatusCode : 500 if InternalServerError <br/>
        public HttpStatusCode StatusCode { set; get; }
        public int TotalCount { get; set; }

    }
}

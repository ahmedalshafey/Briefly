using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Core.Response
{
    public class ResponseHandler
    {
        public Response<T> Deleted<T>(string message=null)
        {
            return new Response<T>()
            {
                Message = message==null? "Deleted successfully":message,
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
            };
        }
        public Response<T> Created<T>(string message=null)
        {
            return new Response<T>()
            {
                Message = message==null? "Created successfully":message,
                StatusCode = HttpStatusCode.Created,
                Succeeded = true,
            };
        }
        public Response<T> Success<T>(T Data, string message = null)
        {
            return new Response<T>()
            {
                Message = message == null ? "Success" : message,
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Data = Data,
            };
        }

        public Response<T> NotFound<T>(string message = null)
        {
            return new Response<T>()
            {
                Message = message == null ? "Not found" : message,
                StatusCode = HttpStatusCode.NotFound,
                Succeeded = false,
            };
        }

        public Response<T> UnAuthorized<T>(string message = null)
        {
            return new Response<T>()
            {
                Message = message == null ? "Unauthorized" : message,
                StatusCode = HttpStatusCode.Unauthorized,
                Succeeded = false,
            };
        }

        public Response<T> BadRequest<T>(string message = null)
        {
            return new Response<T>()
            {
                Message = message == null ? "Bad request" : message,
                StatusCode = HttpStatusCode.BadRequest,
                Succeeded = false,
            };
        }
    }
}

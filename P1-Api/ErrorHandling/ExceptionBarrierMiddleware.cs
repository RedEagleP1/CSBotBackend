using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace P1_Api.ErrorHandling
{
    public class ExceptionBarrierMiddleware
    {
        private readonly RequestDelegate _nextOp;
        private readonly ILogger<ExceptionBarrierMiddleware> _logger;


        public ExceptionBarrierMiddleware(RequestDelegate next, ILogger<ExceptionBarrierMiddleware> logger)
        {
            _nextOp = next;
            _logger = logger;
        }

        public async Task<HttpResponse> InvokeAsync(HttpContext context)
        {
            try
            {
                // Call the next middleware in the pipeline
                await _nextOp(context);
                return context.Response;
            }
            catch (Exception e)
            {
                // Handle the exception and return a response
                return await HandleExceptionAsync(context, e);
            }
        }

        private async Task<HttpResponse> HandleExceptionAsync(HttpContext context, Exception e)
        {
            // First, log the exception
            _logger.LogError(e, "An unhandled exception occurred during the request.");

            // Customize the response based on the exception
            var statusCode = HttpStatusCode.InternalServerError; // Set default response to 500
            string result = string.Empty;

            if (e is UnauthorizedAccessException)
            {
                statusCode = HttpStatusCode.Unauthorized; // 401
                result = "Unauthorized access.";
            }
            else
            {
                result = "An error occurred during the request.";
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            // Return the error message response
            await context.Response.WriteAsync(result);
            return context.Response;
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildingBlocks.Exceptions.CustomExceptionHandler
{
    public class CustomExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            (string Detail, string Title, int StatisCode) details = exception switch
            {
                InternalServerException =>(
                    exception.Message,
                    exception.GetType().Name,
                    httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError
                ),
                ValidationException =>(
                exception.Message,
                exception.GetType().Name,
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest
                ),
                BadHttpRequestException => (
                exception.Message,
                exception.GetType().Name,
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest
                ),
                NotFoundException => 
                (exception.Message,
                 exception.GetType().Name,
                 httpContext.Response.StatusCode = StatusCodes.Status404NotFound
                ),
                _=>(
                 exception.Message,
                 exception.GetType().Name,
                 httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError
                )
            };
            var problemDetails = new ProblemDetails
            {
                Title = details.Title,
                Detail = details.Detail,
                Status = details.StatisCode,
                Instance = httpContext.Request.Path
            };

            problemDetails.Extensions.Add("traceId", httpContext.TraceIdentifier);

            if (exception is ValidationException validationException) {
                problemDetails.Extensions.Add("ValidationErrors", validationException.Errors);
            }
            await httpContext.Response.WriteAsJsonAsync( problemDetails ,cancellationToken:cancellationToken);
            return true;
        }
    }
}

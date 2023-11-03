using HandBallTournamentv2.ApplicationServices.API.Domain;
using HandBallTournamentv2.ApplicationServices.API.ErrorHandling;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HandBallTournamentv2.Controllers
{
    public abstract class ApiControllerBase : ControllerBase
    {
        protected readonly IMediator mediator;

        protected ApiControllerBase(IMediator mediator) 
        {
            this.mediator = mediator;
        }

        protected async Task<IActionResult> HandleRequest<TRequest,  TResponse>(TRequest request) 
            where TRequest : IRequest<TResponse>
            where TResponse : ErrorResponseBase
        {
            if(!ModelState.IsValid)
            {
                return this.BadRequest(
                    this.ModelState
                    .Where(x => x.Value.Errors.Any())
                    .Select(x => new { property = x.Key, errors = x.Value.Errors }));
            }

            var response = await this.mediator.Send(request);
            if (response.Error != null)
            {
                return this.ErrorResponse(response.Error);
            }

            return this.Ok(response);
        }

        private IActionResult ErrorResponse(ErrorModel errorModel)
        {
            var httpCode = GetHttpStatusCode(errorModel.Error);
            return StatusCode((int)httpCode, errorModel);
        }

        private static HttpStatusCode GetHttpStatusCode(string errorType)
        {
            switch (errorType)
            {
                case ErrorType.NotFound: 
                    return HttpStatusCode.NotFound;
                case ErrorType.Unauthorized:
                    return HttpStatusCode.Unauthorized;
                case ErrorType.ValidationError: 
                    return HttpStatusCode.BadRequest;
                case ErrorType.InternalServerError: 
                    return HttpStatusCode.InternalServerError;
                case ErrorType.TooManyRequests: 
                    return HttpStatusCode.TooManyRequests;
                case ErrorType.UnsupportedMediaType:
                    return HttpStatusCode.UnsupportedMediaType;
                case ErrorType.UnsupportedMethod:
                    return HttpStatusCode.MethodNotAllowed;
                default: 
                    return HttpStatusCode.BadRequest;
            }
        }
    }
}

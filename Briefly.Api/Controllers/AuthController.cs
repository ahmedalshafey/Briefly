using Briefly.Core.Features.Auth.Commands.Model;
using Briefly.Core.Features.Auth.Queires.Model;
using Briefly.Core.Response;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Data.ApiRoutingData;
using System.Net;


namespace Briefly.Api.Controllers
{
    [AllowAnonymous]
    public class AuthController : BaseController
    {
        private readonly IValidator<RegisterCommand> _registervalidator;
        private readonly IValidator<LoginCommand> _loginvalidator;
        private readonly IValidator<SendResetPasswordCommand> _sendResetPasswordvalidator;
        private readonly IValidator<ResetPasswordCommand> _resetPasswordvalidator;
        private readonly IValidator<GoogleSigninCommand> _googleSigninValidator;

        public AuthController(IValidator<RegisterCommand> registervalidator, IValidator<LoginCommand> loginvalidator,
            IValidator<SendResetPasswordCommand> sendResetPasswordvalidator, IValidator<ResetPasswordCommand> resetPasswordvalidator, IValidator<GoogleSigninCommand> googleSigninValidator)
        {
            _registervalidator = registervalidator;
            _loginvalidator = loginvalidator;
            _sendResetPasswordvalidator = sendResetPasswordvalidator;
            _resetPasswordvalidator = resetPasswordvalidator;
            _googleSigninValidator = googleSigninValidator;
        }

        [HttpPost(Routes.AuthRouting.Register)]
        public async Task<IActionResult> Register(RegisterCommand registerCommand)
        {
            var validation = await _registervalidator.ValidateAsync(registerCommand);
            if(!validation.IsValid)
            {
                var errorMessages = string.Join('-', validation.Errors.Select(x => x.ErrorMessage).ToList());
                return BadRequest(new Response<string>("", HttpStatusCode.BadRequest, errorMessages, false));
            }
            var response = await _mediator.Send(registerCommand);    
            return Result(response);
        }

        [HttpPost(Routes.AuthRouting.Login)]
        public async Task<IActionResult> Login(LoginCommand loginCommand)
        {
            var validation = await _loginvalidator.ValidateAsync(loginCommand);
            if (!validation.IsValid)
            {
                var errorMessages = string.Join('-', validation.Errors.Select(x => x.ErrorMessage).ToList());
                return BadRequest(new Response<string>("", HttpStatusCode.BadRequest, errorMessages, false));
            }

            var response = await _mediator.Send(loginCommand);
            return Result(response);
        }

        [HttpPost(Routes.AuthRouting.ConfirmEmail)]
        public async Task<IActionResult> ConfirmEmail([FromQuery] int userId,string Code)
        {
            var response = await _mediator.Send(new ConfirmEmailQuery { userId=userId,Code=Code});
            return Result(response);
        }

        [HttpPost(Routes.AuthRouting.SendResetPassword)]
        public async Task<IActionResult> SendResetPassword(SendResetPasswordCommand command)
        {
            var validation = await _sendResetPasswordvalidator.ValidateAsync(command);
            if (!validation.IsValid)
            {
                var errorMessages = string.Join(',', validation.Errors.Select(x => x.ErrorMessage).ToList());
                return BadRequest(new Response<string>("", HttpStatusCode.BadRequest, errorMessages, false));
            }
            var response = await _mediator.Send(command);
            return Result(response);
        }

        [HttpPost(Routes.AuthRouting.ConfirmResetPassword)]
        public async Task<IActionResult> ConfirmResetPassword(ConfirmResetPasswordQuery query)
        {
            var response = await _mediator.Send(query);
            return Result(response);
        }

        [HttpPost(Routes.AuthRouting.ResetPassword)]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand command)
        {
            var validation = await _resetPasswordvalidator.ValidateAsync(command);
            if (!validation.IsValid)

            {
                var errorMessages = string.Join(',', validation.Errors.Select(x => x.ErrorMessage).ToList());
                return BadRequest(new Response<string>("", HttpStatusCode.BadRequest, errorMessages, false));
            }
            var response = await _mediator.Send(command);
            return Result(response);
        }

        [HttpPost(Routes.AuthRouting.GenerateRefreshToken)]
        public async Task<IActionResult> GenerateRefreshToken(RefreshTokenCommand command)
        {
            var response = await _mediator.Send(command);
            return Result(response);
        }

        [HttpPost(Routes.AuthRouting.CheckValidationToken)]
        public async Task<IActionResult> CheckValidationToken(string token)
        {
            var response = await _mediator.Send(new CheckTokenValidationQuery { Token=token});
            return Result(response);
        }

        [HttpPost(Routes.AuthRouting.LoginGoogle)]
        public async Task<IActionResult> LoginGoogle(string tokenId)
        {
            var validation = await _googleSigninValidator.ValidateAsync(new GoogleSigninCommand { IdToken=tokenId});
            if (!validation.IsValid)

            {
                var errorMessages = string.Join(',', validation.Errors.Select(x => x.ErrorMessage).ToList());
                return BadRequest(new Response<string>("", HttpStatusCode.BadRequest, errorMessages, false));
            }
            var response = await _mediator.Send(new GoogleSigninCommand { IdToken = tokenId });
            return Result(response);
        }
    }
}
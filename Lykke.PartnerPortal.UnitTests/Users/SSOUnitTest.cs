using Common.Log;
using Core.Settings.ServiceSettings;
using LykkePartnerPortal.Controllers;
using LykkePartnerPortal.Helpers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Lykke.PartnerPortal.UnitTests.Users
{
    public class SSOUnitTest
    {
        private UsersController _controller;

        [Fact]
        public async Task BadResponse()
        {
            var logsMock = new Mock<ILog>();
            var settings = MockAuthenticationSettings();

            var responseMessage = new HttpResponseMessage();
            var messageHandler = new FakeHttpMessageHandler(responseMessage);
            var client = new HttpClient(messageHandler);

            var mockClient = new Mock<IHttpClientHelper>();
            mockClient.Setup(c => c.PostAsync(
                It.IsAny<string>(),
                It.IsAny<HttpContent>()
                )).Returns(GetBadResponse);

            mockClient.Setup(c => c.GetClient()).Returns(GetClient(client));

            _controller = new UsersController(logsMock.Object, settings, mockClient.Object);

            string code = "Csfsdgfsdgsdyf-asfsdgf-dddd";

            var model = new LykkePartnerPortal.Models.Users.SingleSignOnRequestModel()
            {
                Code = code
            };

            var result = await _controller.Authentication(model);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void CheckIfPostDataIsValid()
        {
            HttpClientHelper helper = new HttpClientHelper();
            var settings = MockAuthenticationSettings();

            string code = "123";

            var examplePostData = MockPostData(code, settings);

            string val = helper.GetPostData(code, settings.ClientId, settings.ClientSecret, settings.RedirectUrl);

            Assert.Equal(examplePostData, val);
        }

        [Fact]
        public async Task CheckIfContentIsNotChanged()
        {
            var logsMock = new Mock<ILog>();
            var settings = MockAuthenticationSettings();

            var responseMessage = new HttpResponseMessage();
            var messageHandler = new FakeHttpMessageHandler(responseMessage);

            var client = new HttpClient(messageHandler);

            string code = "Csfsdgfsdgsdyf-asfsdgf-dddd";

            var model = new LykkePartnerPortal.Models.Users.SingleSignOnRequestModel()
            {
                Code = code
            };

            String postData = MockPostData(code, settings);
            HttpContent mockedConent = GetHttpContent(postData);

            var mockClient = new Mock<IHttpClientHelper>();
            mockClient.Setup(c => c.GetClient()).Returns(GetClient(client));

            mockClient.Setup(c => c.GetPostData(model.Code, settings.ClientId, settings.ClientSecret, settings.RedirectUrl)).
                Returns(postData);

            mockClient.Setup(c => c.PostAsync(It.IsAny<string>(), It.IsAny<HttpContent>()))
                .Returns((string url, HttpContent content) =>
                {
                    CheckIsEqualContent(content, mockedConent);
                    return GetOkResponse();
                });

            mockClient.Setup(c => c.BuildStringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded")).
               Returns(GetStringContent(postData));

            _controller = new UsersController(logsMock.Object, settings, mockClient.Object);

            var result = await _controller.Authentication(model);
            Assert.IsType<OkObjectResult>(result);
        }

        #region Mock helper methods

        private Task<HttpResponseMessage> GetOkResponse()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent("token", Encoding.UTF8, "application/x-www-form-urlencoded");
            return Task.FromResult(response);
        }

        private Task<HttpResponseMessage> GetBadResponse()
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            response.Content = new StringContent("invalid", Encoding.UTF8, "application/x-www-form-urlencoded");
            return Task.FromResult(response);
        }

        private void CheckIsEqualContent(HttpContent cont, HttpContent mockedContent)
        {
            var contentPassedFromController = JsonConvert.SerializeObject(cont);
            var contentBuild = JsonConvert.SerializeObject(mockedContent);

            Assert.Equal(contentPassedFromController, contentBuild);
        }

        private HttpClient GetClient(HttpClient client)
        {
            return client;
        }

        private HttpContent GetHttpContent(string postData)
        {
            return new StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded");
        }

        private StringContent GetStringContent(string postData)
        {
            return new StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded");
        }

        private AuthenticationSettings MockAuthenticationSettings()
        {
            AuthenticationSettings settings = new AuthenticationSettings();
            settings.ClientId = "123";
            settings.ClientSecret = "test";
            settings.ApiTokenUrl = "auth.test.com";
            settings.RedirectUrl = "auth.test.redirect.com";
            return settings;
        }

        private string MockPostData(string code, AuthenticationSettings settings)
        {
            var examplePostData = "code=" + code;
            examplePostData += "&client_id=" + settings.ClientId;
            examplePostData += "&client_secret=" + settings.ClientSecret;
            examplePostData += "&grant_type=" + "authorization_code";
            examplePostData += "&redirect_uri=" + settings.RedirectUrl;

            return examplePostData;
        }
        #endregion
    }
}

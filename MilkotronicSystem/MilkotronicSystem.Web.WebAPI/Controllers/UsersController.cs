using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using MilkotronicSystem.Data;
using MilkotronicSystem.Web.WebAPI;
using MilkotronicSystem.Web.WebAPI.Models;

namespace MilkotronicSystem.Web.WebAPI.Controllers
{
    /// <summary>
    /// Controller handling user functions
    /// </summary>
    public class UsersController : BaseApiController
    {
        private const int MinUsernameLength = 6;
        private const int MaxUsernameLength = 30;
        private const string ValidUsernameCharacters =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_.";

        private const string SessionKeyChars =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM";
        private static readonly Random rand = new Random();

        private const int SessionKeyLength = 50;

        private const int Sha1Length = 40;

        /// <summary>
        /// Controller constructor
        /// </summary>
        public UsersController()
        {
        }

        /// <summary>
        /// Creating RESTful endpoint for action login
        /// </summary>
        /// <param name="model">takes an object Of type UserModel from the body of the http request</param>
        /// <returns>http status code Created and an object of type LoggedModel</returns>
        [HttpPost]
        [ActionName("login")]
        public HttpResponseMessage PostLoginUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
              () =>
              {
                  MilkotronicSystemEntities context = new MilkotronicSystemEntities();
                  using (context)
                  {
                      this.ValidateUsername(model.Username);
                      this.ValidateAuthCode(model.AuthCode);
                      var usernameToLower = model.Username.ToLower();
                      var user = context.Users.FirstOrDefault(
                          usr => usr.username == usernameToLower
                          && usr.authCode == model.AuthCode);

                      if (user == null)
                      {
                          throw new InvalidOperationException("Invalid username or password");
                      }
                      if (user.sessionKey == null)
                      {
                          user.sessionKey = this.GenerateSessionKey(user.id);
                          context.SaveChanges();
                      }

                      var loggedModel = new LoggedUserModel()
                      {
                          Username = user.username,
                          SessionKey = user.sessionKey
                      };

                      var response =
                          this.Request.CreateResponse(HttpStatusCode.Created,
                                          loggedModel);
                      return response;
                  }
              });

            return responseMsg;
        }

        /// <summary>
        /// Creating RESTful endpoint for action logout
        /// </summary>
        /// <param name="sessionKey">used for authorising the user</param>
        /// <returns>HttpStatusCode.OK</returns>
        [HttpPut]
        [ActionName("logout")]
        public HttpResponseMessage PutLogout(string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                MilkotronicSystemEntities context = new MilkotronicSystemEntities();
                using (context)
                {
                    var user = context.Users.FirstOrDefault(u => u.sessionKey == sessionKey);
                    if (user != null)
                    {
                        user.sessionKey = null;
                        context.SaveChanges();
                    }
                }
                var response = this.Request.CreateResponse(HttpStatusCode.OK);
                return response;
            });
            return responseMsg;
        }

        /// <summary>
        /// Method for generating a session key for a user
        /// </summary>
        /// <param name="userId">id of the user, used for finding the user in the database</param>
        /// <returns>generated session key</returns>
        private string GenerateSessionKey(int userId)
        {
            StringBuilder skeyBuilder = new StringBuilder(SessionKeyLength);
            skeyBuilder.Append(userId);
            while (skeyBuilder.Length < SessionKeyLength)
            {
                var index = rand.Next(SessionKeyChars.Length);
                skeyBuilder.Append(SessionKeyChars[index]);
            }
            return skeyBuilder.ToString();
        }

        /// <summary>
        /// Method for validating a given authorisation code
        /// </summary>
        /// <param name="authCode">authorisation code for validation</param>
        private void ValidateAuthCode(string authCode)
        {
            if (authCode == null || authCode.Length != Sha1Length)
            {
                throw new ArgumentOutOfRangeException("Password should be encrypted");
            }
        }

        /// <summary>
        /// Method for validating given username
        /// </summary>
        /// <param name="username">username for validation</param>
        private void ValidateUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Username cannot be null");
            }
            else if (username.Length < MinUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Username must be at least {0} characters long",
                    MinUsernameLength));
            }
            else if (username.Length > MaxUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Username must be less than {0} characters long",
                    MaxUsernameLength));
            }
            else if (username.Any(ch => !ValidUsernameCharacters.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(
                    "Username must contain only Latin letters, digits .,_");
            }

        }
    }
}

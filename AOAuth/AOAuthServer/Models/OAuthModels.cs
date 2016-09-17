using AOAuthServer.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AOAuthServer.Models
{

    [DataContract]
    public class AccessToken
    {
        [DataMember(Name ="value")]
        public string value { get; set; }
        [DataMember(Name = "client_id")]
        public string clientId { get; set; }
        [DataMember(Name = "user_id")]
        public string userId { get; set; }
        [DataMember(Name = "expire")]
        public DateTime Expire { get; set; }

    }

    [DataContract]
    public class AuthorizeRequest
    {
        [Required]
        [Display(Name = "Client ID")]
        [DataMember(Name = "client_id")]
        public string clientId { get; set; }

        [Required]
        [Display(Name = "Response Type")]
        [DataMember(Name = "response_type")]
        public ResponseType responseType { get; set; }

        [Display(Name = "State")]
        [DataMember(Name = "state")]
        public string state { get; set; }

        [Display(Name = "Redirect Uri")]
        [DataMember(Name = "redirect_uri")]
        public string redirectUri { get; set; }
    }
}
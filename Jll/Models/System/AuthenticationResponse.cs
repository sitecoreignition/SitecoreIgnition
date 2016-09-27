using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JLL.SP2013.Internet.Eloqua.Models.System
{
    /// <summary>
    /// Represents successful response on authentication with Eloqua
    /// </summary>
    [DataContract]
    public class AuthenticationResponse
    {
        [DataMember(Name ="site")]
        public Site Site { get; set; }
        [DataMember(Name = "urls")]
        public Urls Urls { get; set; }
        [DataMember(Name = "user")]
        public User User { get; set; }
    }

    [DataContract]
    public class Site
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }

    [DataContract]
    public class Urls
    {
        [DataMember(Name = "apis")]
        public Apis Apis { get; set; }
        [DataMember(Name = "base")]
        public string Base { get; set; }
    }
    [DataContract]
    public class Apis
    {
        [DataMember(Name = "rest")]
        public Rest Rest { get; set; }
        [DataMember(Name = "soap")]
        public Soap Soap { get; set; }
    }
    [DataContract]
    public class Rest
    {
        [DataMember(Name = "bulk")]
        public string Bulk { get; set; }
        [DataMember(Name = "standard")]
        public string Standard { get; set; }
    }
    [DataContract]
    public class Soap
    {
        [DataMember(Name = "dataTransfer")]
        public string DataTransfer { get; set; }
        [DataMember(Name = "email")]
        public string Email { get; set; }
        [DataMember(Name = "externalAction")]
        public string ExternalAction { get; set; }
        [DataMember(Name = "standard")]
        public string Standard { get; set; }
    }
    [DataContract]
    public class User
    {
        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }
        [DataMember(Name = "emailAddress")]
        public string EmailAddress { get; set; }
        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "lastName")]
        public string LastName { get; set; }
        [DataMember(Name = "Username")]
        public string Username { get; set; }
    }

}

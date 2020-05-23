using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using static System.String;

namespace NetPanel.Data
{
    public class User
    {
        [BsonId][BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Username = Empty;
        public string Email = Empty;
        public string HashedPwd = Empty;
        public bool EmailOtp { get; set; }
        public BasePermissions Perms = BasePermissions.Rcon;
        public string CustomPermScript = Empty;
        public int SendOtp()
        {
            var otp = new Random().Next(1001, 9999);
            var mail = new MailMessage("noreply", Email, "NetPanel OTP", $"Your otp is: {otp}");
            
            return otp;
        }
    }

    public class Otp
    {
        [BsonId][BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public int Code { get; set; }
        public DateTime Expires { get; set; }
        public DateTime Issued { get; set; }
    }

    public enum BasePermissions
    {
        God = 0,
        Admin = 1,
        Manage = 4,
        Rcon = 10
    }
}

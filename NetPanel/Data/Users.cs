using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NetPanel.Data
{
    public class Users
    {
        [BsonId][BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
        public string HashedPwd { get; set; }
        public bool EmailOtp { get; set; }

        public int SendOtp()
        {
            var otp = new Random().Next(1001, 9999);
            var mail = new MailMessage("noreply", Email, "NetPanel OTP", $"Your otp is: {otp}");

            return otp;
        }
    }

    public enum BasePermissions
    {
        God,
        Admin,
        Manage,
        RCON
    }
}

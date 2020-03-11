using FileReader.Domain.Enums;
using System;
using System.Security.Claims;

namespace FileReader.Domain.Helpers
{
    public static class Helpers
    {
        /// <summary>
        /// Checks whether the application supports given file type
        /// </summary>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static bool IsFileTypeSupported(string contentType)
        {
            // supported fileTypes:
            // text/plain
            // text/xml
            // application/json
            return contentType switch
            {
                "text/plain" => true,
                "text/xml" => true,
                "application/json" => true,
                _ => false,
            };
        }

        /// <summary>
        /// Checks whether the current user is allowed to read the file
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool IsUserAllowed(ClaimsPrincipal user)
        {
            Random random = new Random();

            return user.Identity.Name switch
            {
                "None" => true,
                "Admin" => true,
                "Member" => Convert.ToBoolean(random.Next(0, 2)),
                _ => false
            };
        }
    }
}

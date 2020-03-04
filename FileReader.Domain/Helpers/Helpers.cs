using FileReader.Domain.Enums;
using System;

namespace FileReader.Domain.Helpers
{
    public static class Helpers
    {
        /// <summary>
        /// Gets FileType enum based on file content type
        /// </summary>
        /// <param name="contentType"></param>
        /// <param name="fileType">Output parameter</param>
        /// <exception cref="NotSupportedException"></exception>
        public static void GetFileTypeEnumFromContentType(string contentType, out FileType fileType)
        {
            // supported fileTypes:
            // text/plain
            // text/xml
            fileType = contentType switch
            {
                "text/plain" => FileType.Text,
                "text/xml" => FileType.Xml,
                _ => throw new NotSupportedException(message: "This type of file isn't supported."),
            };
        }
    }
}

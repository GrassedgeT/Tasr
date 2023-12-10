using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasr.Library.Utils
{
    public partial class ErrorMessages
    {
        public const string AudioErrorTitle = "音频错误";
        public const string ErrorButton = "确定";
        public const string HttpClientErrorTitle = "网络连接错误";
        public static string GetHttpClientError(string server, string message) =>
            $"与{server}连接时发生了错误：\n{message}";
    }
}

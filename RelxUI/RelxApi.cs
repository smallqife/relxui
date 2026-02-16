using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RelxUI
{
    public static class RelxApi
    {
        private static readonly HttpClient client = new HttpClient() { Timeout = TimeSpan.FromSeconds(10) };

        public static async Task<(bool success, string? token, string? error)> TryLoginAsync(string username, string password)
        {
            try
            {
                var payload = new { username = username, password = password };
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://relx.lunarclient.top/api/auth/login", content);
                string result = await response.Content.ReadAsStringAsync();

                var obj = JObject.Parse(result);

                if (obj["error"] != null)
                    return (false, null, obj["error"]?.ToString());

                string? token = obj["token"]?.ToString();
                return (true, token, null);
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message);
            }
        }

        public static async Task<string> GetSubscriptionInfoAsync(string token)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "https://relx.lunarclient.top/api/user/account");
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var response = await client.SendAsync(request);
                string result = await response.Content.ReadAsStringAsync();

                var obj = JObject.Parse(result);

                bool hasSub = obj["has_active_subscription"]?.ToObject<bool>() ?? false;
                if (!hasSub) return "No active subscription";

                string? expiresStr = obj["subscription_expires_at"]?.ToString();
                if (expiresStr == null) return "Subscription info unavailable";

                if (DateTime.TryParse(expiresStr, out DateTime expireTime))
                {
                    TimeSpan remaining = expireTime - DateTime.UtcNow;
                    if (remaining.TotalSeconds <= 0) return "Subscription expired";
                    return $"{remaining.Days} days {remaining.Hours} hours remaining";
                }

                return "Subscription info parse error";
            }
            catch
            {
                return "Failed to get subscription info";
            }
        }

        public static async Task<(bool success, string? error)> RedeemAsync(string token, string code)
        {
            try
            {
                var payload = new { code = code };
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(HttpMethod.Post,
                    "https://relx.lunarclient.top/api/user/activation/redeem");

                request.Content = content;
                request.Headers.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var response = await client.SendAsync(request);
                string result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return (true, null);
                }

                // 解析错误 JSON
                try
                {
                    var obj = JObject.Parse(result);
                    return (false, obj["error"]?.ToString());
                }
                catch
                {
                    return (false, result);
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        public static async Task<string?> GetRemoteSha256Async()
        {
            if (string.IsNullOrEmpty(GlobalData.Token))
                return null;

            try
            {
                string url = "https://relx.lunarclient.top/api/download/injector/sha256";
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", GlobalData.Token);

                var response = await client.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                    return null;

                string json = await response.Content.ReadAsStringAsync();
                var obj = Newtonsoft.Json.Linq.JObject.Parse(json);
                return obj["sha256"]?.ToString()?.Trim();
            }
            catch
            {
                return null;
            }
        }


        public static string ComputeFileSha256(string path)
        {
            using var sha256 = SHA256.Create();
            using var stream = File.OpenRead(path);
            var hash = sha256.ComputeHash(stream);

            return BitConverter.ToString(hash)
                .Replace("-", "")
                .ToLowerInvariant();
        }

        public static async Task<bool> DownloadInjectorAsync(string savePath, IProgress<int> progress)
        {
            if (string.IsNullOrEmpty(GlobalData.Token))
            {
                Debug.WriteLine("Token is null.");
                return false;
            }

            try
            {
                var request = new HttpRequestMessage(
                    HttpMethod.Get,
                    "https://relx.lunarclient.top/api/download/injector");

                request.Headers.Add("apikey", GlobalData.Token);

                using var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

                Debug.WriteLine("Download status code: " + response.StatusCode);

                if (!response.IsSuccessStatusCode)
                {
                    string error = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine("Download failed response: " + error);
                    return false;
                }

                var totalBytes = response.Content.Headers.ContentLength ?? -1L;
                Debug.WriteLine("Total Bytes: " + totalBytes);

                using var contentStream = await response.Content.ReadAsStreamAsync();
                using var fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true);

                var buffer = new byte[8192];
                long totalRead = 0;
                int read;

                while ((read = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    await fileStream.WriteAsync(buffer, 0, read);
                    totalRead += read;

                    if (totalBytes > 0)
                    {
                        int percent = (int)((totalRead * 100) / totalBytes);
                        progress.Report(percent);
                    }
                }

                Debug.WriteLine("Download completed successfully.");
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Download exception: " + ex.Message);
                return false;
            }
        }
    }
}

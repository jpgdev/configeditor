using System;
using System.IO;
using ConfigEditor.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConfigEditor
{
    public class JsonParser
    {
        private readonly ILogger m_logger;

        public JsonParser(ILoggerFactory loggerFactory)
        {
            if (loggerFactory == null)
                throw new ArgumentNullException(nameof(loggerFactory));

            m_logger = loggerFactory.CreateLogger(this);
        }

        public JObject Parse(string json)
        {
            return JObject.Parse(json);
        }

        public JObject ParseFromFile(string fileLocation)
        {
            if (!File.Exists(fileLocation))
            {
                m_logger.TraceError($"{fileLocation} is not a valid file.");
                return null;
            }

            try
            {
                using (StreamReader reader = new StreamReader(fileLocation))
                {
                    var json = reader.ReadToEnd();
                    return Parse(json);
                }
            }
            catch (Exception ex)
            {
                m_logger.TraceError(ex, $"There was an error parsing '{fileLocation}'");
                throw;
            }
        }

        public void ParseJObject(JObject jsonObject)
        {
            foreach (var obj in jsonObject)
            {
                Console.WriteLine($"{obj.Key}:{obj.Value}");
            }
        }

        public static bool TryParseJson(string json, out JObject result)
        {
            result = null;
            try
            {
                result = JObject.Parse(json);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Validates the JSON.
        /// 
        /// </summary>
        /// <param name="json">JSON to validate</param>
        /// <param name="errorMessage">Error message if it's invalid.</param>
        /// <returns>True if valid, False if invalid</returns>
        public static bool ValidateJson(string json, out string errorMessage)
        {
            if (string.IsNullOrEmpty(json))
            {
                errorMessage = "The JSON is null or empty.";
                return false;
            }

            errorMessage = null;
            try
            {
                JObject.Parse(json);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = $"Invalid json: {ex.Message}";
                return false;
            }
        }


    }
}

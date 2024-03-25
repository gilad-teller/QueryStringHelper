using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System;

namespace Net.TellerApps.QueryStringHelper
{
    public static class QueryStringHelper
    {
        /// <summary>
        /// Builds a uri encoded query string. Using the ToString implementation of the key and value types.
        /// </summary>
        /// <typeparam name="TKey">Type for the key</typeparam>
        /// <typeparam name="TValue">Type for the value</typeparam>
        /// <param name="parameters">Collection of key-value parameters</param>
        /// <returns>Uri encoded query string</returns>
        /// <exception cref="ArgumentNullException">Throws ArgumentNullException if the parameters or any of the keys are null</exception>
        public static string BuildQueryString<TKey, TValue>(ICollection<KeyValuePair<TKey, TValue>> parameters)
        {
            if (parameters is null)
            {
                throw new ArgumentNullException(nameof(parameters), "parameters cannot be null");
            }
            NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(string.Empty);
            foreach (KeyValuePair<TKey, TValue> kvp in parameters)
            {
                if (kvp.Key is null)
                {
                    throw new ArgumentNullException(nameof(kvp.Key), "Key cannot be null");
                }
                nameValueCollection[kvp.Key.ToString()] = kvp.Value?.ToString() ?? string.Empty;
            }
            return nameValueCollection.ToString();
        }

        /// <summary>
        /// Builds a uri encoded query string and adds it to the Query property of the UriBuilder. Using the ToString implementation of the key and value types.
        /// </summary>
        /// <typeparam name="TKey">Type for the key</typeparam>
        /// <typeparam name="TValue">Type for the value</typeparam>
        /// <param name="builder">UriBuilder to add the query string</param>
        /// <param name="parameters">Collection of key-value parameters</param>
        /// <returns>The UriBuilder</returns>
        public static UriBuilder AddQueryString<TKey, TValue>(this UriBuilder builder, ICollection<KeyValuePair<TKey, TValue>> parameters)
        {
            string queryString = BuildQueryString(parameters);
            builder.Query = queryString;
            return builder;
        }
    }
}

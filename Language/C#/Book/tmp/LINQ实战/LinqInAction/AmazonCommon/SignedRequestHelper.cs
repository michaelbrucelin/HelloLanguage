// Based on http://developer.amazonwebservices.com/connect/entry.jspa?externalID=2480&categoryID=14

/**********************************************************************************************
 * Copyright 2009 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License"). You may not use this file 
 * except in compliance with the License. A copy of the License is located at
 *
 *       http://aws.amazon.com/apache2.0/
 *
 * or in the "LICENSE.txt" file accompanying this file. This file is distributed on an "AS IS"
 * BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations under the License. 
 *
 * ********************************************************************************************
 *
 *  Amazon Product Advertising API
 *  Signed Requests Sample Code
 *
 *  API Version: 2009-03-31
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
#if SILVERLIGHT
using System.Windows.Browser;
#else
using System.Web;
#endif

namespace AmazonCommon
{
    public class SignedRequestHelper
    {
        private string endPoint;
        private string akid;
        private byte[] secret;
        private HMAC signer;

        private const string REQUEST_URI = "/onca/xml";
        private const string REQUEST_METHOD = "GET";

        /*
         * Use this constructor to create the object. The AWS credentials are available on
         * http://aws.amazon.com
         * 
         * The destination is the service end-point for your application:
         *  US: ecs.amazonaws.com
         *  JP: ecs.amazonaws.jp
         *  UK: ecs.amazonaws.co.uk
         *  DE: ecs.amazonaws.de
         *  FR: ecs.amazonaws.fr
         *  CA: ecs.amazonaws.ca
         */
        public SignedRequestHelper(string awsAccessKeyId, string awsSecretKey, string destination)
        {
            this.endPoint = destination.ToLower();
            this.akid = awsAccessKeyId;
            this.secret = Encoding.UTF8.GetBytes(awsSecretKey);
            this.signer = new HMACSHA256(this.secret);
        }

        /*
         * Sign a request in the form of a Dictionary of name-value pairs.
         * 
         * This method returns a complete URL to use. Modifying the returned URL
         * in any way invalidates the signature and Amazon will reject the requests.
         */
        public string Sign(IDictionary<string, string> request)
        {
            var map = new Dictionary<String, String>(request); // Updated for Silverlight compatibility

            // Add the AWSAccessKeyId and Timestamp to the requests.
            map["AWSAccessKeyId"] = this.akid;
            map["Timestamp"] = this.GetTimestamp();

            // Get the canonical query string
            // Use a sorted dictionary to get the parameters in naturual byte order, as
            // required by AWS.
            ParamComparer pc = new ParamComparer();
            var sortedMap = map.OrderBy(kvp => kvp.Key, pc).ToList(); // Updated for Silverlight compatibility
            string canonicalQS = this.ConstructCanonicalQueryString(sortedMap);

            // Derive the bytes needs to be signed.
            StringBuilder builder = new StringBuilder();
            builder.Append(REQUEST_METHOD)
                .Append("\n")
                .Append(this.endPoint)
                .Append("\n")
                .Append(REQUEST_URI)
                .Append("\n")
                .Append(canonicalQS);

            string stringToSign = builder.ToString();
            byte[] toSign = Encoding.UTF8.GetBytes(stringToSign);

            // Compute the signature and convert to Base64.
            byte[] sigBytes = signer.ComputeHash(toSign);
            string signature = Convert.ToBase64String(sigBytes);
            
            // now construct the complete URL and return to caller.
            StringBuilder qsBuilder = new StringBuilder();
            qsBuilder.Append("http://")
                .Append(this.endPoint)
                .Append(REQUEST_URI)
                .Append("?")
                .Append(canonicalQS)
                .Append("&Signature=")
                .Append(this.PercentEncodeRfc3986(signature));

            return qsBuilder.ToString();
        }

        /*
         * Sign a request in the form of a query string.
         * 
         * This method returns a complete URL to use. Modifying the returned URL
         * in any way invalidates the signature and Amazon will reject the requests.
         */
        public string Sign(string queryString)
        {
            IDictionary<string, string> request = this.CreateDictionary(queryString);
            return this.Sign(request);
        }

        /*
         * Current time in IS0 8601 format as required by Amazon
         */
        private string GetTimestamp()
        {
            DateTime currentTime = DateTime.UtcNow;
            string timestamp = currentTime.ToString("yyyy-MM-ddTHH:mm:ssZ");
            return timestamp;
        }

        /*
         * Percent-encode (URL Encode) according to RFC 3986 as required by Amazon.
         * 
         * This is necessary because .NET's HttpUtility.UrlEncode does not encode
         * according to the above standard. Also, .NET returns lower-case encoding
         * by default and Amazon requires upper-case encoding.
         */
        private string PercentEncodeRfc3986(string str)
        {
            str = HttpUtility.UrlEncode(str); // Updated for Silverlight compatibility
            str = str.Replace("'", "%27").Replace("(", "%28").Replace(")", "%29").Replace("*", "%2A").Replace("!", "%21").Replace("%7e", "~").Replace("+", "%20");

            StringBuilder sbuilder = new StringBuilder(str);
            for (int i = 0; i < sbuilder.Length; i++)
            {
                if (sbuilder[i] == '%')
                {
                    if (Char.IsLetter(sbuilder[i + 1]) || Char.IsLetter(sbuilder[i + 2]))
                    {
                        sbuilder[i + 1] = Char.ToUpper(sbuilder[i + 1]);
                        sbuilder[i + 2] = Char.ToUpper(sbuilder[i + 2]);
                    }
                }
            }
            return sbuilder.ToString();
        }

        /*
         * Convert a query string to corresponding dictionary of name-value pairs.
         */
        private IDictionary<string, string> CreateDictionary(string queryString)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();

            string[] requestParams = queryString.Split('&');

            Regex regex = new Regex("="); // Added for Silverlight compatibility

            for (int i = 0; i < requestParams.Length; i++)
            {
                if (requestParams[i].Length < 1)
                {
                    continue;
                }

                char[] sep = { '=' };
                string[] param = regex.Split(requestParams[i], 2); // Updated for Silverlight compatibility
                for (int j = 0; j < param.Length; j++)
                {
                    param[j] = HttpUtility.UrlDecode(param[j]); // Updated for Silverlight compatibility
                }
                switch (param.Length)
                {
                    case 1:
                        {
                            if (requestParams[i].Length >= 1)
                            {
                                if (requestParams[i].ToCharArray()[0] == '=')
                                {
                                    map[""] = param[0];
                                }
                                else
                                {
                                    map[param[0]] = "";
                                }
                            }
                            break;
                        }
                    case 2:
                        {
                            if (!string.IsNullOrEmpty(param[0]))
                            {
                                map[param[0]] = param[1];
                            }
                        }
                        break;
                }
            }

            return map;
        }

        /*
         * Consttuct the canonical query string from the sorted parameter map.
         */
        private string ConstructCanonicalQueryString(IEnumerable<KeyValuePair<String, String>> sortedParamMap) // Updated for Silverlight compatibility
        {
            StringBuilder builder = new StringBuilder();

            if (!sortedParamMap.Any())
            {
                builder.Append("");
                return builder.ToString();
            }

            foreach (KeyValuePair<string, string> kvp in sortedParamMap)
            {
                builder.Append(this.PercentEncodeRfc3986(kvp.Key));
                builder.Append("=");
                builder.Append(this.PercentEncodeRfc3986(kvp.Value));
                builder.Append("&");
            }
            string canonicalString = builder.ToString();
            canonicalString = canonicalString.Substring(0, canonicalString.Length - 1);
            return canonicalString;
        }
    }

    /*
     * To help the SortedDictionary order the name-value pairs in the correct way.
     */     
    class ParamComparer : IComparer<string>
    {
        public int Compare(string p1, string p2)
        {
            return string.CompareOrdinal(p1, p2);
        }
    }
}

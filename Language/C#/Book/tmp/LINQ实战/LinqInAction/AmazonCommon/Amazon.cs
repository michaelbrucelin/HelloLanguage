using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace AmazonCommon
{
    public class Amazon
    {
        //#error Provide your Amazon Web Services keys below and remove this error line
        // In order to use the Amazon.com web services and test these examples,
        // you need to register with the Amazon Web Services program.
        // After registering with Amazon you will be assigned authentication keys.
        // Edit this file and enter your keys.
        // See http://docs.amazonwebservices.com/AWSECommerceService/latest/DG/index.html?RequestAuthenticationArticle.html

        public const String AccessKey = INSERT YOUR AWS ACCESS KEY HERE;
        public const String SecretKey = INSERT YOUR AWS SECRET KEY HERE;
        public const String ServiceName = "AWSECommerceService";
        public const String ServiceVersion = "2009-07-01";
        public static XNamespace AmazonNS = "http://webservices.amazon.com/" + ServiceName + "/" + ServiceVersion;
    }
}
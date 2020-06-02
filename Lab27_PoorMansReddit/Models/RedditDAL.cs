using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Lab27_PoorMansReddit.Models
{
    public class RedditDAL
    {
        public string GetAPIString(string subreddit)
        {
            string url = $"Https://www.reddit.com/r/{subreddit}/.json";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());

            string output = rd.ReadToEnd();

            return output;
        }

        public RedditPost GetPost()
        {
            string output = GetAPIString("aww");
            JObject json = JObject.Parse(output);
            List<JToken> modelData = json["data"]["children"].ToList();
            //I want to put a for loop in here to display the list but I can't figure out how
            //I know that modelData[0] is restricting me to just the first index
            RedditPost rp = JsonConvert.DeserializeObject<RedditPost>(modelData[0]["data"].ToString());

                return rp;
            
        }
    }
}


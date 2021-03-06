﻿using System;
using System.Collections.Generic;

namespace ms.video.downloader.android.service.download
{
    public class YoutubeUrl
    {
        public string ChannelId { get; set; }
        public string VideoId { get; set; }
        public string FeedId { get; set; }
        public string UserId { get; set; }
        public Uri Uri { get; set; }
        public VideoUrlType Type { get; set; }
        public ContentProviderType Provider { get; set; }
        public string Id { get; set; }

        public override string ToString()
        {
            return Uri.ToString();
        }

        public static YoutubeUrl Create(Uri u)
        {
            var url = new YoutubeUrl { Uri = u, Type = VideoUrlType.Unknown, Provider = ContentProviderType.Youtube, ChannelId = "", FeedId = "", Id = "", VideoId = ""};
            var parameters = DownloadHelper.GetParams(u.Query);
            if (parameters.Count > 0 && parameters.ContainsKey("v")) {
                url.Id = parameters["v"];
                url.VideoId = url.Id;
                url.Type = VideoUrlType.Video;
            } 
            return url;
        }

        /*
        protected void Parse(string lurl)
        {
            var surl = lurl.Replace("youtu.be/", "youtube.com/watch?v=");
            surl = surl.Replace("www.youtube.com", "youtube.com");
            if (surl.StartsWith("http://youtube.com/v/")) 
                surl = surl.Replace("youtube.com/v/", "youtube.com/watch?v=");
            else if (surl.StartsWith("http://youtube.googleapis.com/v")) 
                surl = surl.Replace("youtube.googleapis.com/v/", "youtube.com/watch?v=");
            else if (surl.StartsWith("http://youtube.com/watch#")) 
                surl = surl.Replace("youtube.com/watch#", "youtube.com/watch?");
            surl = surl.Replace("//youtube.com", "//www.youtube.com");

            var uri = new Uri(surl);
            Uri = uri;
            if (!uri.Host.Contains(".youtube.com")) return; // throw new Exception("Invalid HOST");
            var parameters = DownloadHelper.GetParams(uri.Query);
            if (parameters.Count > 0) {
                ChannelId = GetPlaylistId(parameters);
                VideoId = GetVideoId(parameters);
            }
            FeedId = GetFeedId(uri);
            UserId = "";
            Id = "";
            var arr = uri.AbsolutePath.Substring(1).Split('/');
            switch (arr[0].ToLowerInvariant()) {
                case "user":
                    UserId = arr[1];
                    Id = UserId;
                    Type = VideoUrlType.User;
                    break;
                //http://www.youtube.com/feed/UC2xskkQVFEpLcGFnNSLQY0A
                //https://gdata.youtube.com/feeds/api/users/UC2xskkQVFEpLcGFnNSLQY0A/uploads
                case "feed":
                    Id = FeedId;
                    Type = VideoUrlType.Channel;
                    break;
                case "watch":
                    Id = VideoId;
                    Type = VideoUrlType.Video;
                    break;
                default:
                    if (!String.IsNullOrEmpty(ChannelId)) {
                        Id = ChannelId;
                        Type = VideoUrlType.Channel;
                    }
                    break;
            }
        }

        public static string GetFeedId(Uri uri)
        {
            //http://www.youtube.com/feed/UC2xskkQVFEpLcGFnNSLQY0A
            var arr = uri.AbsolutePath.Substring(1).Split('/');
            if (arr.Length >= 2 && arr[0].ToLowerInvariant() == "feed") {
                return arr[1];
            }
            return "";
        }

        public static string GetVideoId(Dictionary<string, string> parameters)
        {
            return parameters.ContainsKey("v") ? parameters["v"] : "";
        }

        private static string GetPlaylistId(Dictionary<string, string> parameters)
        {
            var id = parameters.ContainsKey("list") ? parameters["list"] : "";
            if (id.Substring(0, 2).ToLowerInvariant() == "pl") id = id.Substring(2);
            return id;
        }
        */
    }
}
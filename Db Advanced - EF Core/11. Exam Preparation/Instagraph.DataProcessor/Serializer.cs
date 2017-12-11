namespace Instagraph.DataProcessor
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using Data;
    using ModelsDto;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportUncommentedPosts(InstagraphContext context)
        {
            var posts = context.Posts
                .Where(p => p.Comments.Count == 0)
                .OrderBy(p => p.Id)
                .Select(p => new ExportPostDto
                {
                    Id = p.Id,
                    Picture = p.Picture.Path,
                    User = p.User.Username
                })
                .ToArray();

            string json = JsonConvert.SerializeObject(posts, Formatting.Indented, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            return json;
        }

        public static string ExportPopularUsers(InstagraphContext context)
        {
            var users = context.Users
                .Where(u => u.Posts
                    .Any(p => p.Comments
                        .Any(c => u.Followers
                            .Any(f => f.FollowerId == c.UserId && f.UserId == u.Id))))
                .Select(u => new
                {
                    u.Id,
                    u.Username,
                    Followers = u.Followers.Count
                })
                .ToList()
                .OrderByDescending(u => u.Id)
                .Select(u => new PopularUsersDto
                {
                    Username = u.Username,
                    Followers = u.Followers
                });

            string json = JsonConvert.SerializeObject(users, Formatting.Indented, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            return json;
        }

        public static string ExportCommentsOnPosts(InstagraphContext context)
        {
            //var comments = context.Users
            //    .OrderByDescending(u => u.Posts.OrderByDescending(c => c.Comments.Count).Count())
            //    .Select(u => new
            //    {
            //        u.Username,
            //        MostComments = u.Posts.Count == 0 ? 0 : u.Posts.First().Comments.Count
            //    })
            //    .OrderByDescending(u => u.MostComments)
            //    .ThenBy(u => u.Username);

            var comments = context.Users
                .Select(u => new
                {
                    u.Username,
                    MostComments = u.Posts.OrderByDescending(c => c.Comments.Count).First().Comments.Count()
                })
                .OrderByDescending(u => u.MostComments)
                .ThenBy(u => u.Username)
                .ToList();

            XDocument xmlDoc = new XDocument();
            xmlDoc.Add(new XElement("users"));

            foreach (var comment in comments)
            {
                xmlDoc.Root.Add(new XElement("user",
                    new XElement("username", comment.Username),
                    new XElement("most_comments", comment.MostComments)));
            }

            return xmlDoc.ToString();
        }
    }
}
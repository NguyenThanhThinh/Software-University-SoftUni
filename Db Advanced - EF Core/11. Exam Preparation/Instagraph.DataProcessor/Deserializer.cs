namespace Instagraph.DataProcessor
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    using System.Xml.Linq;

    using Newtonsoft.Json;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Models;
    using ModelsDto;

    public class Deserializer
    {
        public static string ImportPictures(InstagraphContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var jsonPictures = JsonConvert.DeserializeObject<Picture[]>(jsonString).ToList();

            var paths = jsonPictures
                .Select(p => p.Path)
                .ToList();

            foreach (var pic in jsonPictures)
            {
                string path = pic.Path;
                if ((path is null ? 0 : path.Length) <= 0 || pic.Size <= 0.0M)
                {
                    sb.AppendLine(ReturnMessages.Error);
                    continue;
                }

                if (paths.Count(p => p != null && p.Equals(path)) > 1)
                {
                    sb.AppendLine(ReturnMessages.Error);
                    continue;
                }

                sb.AppendFormat(ReturnMessages.Picture, path);
                sb.AppendLine();
            }

            jsonPictures.RemoveAll(p => p?.Path == null || p.Path.Length == 0);

            context.Pictures.AddRange(jsonPictures);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportUsers(InstagraphContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var jsonUsers = JsonConvert.DeserializeObject<UserDto[]>(jsonString);

            foreach (var user in jsonUsers)
            {
                if (user?.Username == null || user?.Password == null || user?.ProfilePicture == null)
                {
                    sb.AppendLine(ReturnMessages.Error);
                    continue;
                }

                bool userExist = context.Users
                    .Any(u => u.Username == user.Username);

                if (userExist)
                {
                    sb.AppendLine(ReturnMessages.Error);
                    continue;
                }

                int profPicId = context.Pictures
                    .Where(p => p.Path.Equals(user.ProfilePicture))
                    .Select(p => p.Id)
                    .SingleOrDefault();

                User currentUser = new User
                {
                    Username = user.Username,
                    Password = user.Password,
                    ProfilePictureId = profPicId
                };

                sb.AppendLine(String.Format(ReturnMessages.User, user.Username));
                context.Users.Add(currentUser);
                context.SaveChanges();
            }

            return sb.ToString();
        }

        public static string ImportFollowers(InstagraphContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var jsonUsers = JsonConvert.DeserializeObject<UserFollowerDto[]>(jsonString);

            foreach (var user in jsonUsers)
            {
                string usernameToFollow = user.User;
                string usernameFollower = user.Follower;

                if (usernameToFollow == null || usernameFollower == null)
                {
                    sb.AppendLine(ReturnMessages.Error);
                    continue;
                }

                int userFollowerId = context.Users
                    .Where(u => u.Username == usernameFollower)
                    .Select(u => u.Id)
                    .FirstOrDefault();

                int userFollowedId = context.Users
                    .Where(u => u.Username == usernameToFollow)
                    .Select(u => u.Id)
                    .FirstOrDefault();

                bool followedWithFollowerExist = context.UsersFollowers
                    .Any(uf => uf.UserId == userFollowedId && uf.FollowerId == userFollowerId);

                if (userFollowerId >= 1 && userFollowedId >= 1 && !followedWithFollowerExist)
                {
                    sb.AppendLine(String.Format(ReturnMessages.UserFollower, usernameFollower, usernameToFollow));

                    UserFollower userFollower = new UserFollower
                    {
                        UserId = userFollowedId,
                        FollowerId = userFollowerId
                    };

                    context.Users
                        .FirstOrDefault(u => u.Username == usernameToFollow)
                        .Followers
                        .Add(userFollower);

                    context.SaveChanges();
                }
                else
                {
                    sb.AppendLine(ReturnMessages.Error);
                }
            }

            return sb.ToString();
        }

        public static string ImportPosts(InstagraphContext context, string xmlString)
        {
            var sb = new StringBuilder();

            XDocument xmlDoc = XDocument.Parse(xmlString);

            var rootElements = xmlDoc.Root.Elements();

            foreach (var element in rootElements)
            {
                string caption = element.Element("caption")?.Value;
                string username = element.Element("user")?.Value;
                string picturePath = element.Element("picture")?.Value;

                if (caption != null && username != null && picturePath != null)
                {
                    int userId = context.Users
                        .Where(u => u.Username == username)
                        .Select(u => u.Id)
                        .FirstOrDefault();

                    int pictureId = context.Pictures
                        .Where(p => p.Path == picturePath)
                        .Select(p => p.Id)
                        .FirstOrDefault();

                    if (userId == 0 || pictureId == 0)
                    {
                        sb.AppendLine(ReturnMessages.Error);
                        continue;
                    }

                    Post post = new Post
                    {
                        Caption = caption,
                        UserId = userId,
                        PictureId = pictureId
                    };

                    context.Posts.Add(post);
                    context.SaveChanges();
                    sb.AppendLine(String.Format(ReturnMessages.Post, caption));
                    continue;
                }

                sb.AppendLine(ReturnMessages.Error);
            }

            return sb.ToString();
        }

        public static string ImportComments(InstagraphContext context, string xmlString)
        {
            var sb = new StringBuilder();

            XDocument xmlDoc = XDocument.Parse(xmlString);

            var rootElements = xmlDoc.Root.Elements();

            foreach (var element in rootElements)
            {
                string content = element.Element("content")?.Value;
                string username = element.Element("user")?.Value;
                var postIdStr = element.Element("post");

                int postId;

                bool error = ElementsValueAreCorrect(postIdStr, out postId);
                bool userAndPostDontExists = CheckIfUserOrPostDontExists(username, postId, context);

                if (error || userAndPostDontExists)
                {
                    sb.AppendLine(ReturnMessages.Error);
                    continue;
                }

                int userId = context.Users
                    .Where(u => u.Username == username)
                    .Select(u => u.Id)
                    .FirstOrDefault();

                Comment comment = new Comment
                {
                    Content = content,
                    UserId = userId,
                    PostId = postId
                };

                sb.AppendLine(String.Format(ReturnMessages.Comment, content));
                context.Comments.Add(comment);
            }

            context.SaveChanges();
            return sb.ToString();
        }

        private static bool ElementsValueAreCorrect(XElement postIdStr, out int postId)
        {
            if (postIdStr != null)
            {
                string str = postIdStr.Attribute("id")?.Value;

                if (str != null)
                {
                    postId = int.Parse(str);
                    return false;
                }

                postId = 0;
                return true;
            }

            postId = 0;
            return true;
        }

        private static bool CheckIfUserOrPostDontExists(string username, int postId, InstagraphContext context)
        {
            if (postId == 0)
            {
                return true;
            }

            bool postExist = !context.Posts
                .Any(p => p.Id == postId);

            bool userExist = !context.Users
                .Any(u => u.Username == username);

            return postExist || userExist;
        }
    }
}
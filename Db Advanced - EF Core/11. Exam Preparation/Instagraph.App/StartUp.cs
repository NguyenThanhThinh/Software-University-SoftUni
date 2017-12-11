namespace Instagraph.App
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using AutoMapper;
    using Data;
    using DataProcessor;
    using System.Text;
    using Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(options => options.AddProfile<InstagraphProfile>());

            Console.WriteLine(ResetDatabase());

            Console.WriteLine(ImportData());

            //ExportData();

        }

        private static string ImportData()
        {
            StringBuilder sb = new StringBuilder();

            using (var context = new InstagraphContext())
            {
                string picturesJson = File.ReadAllText("files/input/pictures.json");

                sb.AppendLine(Deserializer.ImportPictures(context, picturesJson));

                string usersJson = @"[{'Username':'RoundInspecindi','Password':'AdKs>q]u7P`C','ProfilePicture':'src/folders/resources/images/story/browsed/jpg/p27t303Lra.jpg'},{'Username':'AryaNinehow','Password':'X6j>`Huf2F(I','ProfilePicture':'src/folders/resources/images/profile/blocked/jpeg/fB3x0NwaNY.jpeg'},{'Username':'ScoreAntigarein','ProfilePicture':'src/folders/resources/images/profile/reformatted/png/4Hg7J3qBNc.png'},{'ProfilePicture':'src/folders/resources/images/mobile/blocked/digi/3ISlOl969f.digi'},{'Username':'RoundArmydsa','Password':'SZ?F-:hW','ProfilePicture':'src/folders/resources/images/story/blocked/jpeg/6Zjri62vV7.jpeg'}]";
                //File.ReadAllText("files/input/users.json");

                sb.AppendLine(Deserializer.ImportUsers(context, usersJson));

                //string followersJson = File.ReadAllText("files/input/users_followers.json");

                //sb.AppendLine(Deserializer.ImportFollowers(context, followersJson));

                //string postsXml = File.ReadAllText("files/input/posts.xml");

                //sb.AppendLine(Deserializer.ImportPosts(context, postsXml));

                //string commentsXml = File.ReadAllText("files/input/comments.xml");

                //sb.AppendLine(Deserializer.ImportComments(context, commentsXml));
            }

            string result = sb.ToString().Trim();
            return result;
        }

        private static void ExportData()
        {
            using (var context = new InstagraphContext())
            {
                string uncommentedPostsOutput = Serializer.ExportUncommentedPosts(context);

                File.WriteAllText("files/output/UncommentedPosts.json", uncommentedPostsOutput);

                string usersOutput = Serializer.ExportPopularUsers(context);

                File.WriteAllText("files/output/PopularUsers.json", usersOutput);

                string commentsOutput = Serializer.ExportCommentsOnPosts(context);

                File.WriteAllText("files/output/CommentsOnPosts.xml", commentsOutput);
            }
        }

        private static string ResetDatabase()
        {
            using (var context = new InstagraphContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            return $"Database reset succsessfully.";
        }
    }
}
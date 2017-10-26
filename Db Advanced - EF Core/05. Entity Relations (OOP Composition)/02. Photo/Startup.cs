namespace _02._Photo
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Photo;
    using Photo.Models;

    public class Startup
    {
        public static void Main()
        {
            PhotoContext db = new PhotoContext();
            db.Database.Migrate();


        }

        public static void Seed(PhotoContext db)
        {
            Photographer photographer = new Photographer()
            {
                Username = "Kiro",
                Email = "kircho@abv.bg",
                Password = "123456",
                BirthDate = new DateTime(1990, 10, 02),
                RegisteredDate = new DateTime(2017, 10, 10)
            };

            Photographer photographerTwo = new Photographer()
            {
                Username = "Stefan",
                Email = "stefan@abv.bg",
                Password = "128856",
                BirthDate = new DateTime(1989, 09, 02),
                RegisteredDate = new DateTime(2016, 10, 10)
            };

            Photographer photographerThree = new Photographer()
            {
                Username = "Boris",
                Email = "boris@abv.bg",
                Password = "128856",
                BirthDate = new DateTime(1977, 09, 02),
                RegisteredDate = new DateTime(2016, 01, 10)
            };

            Album album = new Album()
            {
                BackgroundColor = "Black",
                IsPublic = true
            };

            Album albumTwo = new Album()
            {
                BackgroundColor = "White",
                IsPublic = false
            };

            PhotographerAlbum photographerAlbum = new PhotographerAlbum()
            {
                Album = album,
                Photographer = photographer
            };

            PhotographerAlbum photographerAlbumTwo = new PhotographerAlbum()
            {
                Album = album,
                Photographer = photographerTwo
            };

            PhotographerAlbum photographerAlbumThree = new PhotographerAlbum()
            {
                Album = albumTwo,
                Photographer = photographerTwo
            };

            PhotographerAlbum photographerAlbumFour = new PhotographerAlbum()
            {
                Album = albumTwo,
                Photographer = photographerThree
            };

            Picture picture = new Picture()
            {
                Caption = "Nature",
                Path = @"C:\Users\Admin\Desktop\Pictures",
                Title = "SummerView"
            };

            Picture pictureOne = new Picture()
            {
                Caption = "Animals",
                Path = @"C:\Users\Admin\Desktop\Pictures",
                Title = "Zoo"
            };

            Picture pictureTwo = new Picture()
            {
                Caption = "Forest",
                Path = @"C:\Users\Admin\Desktop\Pictures",
                Title = "Tree"
            };

            db.PictureAlbums.Add(new PictureAlbum()
            {
                Album = album,
                Picture = picture
            });

            db.PictureAlbums.Add(new PictureAlbum()
            {
                Album = album,
                Picture = pictureOne
            });

            db.PictureAlbums.Add(new PictureAlbum()
            {
                Album = albumTwo,
                Picture = pictureTwo
            });

            db.SaveChanges();
        }
    }
}
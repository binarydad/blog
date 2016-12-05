namespace BinaryDad.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BlogContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var defaultBlogId = new Guid("A0BA2F4A-7954-47F0-968B-5D13625BA8CA");
            var defaultHomeId = new Guid("4B33B37E-5A49-4C70-9757-2C323019827D");

            var home = new Page
            {
                ID = defaultHomeId,
                Title = "Home",
                Path = "",
                Body = "Welcome",
                Published = new DateTime(2014, 5, 1),
                Revision = 1
            };

            var about = new Page
            {
                ID = Guid.NewGuid(),
                Title = "About Me",
                Path = "about-me",
                Body = "This a page about me",
                Published = new DateTime(2014, 5, 1),
                Revision = 1,
                Parent = home
            };

            var projects = new Page
            {
                ID = Guid.NewGuid(),
                Title = "Projects",
                Path = "projects",
                Body = "This is where I'll show all my projects",
                Published = new DateTime(2014, 5, 1),
                Revision = 1,
                Parent = home
            };

            //context.Pages.AddOrUpdate(home);
            //context.Pages.AddOrUpdate(about);
            //context.Pages.AddOrUpdate(projects);

            //context.Blogs.AddOrUpdate(
            //    new Blog
            //    {
            //        ID = defaultBlogId,
            //        Title = "Programming Blog",
            //        Path = "blog",
            //        Body = "A blog about programming",
            //        Published = new DateTime(2014, 6, 24),
            //        Revision = 1,
            //        Entries = new[]
            //        {
            //            new BlogEntry 
            //            {
            //                ID = Guid.NewGuid(),
            //                Title = "Hello, world!",
            //                Path = "hello-world",
            //                Summary = "Just an introductory blog entry.",
            //                Body = "This is a post",
            //                Published = new DateTime(2014, 6, 24),
            //                Revision = 1
            //            },

            //            new BlogEntry 
            //            {
            //                ID = Guid.NewGuid(),
            //                Title = "Second post",
            //                Path = "second-post",
            //                Summary = "Testing another post. Hope you like it.",
            //                Body = "This is another post!",
            //                Published = new DateTime(2014, 6, 24),
            //                Revision = 1
            //            }
            //        }
            //    });
        }
    }
}

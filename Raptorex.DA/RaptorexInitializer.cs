using Raptorex.BO.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raptorex.DA
{
    public class RaptorexInitializer : DropCreateDatabaseAlways<RaptorexContext>
    {
        protected override void Seed(RaptorexContext context)
        {
            var users = new List<RaptorexUser>()
            {
                new RaptorexUser(){ 
                    Email = "vasja@mail.com", 
                    FirstName="Vasja", 
                    LastName="Pupkinidze", 
                    Username = "vpupkin",
                    PasswordHash = "ABJFCcSMF4Aeee91YkL7xfna6VsqUvgBgWbgsPE5/tlzVhE9ZDnAfh1dsrdWWOmsBA==" //password0
                },
                new RaptorexUser(){ 
                    Email = "peter@mail.com", 
                    FirstName="Peter", 
                    LastName="Petrovson", 
                    Username = "petrovson",
                    PasswordHash = "APpPGJfCoi91qNnjzDhdj70RopuoJoHT9uMzZPa+L/A4iDqVHssShBZQRwy0e0tBDA==" //password1
                }
            };
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            var subforums = new List<Subforum>()
            {
                new Subforum(){ Title = "General" }
            };
            subforums.ForEach(s => context.Subforums.Add(s));
            context.SaveChanges();

            var forumTopics = new List<ForumTopic>() 
            {
                new ForumTopic(){ Title = "Thread 1", TopicSubforumId = subforums.FirstOrDefault().ID, CreatedBy = users.FirstOrDefault(), CreatedOn = DateTime.Now}
            };
            forumTopics.ForEach(t => context.ForumTopics.Add(t));
            context.SaveChanges();

            var forumMessages = new List<ForumPost>()
            {
                new ForumPost(){ Text = "Hello, world!", MessageTopicId = forumTopics.FirstOrDefault().ID, CreatedOn=DateTime.Now }
            };
            forumMessages.ForEach(m => context.ForumPosts.Add(m));
            context.SaveChanges();
        }
    }
}

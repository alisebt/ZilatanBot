using Quartz;
using Quartz.Impl;
using System;
using System.Web.Mvc;

namespace ZilatanBot.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Job();
            ViewBag.Message = TelegramHelper.GetMe();
            return View();
        }
        public static void CheckUpdates()
        {
            var updates = TelegramHelper.GetUpdates();
            foreach (var item in updates.Data.result)
            {
                var db = new DataAccess.MessageRepository();
                var thisItem = db.GetByMessageID(item.message.message_id);
                if (thisItem == null)
                {
                    var addResult = db.Add(new DomainModel.Models.Message { createDate = DateTime.Now, date = item.message.date, from_id = item.message.from.id, from_username = item.message.from.username, text = item.message.text, message_Id = item.message.message_id, Id = 0 });

                    string[] keyborad = new string[] { "", "", "" };
                    TelegramHelper.SendMessage(item.message.from.id.ToString(), "این پیام دریافتی از شماست  : " + item.message.text);
                }

            }
        }
        public void Job()
        {
            try
            {
                Common.Logging.LogManager.Adapter = new Common.Logging.Simple.ConsoleOutLoggerFactoryAdapter { Level = Common.Logging.LogLevel.Info };

                // Grab the Scheduler instance from the Factory 
                IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();

                // and start it off
                scheduler.Start();

                // define the job and tie it to our HelloJob class
                IJobDetail job = JobBuilder.Create<HelloJob>()
                    .WithIdentity("job1", "group1")
                    .Build();

                // Trigger the job to run now, and then repeat every 10 seconds
                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("trigger1", "group1")
                    .StartNow()
                    .WithSimpleSchedule(x => x
                        .WithIntervalInSeconds(10)
                        .RepeatForever())
                    .Build();

                // Tell quartz to schedule the job using our trigger
                scheduler.ScheduleJob(job, trigger);

                // some sleep to show what's happening
                //Thread.Sleep(TimeSpan.FromSeconds(10));

                // and last shut down the scheduler when you are ready to close your program
                //scheduler.Shutdown();
            }
            catch (SchedulerException se)
            {
                Console.WriteLine(se);
            }

            Response.Write("Press any key to close the application");
        }
        public class HelloJob : IJob
        {
            public void Execute(IJobExecutionContext context)
            {
                CheckUpdates();
            }
        }
    }
}




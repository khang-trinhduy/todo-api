using System;
using Microsoft.Extensions.DependencyInjection;
using todo_api.Models;
using todo_api.Services;

namespace todo_api.Controllers
{
    public static class SeedTask
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var service = new TodoServices(serviceProvider.GetRequiredService<ITodoDatabaseSettings>());

            if (service.Get().Count > 0)
            {
                return;
            }

            service.Create(new Task
            {
                Name = "Do the laundry",
                IsCompleted = false,
                Steps = new System.Collections.Generic.List<Task> {
                    service.Create(new Task {
                        Name = "Buy ingredients",
                        IsCompleted = true,
                        Steps = null
                    }),

                    service.Create(new Task
                    {
                        Name = "Cook the meal",
                        IsCompleted = false,
                        Steps = null
                    })

                }
            });

            service.Create(new Task
            {
                Name = "Do the cooking",
                IsCompleted = false,
                Steps = new System.Collections.Generic.List<Task> { }
            });
        }
    }
}
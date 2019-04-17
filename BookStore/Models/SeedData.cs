using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BookStoreContext>>()))
            {
                // Look for any movies.
                if (context.Book.Any())
                {
                    return;   // DB has been seeded
                }

                context.Book.AddRange(
                    new Book
                    {
                        Author = "Diana Gabaldon",
                        ISBN = "123456789",
                        Name = "Outlander",
                        PlotReview = @" Is the first in a series of eight historical multi-genre novels by Diana Gabaldon. Published in 1991, it focuses 
                                     on the Second World War-era nurse Claire Randall, who travels through time to 18th century Scotland and finds adventure 
                                     and romance with the dashing Jamie Fraser.[1] A mix of several genres, the Outlander series has elements of historical 
                                     fiction, romance, adventure and science fiction/fantasy.",
                        Type = "Cience Fiction"
                    },
                    new Book
                    {
                        Author = "J. K. Rowling",
                        ISBN = "23568974",
                        Name = "Harry Potter",
                        PlotReview = @"Is a series of fantasy novels written by British author J. K. Rowling. The novels chronicle the lives of a young wizard, 
                                    Harry Potter, and his friends Hermione Granger and Ron Weasley, all of whom are students at Hogwarts School of Witchcraft and Wizardry. 
                                    The main story arc concerns Harry's struggle against Lord Voldemort, a dark wizard who intends to become immortal, overthrow the wizard 
                                    governing body known as the Ministry of Magic, and subjugate all wizards and Muggles (non-magical people).",
                        Type = "Fantasy"
                    },
                    new Book
                    {
                        Author = "Suzanne Collins",
                        ISBN = "12562345",
                        Name = "The Hunger Games",
                        PlotReview = @"Is a 2008 dystopian novel by the American writer Suzanne Collins. It is written in the voice of 16-year-old Katniss Everdeen, 
                                    who lives in the future, post-apocalyptic nation of Panem in North America. The Capitol, a highly advanced metropolis, 
                                    exercises political control over the rest of the nation. The Hunger Games is an annual event in which one boy and one girl 
                                    aged 12–18 from each of the twelve districts surrounding the Capitol are selected by lottery to compete in a televised 
                                    Battle royal to the death.",
                        Type = "Distopia"
                    },
                    new Book
                    {
                        Author = "Stephen King",
                        ISBN = "7894561230",
                        Name = "The Dark Tower",
                        PlotReview = @"It describes a ""gunslinger"" and his quest toward a tower, the nature of which is both physical and metaphorical. The series, 
                                    and its use of the Dark Tower, expands upon Stephen King's multiverse and in doing so, links together many of his other novels. 
                                    In addition to the eight novels of the series proper that comprise 4,250 pages, many of King's other books relate to the story, 
                                    introducing concepts and characters that come into play as the series progresses.",
                        Type = "Fantasy"
                    });

                context.SaveChanges();
            }
        }
    }
}

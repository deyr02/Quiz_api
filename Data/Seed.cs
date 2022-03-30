using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Quiz_api.Models;

namespace Quiz_api.Data
{
    public class Seed
    {
        public static async Task SeedData (DataContext context, UserManager<AppUser> userManager){
            if (!userManager.Users.Any()){
                var users = new List<AppUser>{

                new AppUser {
                    FirstName = "Rajib",
                    LastName= "Dey",
                    DOB = DateTime.Parse("01 Mar 1988"),
                    Email= "rajib_dey@rocketmail.com",
                    UserName = "Rajib_dey"

                },
                 new AppUser {
                    FirstName = "Polash",
                    LastName= "Paul",
                    DOB = DateTime.Parse("15 Mar 1988"),
                    Email= "polash_paul@rocketmail.com",
                    UserName = "Polash_paul"


                }, new AppUser {
                    FirstName = "Partheo",
                    LastName= "Sumon",
                    DOB = DateTime.Parse("01 Mar 1988"),
                    Email= "partho_sumon@rocketmail.com",
                    UserName = "Partho_summon"


                }, new AppUser {
                    FirstName = "Ripon",
                    LastName= "Saha",
                    DOB = DateTime.Parse("01 Mar 1988"),
                    Email= "ripon_saha@rocketmail.com",
                    UserName = "Ripon_saha"


                }
            };

            foreach (AppUser user in users){
               await userManager.CreateAsync(user, "P@ssw0rd");
            }
                
            }


            //https://www.drivingtests.co.nz/roadcode/car/core/56/
            if(!context.Quizzes.Any()){
                var Quizzes = new List<Quiz>{

                    //quiz -1
                    new Quiz{
                        ID=1,
                        Question= "When are you allowed to pass another vehicle to its left? Select all that apply",
                        IsAnswerMultiple = true,
                        Answers = "1,2,3",
                        ContiansImage = false,

                        options = new List<Option>(){
                            //option-1
                            new Option{
                                ID =1,
                                Description= "A police officer has directed you to",
                                ContiansImage = false,
                                URL= null,
                                QuizID=1
                            },

                            //option-2
                            new Option{
                                ID =2,
                                Description= "There are two or more lanes on your side of the road and it's safe to pass",
                                ContiansImage = false,
                                URL= null,
                                QuizID=1
                            },
                            //option-3
                            new Option{
                                ID =3,
                                Description= "The car you will pass is signalling a right turn and is either slowing down or has stopped",
                                ContiansImage = false,
                                URL= null,
                                QuizID=1
                            },
                            //option-4
                            new Option{
                                ID =4,
                                Description= "The vehicle is a motorbike or scooter on a single lane road and therefore there's enough room to pass safely",
                                ContiansImage = false,
                                URL= null,
                                QuizID=1
                            }

                            
                        }

                    },


                    //Quiz-2

                     new Quiz{
                        ID=2,
                        Question= "What does 'speed limit' mean?",
                        IsAnswerMultiple = false,
                        Answers = "6",
                        ContiansImage = true,
                        URL= "Quiz-2.gif",

                        options = new List<Option>(){
                            //option-1
                            new Option{
                                ID =5,
                                Description= "The recommended speed for that road",
                                ContiansImage = false,
                                URL= null,
                                QuizID=2
                            },

                            //option-2
                            new Option{
                                ID =6,
                                Description= "The maximum speed for that road in good conditions",
                                ContiansImage = false,
                                URL= null,
                                QuizID=2
                            },
                            //option-3
                            new Option{
                                ID =7,
                                Description= "The minimum speed for that road in good conditions",
                                ContiansImage = false,
                                URL= null,
                                QuizID=2
                            },
                            //option-4
                            new Option{
                                ID =8,
                                Description= "The maximum speed except for when you are overtaking another vehicle",
                                ContiansImage = false,
                                URL= null,
                                QuizID=2
                            }

                            
                        }

                    },

                    





                    ///Quiz -3 
                     new Quiz{
                        ID=3,
                        Question= "How many standard drinks can you have before driving if you are under 20 years old?",
                        IsAnswerMultiple = false,
                        Answers = "12",
                        ContiansImage = false,

                        options = new List<Option>(){
                            //option-1
                            new Option{
                                ID =9,
                                Description= "One",
                                ContiansImage = false,
                                URL= null,
                                QuizID=3
                            },

                            //option-2
                            new Option{
                                ID =10,
                                Description= "Two",
                                ContiansImage = false,
                                URL= null,
                                QuizID=3
                            },
                            //option-3
                            new Option{
                                ID =11,
                                Description= "Three",
                                ContiansImage = false,
                                URL= null,
                                QuizID=3
                            },
                            //option-4
                            new Option{
                                ID =12,
                                Description= "None",
                                ContiansImage = false,
                                URL= null,
                                QuizID=3
                            }

                            
                        }

                    },




                    ///Quiz -4
                     new Quiz{
                        ID=4,
                        Question= "How long should you signal for before passing another vehicle?",
                        IsAnswerMultiple = false,
                        Answers = "15",
                        ContiansImage = true,
                        URL= "Quiz_4.jpg",

                        options = new List<Option>(){
                            //option-1
                            new Option{
                                ID =13,
                                Description= "One second",
                                ContiansImage = false,
                                URL= null,
                                QuizID=4
                            },

                            //option-2
                            new Option{
                                ID =14,
                                Description= "Two Seconds",
                                ContiansImage = false,
                                URL= null,
                                QuizID=4
                            },
                            //option-3
                            new Option{
                                ID =15,
                                Description= "Three Seconds",
                                ContiansImage = false,
                                URL= null,
                                QuizID=4
                            },
                            //option-4
                            new Option{
                                ID =16,
                                Description= "Only signal if there's another vehicale behind you or one coming towards you.",
                                ContiansImage = false,
                                URL= null,
                                QuizID=4
                            }

                            
                        }

                    },
                    





                    //https://www.drivingtests.co.nz/roadcode/car/core/56/
                    ///Quiz-5
                     new Quiz{
                        ID=5,
                        Question= "When should you apply the four-second rule?",
                        IsAnswerMultiple = false,
                        Answers = "17",
                        ContiansImage = false,
                        URL=null,

                        options = new List<Option>(){
                            //option-1
                            new Option{
                                ID =17,
                                Description= "If the road is wet or frosty, or you are towing a trailer",
                                ContiansImage = false,
                                URL= null,
                                QuizID=5
                            },

                            //option-2
                            new Option{
                                ID =18,
                                Description= "If your brakes are almost worn out",
                                ContiansImage = false,
                                URL= null,
                                QuizID=5
                            },
                            //option-3
                            new Option{
                                ID =19,
                                Description= "If you're travelling at more than 100km/h",
                                ContiansImage = false,
                                URL= null,
                                QuizID=5
                            },
                            //option-4
                            new Option{
                                ID =20,
                                Description= "At night",
                                ContiansImage = false,
                                URL= null,
                                QuizID=5
                            }

                            
                        }

                    },











                    // ///Template
                    //  new Quiz{
                    //     ID=0,
                    //     Question= "",
                    //     IsAnswerMultiple = false,
                    //     Answers = "",
                    //     ContiansImage = false,

                    //     options = new List<Option>(){
                    //         //option-1
                    //         new Option{
                    //             ID =1,
                    //             Description= "",
                    //             ContiansImage = false,
                    //             URL= null,
                    //             QuizID=1
                    //         },

                    //         //option-2
                    //         new Option{
                    //             ID =2,
                    //             Description= "",
                    //             ContiansImage = false,
                    //             URL= null,
                    //             QuizID=1
                    //         },
                    //         //option-3
                    //         new Option{
                    //             ID =3,
                    //             Description= "",
                    //             ContiansImage = false,
                    //             URL= null,
                    //             QuizID=1
                    //         },
                    //         //option-4
                    //         new Option{
                    //             ID =4,
                    //             Description= "",
                    //             ContiansImage = false,
                    //             URL= null,
                    //             QuizID=1
                    //         }

                            
                    //     }

                    // }





                };


                foreach(Quiz quiz in Quizzes){
                    context.Quizzes.Add(quiz);

                    foreach(Option option in quiz.options){
                        context.Options.Add(option);
                    }
                }

                await context.SaveChangesAsync();

            }
            
            
        }
    }
}
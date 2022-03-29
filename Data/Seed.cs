using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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


            if(!context.Quizzes.Any()){
                var Quizzes = new List<Quiz>{
                    new Quiz{
                        Question= "input the question here",
                        Answer = 1,
                        ContiansImage = true,

                        QuizImages = new List<QuizImage>(){
                            new QuizImage{
                                ID= 1,
                                URL= "Just put the image name example ------  'Imgae.jpg'  --------   " 
                            }
                        },

                        options = new List<Option>(){
                            //option-1
                            new Option{
                                ID =1,
                                Description= "quiz option goes here -- 1",
                                ContiansImage = true,
                                
                                

                            }
                        }

                    }
                };
            }
            
            
        }
    }
}
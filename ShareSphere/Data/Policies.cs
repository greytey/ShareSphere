using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSphere.Data
{
    public class Policies
    {
        public static bool checkUsername(string username)
        {
            if(username.Length >= 3 && username != null)
            {
                if (!username.Contains(" "))
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Username has whitespaces");
                    return false;
                }
            } else
            {
                Console.WriteLine("Username is too short");
                return false;
            }

        }

        public static bool checkEmail(string email)
        {
            if (!email.Contains(" "))
            {
                if (email.Contains("@"))
                {
                    if (email.Contains("."))
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Email has no . symbol");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Email has no @ symbol");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Email has whitespaces");
                return false;
            }
        }

        public static bool checkPassword(string password)
        {
            if(password.Length >= 8 && password != null)
            {
                if (!password.Contains(" "))
                {
                    if (password.Any(char.IsDigit))
                    {
                        if (password.Any(char.IsLetter))
                        {
                            if (password.Any(char.IsUpper))
                            {
                                if (password.Any(char.IsLower))
                                {
                                    return true;
                                }
                                else
                                {
                                    Console.WriteLine("Password has no lower case letter");
                                    return false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Password has no upper case letter");
                                return false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Password has no letter");
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Password has no number");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Password has whitespaces");
                    return false;
                }
            } else
            {
                Console.WriteLine("Password is too short");
                return false;
            }
            
        }
    }
}
// Nvm
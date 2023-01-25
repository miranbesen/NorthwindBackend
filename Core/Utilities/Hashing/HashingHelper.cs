using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Hashing
{
    public class HashingHelper
    {
        /// <summary>
        /// Password hash'ini oluşturuyoruz.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) //Out keyword parametre olarak gönderdiğimiz zaman değişen nesne, aynı zamanda bizim o byte array'imize aktarılacak (gönderilen yerdeki).
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) //Hashing algoritmamız.
            {
                passwordSalt = hmac.Key; //Oluşturmuş olduğu salt'ı key olarak passwordSalt içine atadık.
                passwordHash = hmac.ComputeHash(buffer: Encoding.UTF8.GetBytes(password)); //oluşan hash'i passwordHash'e atamış olduk.
            }
        }

        /// <summary>
        /// Password hash'ini doğrulama. Doğru ise true yanlış ise false dönderiyor.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        /// <returns></returns>
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                var computedHash = hmac.ComputeHash(buffer: Encoding.UTF8.GetBytes(password)); //kullanicinin göndermiş olduğu password'un hash'ini alıp passowrdHash ile kıyaslama yapıyor.
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }


    }
}

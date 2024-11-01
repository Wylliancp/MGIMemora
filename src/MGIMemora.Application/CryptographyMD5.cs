namespace MGIMemora.Application;

public static class CryptographyMd5
{
 public static string ComputeHash(this string input)
 {
   try
   {
    var md5 = System.Security.Cryptography.MD5.Create();
    var inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
    var hash = md5.ComputeHash(inputBytes);
    var stringBuilder = new System.Text.StringBuilder();
    foreach (var item in hash)
    {
     stringBuilder.Append(item.ToString("X2"));
    }
    return stringBuilder.ToString();
   }
   catch (Exception ex)
   {
    throw new Exception(ex.Message);
   }
 }
}
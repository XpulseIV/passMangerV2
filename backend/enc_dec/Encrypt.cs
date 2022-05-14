namespace backend.enc_dec;

public static class Encrypt
{
    private static void EncryptString(ref string str, ref int[] key)
    {
        var strCharArray = str.ToCharArray();

        foreach (var digit in key)
        {
            switch (digit)
            {
                case 0:
                    for (var i = 0; i < strCharArray.Length; i++)
                    {
                        strCharArray[i]++;
                    }
                    break;
                case 1:
                    for (var i = 0; i < strCharArray.Length; i++)
                    {
                        strCharArray[i] = (char)~strCharArray[i];
                    }
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 10:
                    break;
                case 11:
                    break;
                case 12:
                    break;
                case 13:
                    break;
                case 14:
                    break;
                case 15:
                    break;
            }
        }
    }
}
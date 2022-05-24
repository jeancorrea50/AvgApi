using Microsoft.Extensions.Options;
using System;
using System.Security.Cryptography;
using System.Text;

namespace AvgApi.Utilities
{
    public class EncryptionHelper
    {
        private readonly IOptions<KeysConfig> chaveConfiguracao;
        DESCryptoServiceProvider encryptionProvider = null;

        public EncryptionHelper(IOptions<KeysConfig> chaveConfiguracao)
        {
            this.chaveConfiguracao = chaveConfiguracao;

            encryptionProvider = new DESCryptoServiceProvider();
            encryptionProvider.KeySize = 64;

            encryptionProvider.IV = Convert.FromBase64String(chaveConfiguracao.Value.CryptoVector);
            encryptionProvider.Key = Convert.FromBase64String(chaveConfiguracao.Value.CryptoKey);
        }

        public string Criptografar(string text)
        {
            if (string.IsNullOrEmpty(text) == true)
            {
                return string.Empty;
            }

            StringBuilder returnText = new StringBuilder();

            char[] convertContent = text.ToCharArray();
            byte[] convertedContent = new byte[convertContent.Length];

            int indexAC = 0;
            foreach (char symbol in convertContent)
            {
                convertedContent[indexAC] = Convert.ToByte(symbol);
                indexAC++;
            }

            byte[] returnContent = encryptionProvider.CreateEncryptor().TransformFinalBlock(convertedContent, 0, convertedContent.Length);

            return Convert.ToBase64String(returnContent);
        }

        public string Descriptografar(string text)
        {
            try
            {
                if (string.IsNullOrEmpty(text) == true)
                {
                    return string.Empty;
                }

                byte[] encryptedContent = Convert.FromBase64String(text);

                byte[] convertContent = encryptionProvider.CreateDecryptor().TransformFinalBlock(encryptedContent, 0, encryptedContent.Length);
                StringBuilder convertedContent = new StringBuilder();

                foreach (byte symbol in convertContent)
                {
                    convertedContent.Append(Convert.ToChar(symbol));
                }

                return convertedContent.ToString();
            }
            catch
            {
                return text;
            }


        }
    }
}

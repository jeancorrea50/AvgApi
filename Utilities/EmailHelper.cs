//using Microsoft.Extensions.Options;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Net;
//using System.Net.Mail;
//using System.Net.Mime;
//using System.Text.RegularExpressions;

//namespace BackOffice.Infrastructure.CrossCutting.Utilities
//{
//    public class EmailHelper
//    {
//        private readonly IOptions<KeysConfig> ChaveConfiguracao;

//        public EmailHelper(IOptions<KeysConfig> chaveConfiguracao)
//        {
//            ChaveConfiguracao = chaveConfiguracao;
//        }

//        public bool EnviarMensagem(string emailPara, string para, string assunto, string mensagem)
//        {
//            try
//            {
//                MailMessage mail = new MailMessage();

//                mail.From = new MailAddress(ChaveConfiguracao.Value.EmailFrom, ChaveConfiguracao.Value.From);
//                mail.To.Add(new MailAddress(emailPara, para));
//                if (string.IsNullOrEmpty(ChaveConfiguracao.Value.EmailCCO) == false)
//                {
//                    foreach (var item in ChaveConfiguracao.Value.EmailCCO.Split(";"))
//                    {
//                        mail.Bcc.Add(new MailAddress(item));
//                    }
//                }
//                mail.Subject = assunto;
//                mail.Priority = MailPriority.High;
//                mail.IsBodyHtml = true;

//                AlternateView alterView = ContentToAlternateView(mensagem);
//                mail.AlternateViews.Add(alterView);

//                SmtpClient smtp = new SmtpClient(ChaveConfiguracao.Value.SmtpServer, Convert.ToInt32(ChaveConfiguracao.Value.SmtpPort));
//                smtp.EnableSsl = ChaveConfiguracao.Value.SmtpSecure;
//                smtp.Credentials = new NetworkCredential(ChaveConfiguracao.Value.SmtpUser, ChaveConfiguracao.Value.SmtpPassword);
//                smtp.Send(mail);

//                return true;
//            }
//            catch (Exception ex)
//            {
//                return false;
//            }
//        }

//        public bool EnviarMensagem(List<KeyValuePair<string, string>> emailPara, string assunto, string mensagem)
//        {
//            try
//            {
//                MailMessage mail = new MailMessage();

//                mail.From = new MailAddress(ChaveConfiguracao.Value.EmailFrom, ChaveConfiguracao.Value.From);

//                foreach (var item in emailPara)
//                {
//                    mail.To.Add(new MailAddress(item.Key, item.Value));
//                }

//                if (string.IsNullOrEmpty(ChaveConfiguracao.Value.EmailCCO) == false)
//                {
//                    foreach (var item in ChaveConfiguracao.Value.EmailCCO.Split(";"))
//                    {
//                        mail.Bcc.Add(new MailAddress(item));
//                    }
//                }

//                mail.Subject = assunto;
//                mail.Priority = MailPriority.High;
//                mail.IsBodyHtml = true;

//                AlternateView alterView = ContentToAlternateView(mensagem);
//                mail.AlternateViews.Add(alterView);

//                SmtpClient smtp = new SmtpClient(ChaveConfiguracao.Value.SmtpServer, Convert.ToInt32(ChaveConfiguracao.Value.SmtpPort));
//                smtp.EnableSsl = ChaveConfiguracao.Value.SmtpSecure;
//                smtp.Credentials = new NetworkCredential(ChaveConfiguracao.Value.SmtpUser, ChaveConfiguracao.Value.SmtpPassword);
//                smtp.Send(mail);

//                return true;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Erro envio de email: " + ex.Message + Environment.NewLine + ex.InnerException);

//                return false;
//            }
//        }

//        public bool EnviarMensagem(string emailPara, string para, string assunto, string mensagem, string nomeArquivo)
//        {
//            try
//            {
//                MailMessage mail = new MailMessage();

//                mail.From = new MailAddress(ChaveConfiguracao.Value.EmailFrom, ChaveConfiguracao.Value.From);
//                mail.To.Add(new MailAddress(emailPara, para));
//                mail.Subject = assunto;
//                mail.Priority = MailPriority.High;
//                mail.IsBodyHtml = true;

//                AlternateView alterView = ContentToAlternateView(mensagem);
//                mail.AlternateViews.Add(alterView);

//                mail.Attachments.Add(new Attachment(nomeArquivo));

//                SmtpClient smtp = new SmtpClient(ChaveConfiguracao.Value.SmtpServer, Convert.ToInt32(ChaveConfiguracao.Value.SmtpPort));

//                EncryptionHelper encryptionHelper = new EncryptionHelper(ChaveConfiguracao);

//                smtp.Credentials = new NetworkCredential(ChaveConfiguracao.Value.SmtpUser, encryptionHelper.Descriptografar(ChaveConfiguracao.Value.SmtpPassword));
//                smtp.Send(mail);

//                return true;
//            }
//            catch (Exception)
//            {
//                return false;
//            }
//        }


//        private static AlternateView ContentToAlternateView(string content)
//        {
//            var imgCount = 0;
//            List<LinkedResource> resourceCollection = new List<LinkedResource>();
//            foreach (Match m in Regex.Matches(content, "<img(?<value>.*?)>"))
//            {
//                imgCount++;
//                var imgContent = m.Groups["value"].Value;
//                string type = Regex.Match(imgContent, ":(?<type>.*?);base64,").Groups["type"].Value;
//                string base64 = Regex.Match(imgContent, "base64,(?<base64>.*?)\"").Groups["base64"].Value;
//                if (String.IsNullOrEmpty(type) || String.IsNullOrEmpty(base64))
//                {
//                    //ignore replacement when match normal <img> tag
//                    continue;
//                }
//                var replacement = " src=\"cid:" + imgCount + "\"";
//                content = content.Replace(imgContent, replacement);
//                var tempResource = new LinkedResource(Base64ToImageStream(base64), new ContentType(type))
//                {
//                    ContentId = imgCount.ToString()
//                };
//                resourceCollection.Add(tempResource);
//            }

//            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(content, null, MediaTypeNames.Text.Html);
//            foreach (var item in resourceCollection)
//            {
//                alternateView.LinkedResources.Add(item);
//            }

//            return alternateView;
//        }

//        public static Stream Base64ToImageStream(string base64String)
//        {
//            byte[] imageBytes = Convert.FromBase64String(base64String);
//            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
//            return ms;
//        }
//    }
//}

using System;

namespace AvgApi.Utilities
{
    public class KeysConfig
    {
        public int TimeZone { get; set; }

        public string CronIntegracao { get; set; }

        public string MessageBrokerType { get; set; }
        public string MessageBroker { get; set; }
        public string MessageBrokerGroupId { get; set; }
        public string MessageBrokerTopicoLogin { get; set; }
        public string MessageBrokerTopicoOperacao { get; set; }
        public string MessageBrokerTopicoAuditoria { get; set; }

        public string SecretKey { get; set; }
        public string IssuerToken { get; set; }
        public int TokenExpirationMinutes { get; set; }
        public string TokenAnonimo { get; set; }

        public int UserPasswordExpiration { get; set; }
        public int EmailPasswordExpiration { get; set; }

        public string TypeDB { get; set; }
        public string ConnectionDB { get; set; }

        public string TypeCache { get; set; }
        public string ConnectionCache { get; set; }

        public string EnableLog { get; set; }
        public string SwaggerVersion { get; set; }
        public string SwaggerTitle { get; set; }
        public string SwaggerDescription { get; set; }
        public string SwaggerContactName { get; set; }
        public string SwaggerContactEmail { get; set; }
        public string SwaggerContactUrl { get; set; }



        public string EmailCCO { get; set; }
        public string EmailFrom { get; set; }
        public string From { get; set; }
        public string SmtpServer { get; set; }
        public string SmtpPort { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPassword { get; set; }
        public bool SmtpSecure { get; set; }

        public string CryptoVector { get; set; }
        public string CryptoKey { get; set; }

        public string SMSUrlToken { get; set; }
        public string SMSUrlEnvio { get; set; }
        public string SMSUsuario { get; set; }
        public string SMSSenha { get; set; }
        public string SMSCampanha { get; set; }
        public string SMSToken { get; set; }

        public string BitlyUrl { get; set; }
        public string BitlyToken { get; set; }
        public string BitlyDominio { get; set; }
        public string BitlyGrupo { get; set; }

    }
}

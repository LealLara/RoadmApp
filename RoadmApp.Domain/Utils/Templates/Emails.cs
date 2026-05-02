using RoadmApp.Domain.Utils.Contants;
using RoadmApp.Domain.Utils.Enums;

namespace RoadmApp.Domain.Utils.Templates
{
    public static class EmailTemplates
    {
        public static string GetTemplate(EEmailType type)
        {
            return type switch
            {
                EEmailType.Welcome => WelcomeTemplate(),
                // EEmailType.FirstRegister => FirstRegisterTemplate(),
                EEmailType.PasswordReset => PasswordResetTemplate(),
                EEmailType.BloomingLove => BloomingLove(),

                _ => throw new ArgumentOutOfRangeException(nameof(type))
            };
        }

        private static string WelcomeTemplate()
        {
            string mailObj =
                $@"<!DOCTYPE html>
                <html lang=""pt-BR"">
                <head>
                  <meta charset=""UTF-8"">
                  <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                  <title>Boas-vindas ao RoadmApp 🐰</title>
                </head>
                
                <body style=""margin:0; padding:0; background-color:#f4f7f8; font-family:Arial, sans-serif;"">
                
                  <table width=""100%"" cellpadding=""0"" cellspacing=""0"" style=""padding:20px;"">
                    <tr>
                      <td align=""center"">
                
                        <table width=""600"" cellpadding=""0"" cellspacing=""0"" style=""background:white; border-radius:12px; overflow:hidden; box-shadow:0 4px 12px rgba(0,0,0,0.1);"">
                
                          <!-- HEADER -->
                          <tr>
                            <td style=""background:#2EC4B6; padding:30px; text-align:center; color:white;"">
                              <h1 style=""margin:0;"">🐰 RoadmApp</h1>
                              <p style=""margin:5px 0 0;"">Organize sua vida com leveza</p>
                            </td>
                          </tr>
                
                          <!-- BODY -->
                          <tr>
                            <td style=""padding:30px; color:#333;"">
                
                              <h2>Boas-vindas ao RoadmApp! 🎉</h2>
                
                              <p>
                                Sua conta foi criada com sucesso. Agora você pode organizar seus estudos, tarefas e metas com muito mais clareza.
                              </p>
                
                              <p>
                                Para acessar pela primeira vez, utilize a senha temporária abaixo:
                              </p>
                
                              <!-- SENHA TEMPORÁRIA -->
                              <div style=""text-align:center; margin:30px 0;"">
                                <div style=""background:#f0f7f6; border-radius:8px; padding:20px; border-left:4px solid #2EC4B6;"">
                                  <p style=""margin:0 0 5px; font-size:14px; color:#666;"">🔐 Senha temporária</p>
                                  <p style=""margin:0; font-size:32px; font-weight:bold; color:#2EC4B6; letter-spacing:2px;"">
                                    {PatternAccountConfig.PatternFirstRegister}
                                  </p>
                                </div>
                              </div>
                
                              <!-- ALERTA -->
                              <div style=""background:#fff3cd; border-left:4px solid #ffc107; padding:15px; margin:20px 0;"">
                                <p style=""margin:0; font-size:14px; color:#856404;"">
                                  ⚠️ <strong>Importante:</strong> Recomendamos trocar sua senha após o primeiro login por segurança.
                                </p>
                              </div>
                
                              <!-- CTA -->
                              <div style=""text-align:center; margin:30px 0;"">
                                <a href=""https://roadmapp.com/login""
                                   style=""background:#2EC4B6; color:white; padding:12px 25px; border-radius:8px; text-decoration:none; font-weight:bold;"">
                                   Começar agora 🚀
                                </a>
                              </div>
                
                              <p style=""font-size:14px; color:#777;"">
                                Se você não criou essa conta, pode ignorar este email.
                              </p>
                
                            </td>
                          </tr>
                
                          <!-- FOOTER -->
                          <tr>
                            <td style=""background:#f1f1f1; padding:20px; text-align:center; font-size:12px; color:#999;"">
                              © 2026 RoadmApp • Feito com 💙
                            </td>
                          </tr>
                
                        </table>
                
                      </td>
                    </tr>
                  </table>
                
                </body>
                </html>";

            return mailObj;
        }

        private static string BloomingLove()
        {
            string mailObj =
                $"<!DOCTYPE html>\r\n\r\n<html lang=\"pt-BR\">\r\n<head>\r\n  <meta charset=\"UTF-8\">\r\n  <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n  <title>💖 Mensagem Especial - RoadmApp</title>\r\n</head>\r\n\r\n<body style=\"margin:0; padding:0; background-color:#fff0f5; font-family:Arial, sans-serif;\">\r\n\r\n  <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" style=\"padding:20px;\">\r\n    <tr>\r\n      <td align=\"center\">\r\n\r\n        <table width=\"600\" cellpadding=\"0\" cellspacing=\"0\" style=\"background:white; border-radius:12px; overflow:hidden; box-shadow:0 4px 12px rgba(0,0,0,0.1);\">\r\n\r\n          <!-- HEADER -->\r\n          <tr>\r\n            <td style=\"background:#ff6b9d; padding:30px; text-align:center; color:white;\">\r\n              <h1 style=\"margin:0;\">💖 Mensagem Especial 💖</h1>\r\n              <p style=\"margin:5px 0 0;\">Com amor</p>\r\n             </td>\r\n           </tr>\r\n\r\n          <!-- BODY -->\r\n          <tr>\r\n            <td style=\"padding:30px; color:#333; text-align:center;\">\r\n\r\n              <div style=\"font-size: 48px; margin-bottom: 20px;\">🌸</div>\r\n\r\n              <h2 style=\"color:#ff6b9d;\">Você é incrível! ✨</h2>\r\n\r\n              <p style=\"font-size: 18px; line-height: 1.6;\">\r\n                Continue sendo um amorziho! 💖\r\n              </p>\r\n\r\n              <!-- Decorative hearts -->\r\n              <div style=\"margin: 30px 0; font-size: 24px;\">\r\n                💕 💗 💓 💖 💝\r\n              </div>\r\n\r\n              <p style=\"font-size: 14px; color:#999; margin-top: 30px;\">\r\n                Você ilumina os dias de quem está ao seu redor!\r\n              </p>\r\n\r\n             </td>\r\n           </tr>\r\n\r\n          <!-- FOOTER -->\r\n          <tr>\r\n            <td style=\"background:#f1f1f1; padding:20px; text-align:center; font-size:12px; color:#999;\">\r\n              © 2026 RoadmApp • Com muito carinho 💙\r\n             </td>\r\n           </tr>\r\n\r\n         </table>\r\n\r\n       </td>\r\n     </tr>\r\n   </table>\r\n\r\n</body>\r\n</html>";

            return mailObj;
        }
        private static string PasswordResetTemplate()
        {
            string mailObj =
                $"<!DOCTYPE html>\r\n\r\n<html lang=\"pt-BR\">\r\n<head>\r\n  <meta charset=\"UTF-8\">\r\n  <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n  <title>Senha atualizada - RoadmApp 🔒</title>\r\n</head>\r\n\r\n<body style=\"margin:0; padding:0; background-color:#f4f7f8; font-family:Arial, sans-serif;\">\r\n\r\n  <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" style=\"padding:20px;\">\r\n    <tr>\r\n      <td align=\"center\">\r\n\r\n        <table width=\"600\" cellpadding=\"0\" cellspacing=\"0\" style=\"background:white; border-radius:12px; overflow:hidden; box-shadow:0 4px 12px rgba(0,0,0,0.1);\">\r\n\r\n          <!-- HEADER -->\r\n          <tr>\r\n            <td style=\"background:#2EC4B6; padding:30px; text-align:center; color:white;\">\r\n              <h1 style=\"margin:0;\">🐰 RoadmApp</h1>\r\n              <p style=\"margin:5px 0 0;\">Segurança em primeiro lugar</p>\r\n             </td>\r\n           </tr>\r\n\r\n          <!-- BODY -->\r\n          <tr>\r\n            <td style=\"padding:30px; color:#333;\">\r\n\r\n              <div style=\"text-align:center; font-size:56px; margin-bottom:20px;\">🔒 ✅</div>\r\n\r\n              <h2 style=\"text-align:center;\">Senha atualizada com sucesso!</h2>\r\n\r\n              <p style=\"text-align:center; font-size:16px;\">\r\n                Sua senha foi alterada com sucesso no <strong>RoadmApp</strong>.\r\n              </p>\r\n\r\n              <div style=\"background:#d4edda; border-left:4px solid #28a745; padding:15px; margin:25px 0;\">\r\n                <p style=\"margin:0; font-size:14px; color:#155724;\">\r\n                  ✅ <strong>Segurança atualizada:</strong> Se você realizou esta alteração, nenhuma ação adicional é necessária.\r\n                </p>\r\n              </div>\r\n\r\n              <!-- CTA -->\r\n              <div style=\"text-align:center; margin:30px 0;\">\r\n                <a href=\"https://roadmapp.com/login\"\r\n                   style=\"background:#2EC4B6; color:white; padding:12px 25px; border-radius:8px; text-decoration:none; font-weight:bold;\">\r\n                   Acessar minha conta 🔑\r\n                </a>\r\n              </div>\r\n\r\n              <div style=\"background:#f8f9fa; padding:15px; border-radius:8px; margin-top:20px;\">\r\n                <p style=\"margin:0; font-size:13px; color:#666;\">\r\n                  🔔 <strong>Não reconhece esta alteração?</strong><br>\r\n                  Entre em contato imediatamente com o suporte do RoadmApp.\r\n                </p>\r\n              </div>\r\n\r\n              <p style=\"font-size:14px; color:#777; margin-top:20px;\">\r\n                Se você não solicitou a alteração de senha, ignore este e-mail ou entre em contato conosco.\r\n              </p>\r\n\r\n             </td>\r\n           </tr>\r\n\r\n          <!-- FOOTER -->\r\n          <tr>\r\n            <td style=\"background:#f1f1f1; padding:20px; text-align:center; font-size:12px; color:#999;\">\r\n              © 2026 RoadmApp • Feito com 💙\r\n             </td>\r\n           </tr>\r\n\r\n         </table>\r\n\r\n       </td>\r\n     </tr>\r\n   </table>\r\n\r\n</body>\r\n</html>";

            return mailObj;
        }
    }
}
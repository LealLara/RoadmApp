using System.ComponentModel;

namespace RoadmApp.Domain.Utils.Enums
{
    public enum EEmailSender
    {
        [Description("console.roadmapp@gmail.com")]
        RoadmApp = 1,
        ///Use seu próprio email e senha de app para autenticação aqui, este é meu e em breve vou bloquear o acesso, então não se preocupe em usar ele para testes, mas se for usar, use com moderação e bloqueie o acesso depois (se for testar, limite se ao maximo de 5 envios por dia neste email - se for usar outro email  próprio autenticado, dá para enviar até 500 por dia na conta pessoal e 2.000 por dia na conta empresarial)
    }
}

namespace RoadmApp.Domain.Utils.Contants
{
    public class Messages
    {
        public const string EmailAlreadyRegistered = "O email informado já se encontra cadastrado no sistema. Para primeiro acesso, utilize a senha padrão.";
        public const string NicknameAlreadyRegistered = "Nickname já cadastrado no sistema, escolha outro.";
        public const string UserCreatedSuccessfully = "Usuário criado com sucesso. A senha padrão foi enviada ao email informado."; 
        public const string UserNotFound = "Usuário não encontrado.";
        public const string InvalidCredentials = "Credenciais inválidas.";
        public const string TokenGenerationError = "Erro ao gerar token de autenticação.";
        public const string UserLoggedIn = "Usuário logado com sucesso:";
        public const string InvalidPatternPassword = "Senha inválida. A senha padrão já foi atualizada paara este usuário";
    }
}
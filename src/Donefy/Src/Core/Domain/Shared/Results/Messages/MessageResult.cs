namespace Donefy.Src.Core.Domain.Shared.Results.Messages;
public class MessageResult
{
    public static class Common
    {
        public const string Null = null;
        public const string ParamsRequired = "Parâmetros não podem estar vazios.";
        public const string Unauthorized = "Não autorizado para acessar os dados.";
        public const string InvalidId = "ID deve ser maior que zero.";
        public const string InvalidParameters = "Parâmetros inválidos.";
        public const string InvalidValidatCandidatura = "CandidaturaId e AdminId devem ser válidos.";
        public const string InternalServerError = "Erro interno no servidor.";
        public const string Success = "Operação executada com sucesso.";
        public const string NotFound = "ID não encontrado.";
        public const string NotFoundInSearch = "Nenhum dado encontrado.";
        public const string FluentValidation = "Erro de validação";
        public const string InvalidPassword = "Senha atual incorreta.";
        public const string InvalidConfirmNewPassword = "A nova senha e a confirmação não coincidem.";
        public const string InvalidConfirmPassword = "A senha e a confirmação não coincidem.";
        public const string InvalidCredentials = "Credenciais inválidas.";
        public const string InvalidEmail = "O domínio de e-mail informado não é válido ou não aceita mensagens.";
        public const string IsValidNIP = "NIP inválido. Deve conter apenas números e ter entre 5 e 7 dígitos.";
        public const string ExistsByEmail = "Já existe um usuário com esse Email.";
        public const string ExistsByNIP = "Já existe um usuário com esse NIP.";
        public const string InvalidTelefone = "Número de telefone inválido. Deve conter 9 dígitos e começar com 9.";
    }
    public static class PermissionMessages
    {
        public const string ForbiddenGetAll = "Você não tem permissão para consultar todos os {0}.";
        public const string ForbiddenGetById = "Você não tem permissão para consultar este {0}.";
        public const string ForbiddenCreate = "Você não tem permissão para criar este {0}.";
        public const string ForbiddenUpdate = "Você não tem permissão para atualizar este {0}.";
        public const string ForbiddenDelete = "Você não tem permissão para deletar este {0}.";
        public const string ForbiddenChangePassword = "Você não tem permissão para alterar a senha deste {0}.";
        public const string ForbiddenRecoverPassword = "Você não tem permissão para recuperar a senha deste {0}.";
        public const string ForbiddenValidate = "Você não tem permissão para validar este {0}.";
    }

    public static class Operation
    {
        public const string ErrorAuth = "Erro ao autenticar.";
        public const string ErrorCreate = "Erro ao executar a operação (CRIAR).";
        public const string ErrorUpdate = "Erro ao executar a operação (UPDATE).";
        public const string ErrorDelete = "Erro ao executar a operação (DELETAR).";
        public const string ErrorSearch = "Erro ao executar a operação (SEARCH).";
        public const string ErrorGetAll = "Erro ao executar a operação (GET ALL).";
        public const string ErrorGetById = "Erro ao executar a operação (GET BY ID).";
        public const string ErroUpdateStatus = "Erro ao manipular a operação (EDITAR STATUS)";
        
    }
}


namespace NerdStore.Core.DomainObjects
{
    public class DomainException : Exception
    {
        /*Criacao de uma instancia*/
        public DomainException() { }

        /*Mensagem especializada para alimentar a exception*/
        public DomainException(string? message) : base(message) { }

        /*Mensagem com expection interna*/
        public DomainException(string? message, Exception? innerException) : base(message, innerException) { }


    }
}

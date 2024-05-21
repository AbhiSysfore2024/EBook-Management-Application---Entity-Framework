namespace CustomExceptions
{
    public class EmptOrNullSpaceUsrnmePsswrd : Exception
    {
        public EmptOrNullSpaceUsrnmePsswrd(string message) : base(message) { }

    }

    public class EqualUserNameAndPassword : Exception
    {
        public EqualUserNameAndPassword(string message) : base(message) { }
    }

    public class NotUniqueUserName : Exception
    {
        public NotUniqueUserName(string message) : base(message) { }
    }

    public class AuthorNotFound : Exception
    {
        public AuthorNotFound(string message) : base(message) { }
    }

    public class BookNotFound : Exception
    {
        public BookNotFound(string message) : base(message) { }
    }

}

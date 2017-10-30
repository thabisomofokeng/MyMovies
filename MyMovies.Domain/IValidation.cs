namespace MyMovies.Domain
{
    public interface IValidation<T> where T : class
    {
        void Validate(T entity);
    }
}

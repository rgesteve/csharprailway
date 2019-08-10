namespace roptry.Domain
{
  public interface IHandler<T> where T : IEvent
  {
    void Handle(T msg);
  }
}
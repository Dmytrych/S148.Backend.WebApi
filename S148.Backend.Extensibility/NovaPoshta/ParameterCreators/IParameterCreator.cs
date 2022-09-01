namespace S148.Backend.Extensibility.NovaPoshta.ParameterCreators;

public interface IParameterCreator<TParameter, TFilter>
{
    TParameter Create(TFilter filter);
}
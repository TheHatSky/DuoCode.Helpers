namespace DuoCode.JQuery
{
    public class AjaxSettings<TResponse> : AjaxSettings<TResponse, JsonDeserializer<TResponse>>
        where TResponse : new()
    {
    }
}

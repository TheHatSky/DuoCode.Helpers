namespace DuoCode.JQuery
{
    public enum AjaxRequestReadyState : ushort
    {
        RequestNotInitialized = 0,
        ServerConnectionEstablished,
        RequestReceived,
        ProcessingRequest,
        ResponseReady
    }
}
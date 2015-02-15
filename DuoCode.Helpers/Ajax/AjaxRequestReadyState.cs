namespace DuoCode.Helpers
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
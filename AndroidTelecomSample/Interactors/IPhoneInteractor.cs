namespace AndroidTelecomSample.Interactors
{
    public interface IPhoneInteractor
    {
        void Hangup();
        void Call(string phoneNumber);
    }
}
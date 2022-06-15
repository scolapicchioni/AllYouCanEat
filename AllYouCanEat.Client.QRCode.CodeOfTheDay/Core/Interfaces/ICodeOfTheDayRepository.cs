namespace AllYouCanEat.Client.QRCode.CodeOfTheDay.Core.Interfaces;
public interface ICodeOfTheDayRepository {
    Task<string> GetCodeOfTheDay();
}

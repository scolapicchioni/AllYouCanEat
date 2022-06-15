namespace AllYouCanEat.Client.QRCode.CodeOfTheDay.Core.Interfaces;
public interface ICodeOfTheDayService {
    Task<string> GetCodeOfTheDay();
}

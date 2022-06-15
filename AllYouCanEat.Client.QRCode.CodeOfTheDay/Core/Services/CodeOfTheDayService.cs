using AllYouCanEat.Client.QRCode.CodeOfTheDay.Core.Interfaces;

namespace AllYouCanEat.Client.QRCode.CodeOfTheDay.Core.Services;
public class CodeOfTheDayService : ICodeOfTheDayService {
    private readonly ICodeOfTheDayRepository repository;

    public CodeOfTheDayService(ICodeOfTheDayRepository repository) {
        this.repository = repository;
    }

    public Task<string> GetCodeOfTheDay() => repository.GetCodeOfTheDay();
}

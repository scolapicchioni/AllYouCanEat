using AllYouCanEat.Client.QRCode.CodeOfTheDay.Core.Interfaces;

namespace AllYouCanEat.Client.QRCode.CodeOfTheDay.Infrastructure.Repositories;
public class CodeOfTheDayRepository : ICodeOfTheDayRepository {
    public Task<string> GetCodeOfTheDay() {
        return Task.FromResult($"12345{(DateTime.Now.Second / 10)}");
    }
}

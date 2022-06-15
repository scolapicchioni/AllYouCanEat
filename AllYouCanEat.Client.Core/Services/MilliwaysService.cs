using AllYouCanEat.Client.Core.Interfaces;

namespace AllYouCanEat.Client.Core.Services;
public class MilliwaysService : IMilliwaysService {
    private readonly IMilliwaysRepository repository;

    public MilliwaysService(IMilliwaysRepository repository) {
        this.repository = repository;
    }
}

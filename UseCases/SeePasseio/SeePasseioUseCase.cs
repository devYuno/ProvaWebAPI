namespace WebTuor.UseCases.SeePasseio;

public class SeePasseioUseCase
{
    public async Task<Result<SeePasseioResponse>> Do(SeePasseioPayload payload)
    {
        return Result<SeePasseioResponse>.Fail("");
    }

}
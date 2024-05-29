using Marombastore.Core.Seedwork;
using Marombastore.Payment.Application.Services;
using Marombastore.Payment.Domain.Repository;

namespace Marombastore.Payment.Application.UseCases;

public class PayUseCase
{
    private readonly IPaymentService _paymentService;
    private readonly IPaymentRepository _paymentRepository;
    private readonly IUnitOfWork _unityOfWork;

    public PayUseCase(IPaymentService paymentService, IPaymentRepository paymentRepository, IUnitOfWork unityOfWork)
    {
        _paymentService = paymentService;
        _paymentRepository = paymentRepository;
        _unityOfWork = unityOfWork;
    }
}

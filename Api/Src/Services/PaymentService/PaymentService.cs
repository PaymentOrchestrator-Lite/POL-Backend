using Api.Src.Infrastructure.Sqlite;
using Api.Src.Infrastructure.Sqlite.Models;
using Api.Src.Util.Di;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Api.Src.Services.PaymentService
{
    [iBaseServiceAttribute(eServiceScope.Scoped)]
    public class PaymentService
    {
        private readonly SqlLiteInfrastructure _sqlLiteInfra;
        public PaymentService(SqlLiteInfrastructure sqlLiteInfrastructure)
        {
            _sqlLiteInfra = sqlLiteInfrastructure;
        }

        public async Task AddPaymentRecordAsync(PaymentModel model)
        {
            _sqlLiteInfra.PaymentModel.Add(model);
            await _sqlLiteInfra.SaveChangesAsync();
        }

        public async Task<List<PaymentModel>> GetPaymentTableToListAsync()
        {
            return await _sqlLiteInfra.PaymentModel.ToListAsync();
        }

        public async Task<PaymentModel?> GetPaymentByIdAsync(Guid id)
        {
            return await _sqlLiteInfra.PaymentModel.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<PaymentModel> UpdatePaymentAsync(PaymentModel model)
        {
            _sqlLiteInfra.PaymentModel.Update(model);
            await _sqlLiteInfra.SaveChangesAsync();
            return model;
        }
    }
}